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
        private readonly string _preExamPrefix = "preExam:{0}:{1}:{2}:{3}";
        private readonly string _examSubjectsPrefix = "subjects:{0}:{1}:{2}";
        private readonly string _generalMetricpPrefix = "generalmetric:{0}";
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
        public async Task SaveReportMetrics(ExamGeneralMetrics examGeneralMetrics, Guid examId)
        {
            var options = new DistributedCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromDays(7)
            };
            var cacheKey = string.Format(_generalMetricpPrefix, examId);
            var examGeneralMetricsSerialized = JsonConvert.SerializeObject(examGeneralMetrics, _jsonSerializerSettings);
            
            await _cache.SetStringAsync(cacheKey, examGeneralMetricsSerialized, options);
        }
        public async Task<ExamGeneralMetrics> GetReportMetrics(Guid examId)
        {
            var examGeneralMetricsSerialized = await _cache.GetStringAsync(string.Format(_generalMetricpPrefix, examId));
            if (string.IsNullOrEmpty(examGeneralMetricsSerialized))
                return null;
            return JsonConvert.DeserializeObject<ExamGeneralMetrics>(examGeneralMetricsSerialized, _jsonSerializerSettings);
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

        public async Task SavePreExam(PreExamVO preExamVO)
        {
            var options = new DistributedCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromMinutes(20)
            };
            var keyPreExam = string.Format(_preExamPrefix, Enum.GetName(typeof(EExamModel), preExamVO.ExamModel), Enum.GetName(typeof(EExamType), preExamVO.ExamModel), 
                                            preExamVO.Number, Enum.GetName(typeof(EExamTopic), preExamVO.ExamTopic));
            var preExamVOSerialized = JsonConvert.SerializeObject(preExamVO, _jsonSerializerSettings);
            await _cache.SetStringAsync(keyPreExam, preExamVOSerialized, options);
        }

        public async Task<PreExamVO> GetPreExam(EExamModel examModel, EExamType examType, int number, EExamTopic examTopic)
        {
            var key = string.Format(_preExamPrefix, Enum.GetName(typeof(EExamModel), examModel), Enum.GetName(typeof(EExamType), examModel),
                                            number, Enum.GetName(typeof(EExamTopic), examTopic));
            var periodsSerialized = await _cache.GetStringAsync(key);
            return JsonConvert.DeserializeObject<PreExamVO>(periodsSerialized, _jsonSerializerSettings);
        }
        //TODO: EXCLUIR, METODO DE DELETAR RESPOSTAS SO DEVE EXISTIR DURANTE DESENVOLVIMENTO
        public async Task DeleteUserStartedExam(Guid userId, Guid examId)
        {
            var cacheKey = string.Format(_examPrefix, examId) + userId;
            await _cache.RemoveAsync(cacheKey);
        }
    }
    public class PrivateResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var prop = base.CreateProperty(member, memberSerialization);
            if (member.Name == nameof(Question.QuestionAnswers))
                prop.Writable = false;
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
