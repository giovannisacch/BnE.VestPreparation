using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.Interfaces.InfraService;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace BnE.EducationVest.Infra.Service.Exam
{
    public class ExamCacheService : IExamCacheService
    {
        private readonly IDistributedCache _cache;
        private readonly string _examPrefix = "exam:{0}:";
        private readonly string _examQuestionsByPagePrefix = "exam:{0}:questionList:{1}";
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        public ExamCacheService(IDistributedCache cache)
        {
            _cache = cache;
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new PrivateResolver()
            };
        }
        public async Task SaveUserStartedExam(Guid userId, Domain.Exam.Entities.Exam exam)
        {
            DateTimeOffset examAbosluteDatetime = DateTime.SpecifyKind(exam.GetActualAvailablePeriod().CloseDate, DateTimeKind.Utc);
            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = examAbosluteDatetime
            };
            var cacheKey = string.Format(_examPrefix, exam.Id) + userId;
            await _cache.SetStringAsync(cacheKey, true.ToString(), options);
        }
        public async Task<bool> VerifyIfUserStartedExam(Guid userId, Guid examId)
        {
            var cacheKey = string.Format(_examPrefix, examId) + userId;
            var key = await _cache.GetStringAsync(cacheKey);
            if (key == true.ToString())
                return true;
            else
                return false;
        }
        public async Task<List<Question>> GetQuestionsByPageAsync(Guid examId, int page)
        {
            var questionListSerialized = await _cache.GetStringAsync(string.Format(_examQuestionsByPagePrefix, examId, page));
            if (string.IsNullOrEmpty(questionListSerialized))
                return null;
            return JsonConvert.DeserializeObject<List<Question>>(questionListSerialized, _jsonSerializerSettings);
        }
        public async Task SaveQuestionListByPage(Domain.Exam.Entities.Exam exam, List<Question> questionList, int page)
        {
            DateTimeOffset examAbosluteDatetime = DateTime.SpecifyKind(exam.GetActualAvailablePeriod().CloseDate, DateTimeKind.Utc);
            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = examAbosluteDatetime
            };
            var questionListSerialized = JsonConvert.SerializeObject(questionList, _jsonSerializerSettings);
            await _cache.SetStringAsync(string.Format(_examQuestionsByPagePrefix, exam.Id, page), questionListSerialized, options);
        }
    }
    public class PrivateResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var prop = base.CreateProperty(member, memberSerialization);
            if (!prop.Writable)
            {
                var property = member as PropertyInfo;
                var hasPrivateSetter = property?.GetSetMethod(true) != null;
                prop.Writable = hasPrivateSetter;
            }
            return prop;
        }
    }
}
