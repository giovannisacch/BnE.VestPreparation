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
using BnE.EducationVest.Domain.Exam.RelationEntities;
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
            var actualQuestionAnswer = await _examRepository.GetQuestionAnswerByIdAndUser(updateAnswerQuestionResponse.QuestionAnswerId, userId);
            if (actualQuestionAnswer == null)
                return new Either<ErrorResponseModel, object>(new ErrorResponseModel(ErrorConstants.QUESTION_ANSWER_NOT_FOUND), HttpStatusCode.BadRequest);
            if (!actualQuestionAnswer.UserId.Equals(userId))
                return new Either<ErrorResponseModel, object>(null, HttpStatusCode.Unauthorized);
            if(actualQuestionAnswer.Question.Exam.UserHasFinalized(userId))
                return new Either<ErrorResponseModel, object>(new ErrorResponseModel(ErrorConstants.ALREADY_FINALIZED_EXAM), HttpStatusCode.BadRequest);

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
            //Colocar na leitura de documento
            var subjectIdList = await _examCacheService.GetExamSubjects(examViewModel.ExamModel, examViewModel.ExamType, examViewModel.ExamNumber);
            for (int i = 0; i < subjectIdList.Count; i++)
                examViewModel.QuestionList[i].SubjectId = subjectIdList[i];
            
            var exam = examViewModel.MapToDomain();
            await _examDomainService.CreateExam(exam);
            return new Either<ErrorResponseModel, Guid>(exam.Id, HttpStatusCode.OK);
        }

        public async Task<Either<ErrorResponseModel, AvailableExamsViewModel>> GetAvailableExamsByUser()
        {
            var token =_httpContextAccessor.GetTokenData();
            var userId = await _userDomainService.GetUserIdByCognitoId(Guid.Parse(token.CognitoId));

            var availableExams = await _examRepository.GetAvailableExamsByUser(userId);
            var response = new AvailableExamsViewModel();
            response.AvailableExams = availableExams.Select(x => new AvailableExamViewModel()
            {
                ExamId = x.Id,
                ExamName = GetFormatedExamName(x),
                ExpirationDate = x.GetActualAvailablePeriod().CloseDate,
                WasStarted = _examCacheService.VerifyIfUserStartedExam(userId, x.Id).Result,
                QuestionsCount = x.ExamModel.GetQuestionAmount()
            }).ToList();

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

        public async Task UploadExamPeriodsAndSubjects(UploadExamPeriodsRequestViewModel uploadExamPeriodsRequestViewModel)
        {
            await _examCacheService.SaveExamPeriodsAndSubjects(uploadExamPeriodsRequestViewModel.ExamModel,
                                              uploadExamPeriodsRequestViewModel.ExamType, 
                                              uploadExamPeriodsRequestViewModel.ExamNumber,
                                              uploadExamPeriodsRequestViewModel.ExamPeriods.Select(x => x.MapToVO()).ToList(),
                                              uploadExamPeriodsRequestViewModel.Subjects);
        }
        public async Task<List<ExamPeriodViewModel>> GetExamPeriods(EExamModel examModel, EExamType examType, int number)
        {
            var examPeriodVOList = await _examCacheService.GetExamPeriods(examModel, examType, number);
            return examPeriodVOList.Select(x => x.MapToViewModel()).ToList();
        }

        public async Task FinalizeExam(Guid ExamId)
        {
            var tokenData = _httpContextAccessor.GetTokenData();
            var userId = await _userDomainService.GetUserIdByCognitoId(Guid.Parse(tokenData.CognitoId));
            var finalizedExam = new FinalizedExam(userId, ExamId);
            await _examRepository.FinalizeExam(finalizedExam);
        }

        public async Task<IEnumerable<SubjectResponseViewModel>> GetSubjects()
        {
            var subjects = await _examRepository.GetSubjects();
            return subjects.Select(x => new SubjectResponseViewModel() { Id = x.Id, Name = x.Name });
        }
        
        public async Task<RealizedExamListViewModel> GetUserRealizedExamList()
        {
            var tokenData = _httpContextAccessor.GetTokenData();
            var userId = await _userDomainService.GetUserIdByCognitoId(Guid.Parse(tokenData.CognitoId));
            var exams = await _examRepository.GetUserFinalizedExams(userId);
            return new RealizedExamListViewModel()
            {
                RealizedExams =
                                                    exams.Select(x => new RealizedExamViewModel()
                                                    {
                                                        ExamId = x.Id,
                                                        Name = GetFormatedExamName(x),
                                                        ImageUrl = "https://emc.acidadeon.com/dbimagens/pedreira__1024x576_11032021174053.jpg"
                                                    })
            }; 
        }
        public async Task<ExamReportViewModel> GetUserExamReport(Guid examId)
        {
            var tokenData = _httpContextAccessor.GetTokenData();
            var userId = await _userDomainService.GetUserIdByCognitoId(Guid.Parse(tokenData.CognitoId));
            var examWithQuestionAndAnswers = await _examRepository.GetExamWithQuestionsAndUserAnswers(examId, userId);
            var questionsWithAnswers = examWithQuestionAndAnswers.Questions;
            var questionsGroupsBySubject = questionsWithAnswers.GroupBy(x => x.Subject.Name);
            //TODO: Separa mappings em outros metodos
            var subjectsDifficulties = new List<ExamReportSubjectDifficultyViewModel>();
            var subjectsDistribution = new List<ExamReportSubjectDistributionViewModel>();
            var acertsAndErrorsBySubject = new List<ExamReportAcertsAndErrorBySubject>();
            //VERIFICAR COMO DEFINIREMOS DIFICULDADEEEEEEE
            foreach (var questionGroup in questionsGroupsBySubject)
            {
                var groupQuestionCount = questionGroup.Count();
                subjectsDifficulties.Add(new ExamReportSubjectDifficultyViewModel()
                {
                    Name = questionGroup.Key,
                    Easy = $"{questionGroup.Count(x => x.QuestionDifficulty == EQuestionDifficulty.Easy) / groupQuestionCount}%",
                    Medium = $"{questionGroup.Count(x => x.QuestionDifficulty == EQuestionDifficulty.Medium) / groupQuestionCount}%",
                    Hard = $"{questionGroup.Count(x => x.QuestionDifficulty == EQuestionDifficulty.Hard) / groupQuestionCount}%"
                });
                subjectsDistribution.Add(new ExamReportSubjectDistributionViewModel()
                {
                    Name = questionGroup.Key,
                    QuestionNumbers = questionGroup.Select(x => x.Index)
                });
                acertsAndErrorsBySubject.Add(new ExamReportAcertsAndErrorBySubject()
                {
                    Subject = questionGroup.Key,
                    QuestionCount = groupQuestionCount,
                    CorrectCount = questionGroup.Count(x => x.GetUserAnswer(userId).IsCorrect())
                });
            }
            var acertsAndErrorsByQuestion = questionsWithAnswers.Select(x => new ExamReportAcertsAndErrorByQuestion()
            {
                QuestionNumber = x.Index,
                Subject = x.Subject.Name,
                //Pegar alternativa pelo index (ex: index 0 = A)
                ChosenAlternative = x.GetUserAnswer(userId).ChosenAlternative.Index.ToString(),
                RightAlternative = x.GetRightAlternative().Index.ToString(),
                Difficulty = x.QuestionDifficulty.ToString()
            });
            var userPerformances = new List<ExamReportPerformanceViewModel>()
            {
                new ExamReportPerformanceViewModel()
                {
                    Name = "Pontuação",
                    Value = examWithQuestionAndAnswers.GetUserTotalScore(userId)
                },
                new ExamReportPerformanceViewModel()
                {
                    Name = "Matemática",
                    Value = examWithQuestionAndAnswers.GetUserMathPerformance(userId)
                },
                new ExamReportPerformanceViewModel()
                {
                    Name = "Português",
                    Value = examWithQuestionAndAnswers.GetUserPortuguesePerformance(userId)
                }
            };

            return new ExamReportViewModel()
            {
                MyPerformances = null,
                SubjectsDifficulties = subjectsDifficulties,
                SubjectsDistribution = subjectsDistribution,
                AcertsAndErrorsBySubject = acertsAndErrorsBySubject,
                AcertsAndErrorsByQuestion = acertsAndErrorsByQuestion
            };

        }
        private string GetFormatedExamName(Exam exam)
        {
            return $"Simulado {exam.ExamNumber} - {Enum.GetName(typeof(EExamModel), exam.ExamModel)}";
        }
    }
}
