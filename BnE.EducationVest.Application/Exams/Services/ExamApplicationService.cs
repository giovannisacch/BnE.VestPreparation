using BnE.EducationVest.Application.Common.Extensions;
using BnE.EducationVest.Application.Exams.Interfaces;
using BnE.EducationVest.Application.Exams.Mappings;
using BnE.EducationVest.Application.Exams.ViewModels;
using BnE.EducationVest.Application.Exams.ViewModels.Request;
using BnE.EducationVest.Application.Exams.ViewModels.Response;
using BnE.EducationVest.Domain;
using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.Enums;
using BnE.EducationVest.Domain.Exam.Extensions;
using BnE.EducationVest.Domain.Exam.Interfaces;
using BnE.EducationVest.Domain.Exam.Interfaces.Infra;
using BnE.EducationVest.Domain.Exam.Interfaces.InfraService;
using BnE.EducationVest.Domain.Users.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.Services
{
    public class ExamApplicationService : IExamApplicationService
    {
        private readonly IExamRepository _examRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserDomainService _userDomainService;
        private readonly IExamDomainService _examDomainService;
        private readonly IExamCacheService _examCacheService;
        public ExamApplicationService(IExamRepository examRepository, IHttpContextAccessor httpContextAccessor,
                                      IUserDomainService userDomainService, IExamDomainService examDomainService,
                                      IExamCacheService examCacheService)
        {
            _examRepository = examRepository;
            _httpContextAccessor = httpContextAccessor;
            _userDomainService = userDomainService;
            _examDomainService = examDomainService;
            _examCacheService = examCacheService;
        }

        public async Task<Either<ErrorResponseModel, object>> UpdateExamQuestionAnswer(UpdateAnswerQuestionRequestViewModel updateAnswerQuestionResponse)
        {
            var tokenData = _httpContextAccessor.GetTokenData();
            var userId = await _userDomainService.GetUserIdByCognitoId(Guid.Parse(tokenData.CognitoId));
            var actualQuestionAnswer = await _examRepository.GetQuestionAnswerById(updateAnswerQuestionResponse.QuestionAnswerId);
            if (actualQuestionAnswer == null)
                return new Either<ErrorResponseModel, object>(new ErrorResponseModel(ErrorConstants.QUESTION_ANSWER_NOT_FOUND), HttpStatusCode.BadRequest);
            if (!actualQuestionAnswer.UserId.Equals(userId))
                return new Either<ErrorResponseModel, object>(null, HttpStatusCode.Unauthorized);

            actualQuestionAnswer.UpdateChosenAlternative(updateAnswerQuestionResponse.ChosenAlternativeId);
            await _examRepository.UpdateExamQuestionAnswer(actualQuestionAnswer);
            return new Either<ErrorResponseModel, object>(null, HttpStatusCode.OK);
        }
        public async Task<Either<ErrorResponseModel, Guid>> AddExamQuestionAnswer(AnswerQuestionRequestViewModel answerQuestionResponse)
        {
            var tokenData = _httpContextAccessor.GetTokenData();
            var userId = await _userDomainService.GetUserIdByCognitoId(Guid.Parse(tokenData.CognitoId));
            var newAnswer = new QuestionAnswer(answerQuestionResponse.QuestionId, userId, answerQuestionResponse.ChosenAlternativeId);
            await _examDomainService.AnswerExamQuestion(answerQuestionResponse.ExamId, newAnswer);
            return new Either<ErrorResponseModel, Guid>(newAnswer.Id, HttpStatusCode.OK);
        }
        public async Task<Either<ErrorResponseModel, object>> AddExamPeriods(Guid examId, List<ExamPeriodViewModel> periods)
        {
            var exam = await _examRepository.FindByIdAsync(examId);
            if (exam == null)
                return new Either<ErrorResponseModel, object>(new ErrorResponseModel(ErrorConstants.EXAM_NOT_FOUND), HttpStatusCode.BadRequest);
            periods.ForEach(period =>
                exam.AddPeriod(period.OpenDate, period.CloseDate)
            );

            await _examRepository.AddExamPeriodsAsync(exam);
            return new Either<ErrorResponseModel, object>(null, HttpStatusCode.OK);
        }

        public async Task<Either<ErrorResponseModel, Guid>> CreateExam(ExamViewModel examViewModel)
        {
            var exam = examViewModel.MapToDomain();
            await _examDomainService.CreateExam(exam);
            return new Either<ErrorResponseModel, Guid>(exam.Id, HttpStatusCode.OK);
        }

        public async Task<Either<ErrorResponseModel, AvailableExamsViewModel>> GetAvailableExamsByUser()
        {
            var token =_httpContextAccessor.GetTokenData();
            var userId = await _userDomainService.GetUserIdByCognitoId(Guid.Parse(token.CognitoId));

            var availableExams = await _examRepository.GetAvailableExams();
            var response = new AvailableExamsViewModel();
            response.AvailableExams = availableExams.Select(x => new AvailableExamViewModel()
            {
                ExamId = x.Id,
                ExamName = $"Simulado {x.ExamNumber} - {Enum.GetName(typeof(EExamModel), x.ExamModel)}",
                ExpirationDate = x.GetActualAvailablePeriod().CloseDate,
                WasStarted = _examCacheService.VerifyIfUserStartedExam(userId, x.Id).Result,
                QuestionsCount = x.ExamModel.GetQuestionAmount()
            }).ToList();

            foreach (var item in response.AvailableExams.Where(x => x.WasStarted).ToList())
            {
                var questionList = await _examRepository.GetQuestionWithAnswersByUserExamAsync(item.ExamId, userId);
                if (questionList.Any(x => x.QuestionAnswers == null || x.QuestionAnswers.Count == 0))
                    continue;
                response.AvailableExams.Remove(item);
            }

            return new Either<ErrorResponseModel, AvailableExamsViewModel>(response, HttpStatusCode.OK);
        }

        public async Task<Either<ErrorResponseModel, ExamViewModel>> GetExam(Guid examId)
        {
            var exam = await _examRepository.GetByIdWithAllIncludes(examId);
            if (exam == null)
                return new Either<ErrorResponseModel, ExamViewModel>(new ErrorResponseModel(ErrorConstants.EXAM_NOT_FOUND), System.Net.HttpStatusCode.BadRequest);

            return new Either<ErrorResponseModel, ExamViewModel>(exam.MapToViewModel(), HttpStatusCode.OK);
        }

        public async Task<Either<ErrorResponseModel, IEnumerable<ExamViewModel>>> GetAllExams()
        {
            var examList = await _examRepository.FindAllAsync(true);
            return new Either<ErrorResponseModel, IEnumerable<ExamViewModel>>(examList.Select(x => x.MapToViewModel()), HttpStatusCode.OK);
        }

        public async Task<Either<ErrorResponseModel, GetExamQuestionListViewModel>> GetQuestions(GetQuestionListPaginatedRequestViewModel getQuestionListPaginatedRequest)
        {
            var tokenData = _httpContextAccessor.GetTokenData();
            var userId = await _userDomainService.GetUserIdByCognitoId(Guid.Parse(tokenData.CognitoId));
            var questions = await _examDomainService.GetExamQuestionsWithAnswers(getQuestionListPaginatedRequest.ExamId, userId, 
                                                                                 getQuestionListPaginatedRequest.Page, getQuestionListPaginatedRequest.WasStarted);
            return new Either<ErrorResponseModel, GetExamQuestionListViewModel>(new GetExamQuestionListViewModel() 
            {
                Questions = questions.Select(x => x.MapToViewModel())
            }, HttpStatusCode.OK);
        }

        public async Task UploadExamPeriods(UploadExamPeriodsRequestViewModel uploadExamPeriodsRequestViewModel)
        {
            await _examCacheService.SaveExamPeriods(uploadExamPeriodsRequestViewModel.ExamModel,
                                              uploadExamPeriodsRequestViewModel.ExamType, 
                                              uploadExamPeriodsRequestViewModel.ExamNumber,
                                              uploadExamPeriodsRequestViewModel.ExamPeriods.Select(x => x.MapToVO()).ToList());
        }
        public async Task<List<ExamPeriodViewModel>> GetExamPeriods(EExamModel examModel, EExamType examType, int number)
        {
            var examPeriodVOList = await _examCacheService.GetExamPeriods(examModel, examType, number);
            return examPeriodVOList.Select(x => x.MapToViewModel()).ToList();
        }
    }
}
