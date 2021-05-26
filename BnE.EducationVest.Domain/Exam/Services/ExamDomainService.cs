using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.Interfaces;
using BnE.EducationVest.Domain.Exam.Interfaces.Infra;
using BnE.EducationVest.Domain.Exam.Interfaces.InfraService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Services
{
    public class ExamDomainService : IExamDomainService
    {
        private readonly IExamRepository _examRepository;
        private readonly IExamCacheService _examCacheService;
        public ExamDomainService(IExamCacheService examCacheService,IExamRepository examRepository)
        {
            _examCacheService = examCacheService;
            _examRepository = examRepository;
        }
        public async Task<List<Question>> GetExamQuestionsWithAnswers(Guid examId, Guid userId, int pageNumber, bool userAlreadyStarted)
        {
            var from = (pageNumber - 1) * 10;
            var to = (pageNumber) * 10;
            if (userAlreadyStarted)
                return await _examRepository.GetExamQuestions(examId, userId, from, to);

            var questionList = await _examCacheService.GetQuestionsByPageAsync(examId, pageNumber);
            if (questionList == null)
            {
                var exam = await _examRepository.GetExamWithPeriodsById(examId);
                questionList = await _examRepository.GetExamQuestions(examId, userId, from, to);
                await _examCacheService.SaveQuestionListByPage(exam, questionList, pageNumber);
            }

            return questionList;
        }
        public async Task AnswerExamQuestion(Guid examId, QuestionAnswer questionAnswer)
        {
            var questionList = await _examCacheService.GetQuestionsByPageAsync(examId, 1);
            var questionInQuestionList = questionList.FirstOrDefault(x => x.Id == questionAnswer.QuestionId);
            if (questionInQuestionList != null && questionInQuestionList.Index == 0)
            {
                var exam = await _examRepository.GetExamWithPeriodsById(examId);
                await _examCacheService.SaveUserStartedExam(questionAnswer.UserId, exam);
            }
            await _examRepository.AddExamQuestionAnswer(questionAnswer);
        }
    }
}
