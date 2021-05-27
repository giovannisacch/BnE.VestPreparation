using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.Enums;
using BnE.EducationVest.Domain.Exam.Interfaces.InfraService;
using BnE.EducationVest.Domain.Exam.ValueObjects;
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
        private readonly string _examPeriodPrefix = "periods:{0}:{1}:{2}";
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        public ExamCacheService(IDistributedCache cache)
        {
            _cache = cache;
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
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
            DateTimeOffset examAbosluteDatetime = DateTime.SpecifyKind(exam.GetActualAvailablePeriod().CloseDate, DateTimeKind.Local);
            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = examAbosluteDatetime
            };
            var questionListSerialized = JsonConvert.SerializeObject(questionList, _jsonSerializerSettings);
            await _cache.SetStringAsync(string.Format(_examQuestionsByPagePrefix, exam.Id, page), questionListSerialized, options);
        }

        public async Task SaveExamPeriods(EExamModel examModel, EExamType examType, int number, List<ExamPeriodVO> periods)
        {
            var options = new DistributedCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromMinutes(2)
            };
            var key = string.Format(_examPeriodPrefix, Enum.GetName(typeof(EExamModel), examModel), Enum.GetName(typeof(EExamType), examType), number);
            var periodsSerialized = JsonConvert.SerializeObject(periods, _jsonSerializerSettings);
            await _cache.SetStringAsync(key, periodsSerialized, options);
        }

        public async Task<List<ExamPeriodVO>> GetExamPeriods(EExamModel examModel, EExamType examType, int number)
        {
            var key = string.Format(_examPeriodPrefix, Enum.GetName(typeof(EExamModel), examModel), Enum.GetName(typeof(EExamType), examType), number);
            var periodsSerialized = await _cache.GetStringAsync(key);
            return JsonConvert.DeserializeObject<List<ExamPeriodVO>>(periodsSerialized, _jsonSerializerSettings);

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
                if (property != null)
                {
                    var hasNonPublicSetter = property.GetSetMethod(true) != null;
                    prop.Writable = hasNonPublicSetter;
                }
            }
            return prop;
        }
    }
}
