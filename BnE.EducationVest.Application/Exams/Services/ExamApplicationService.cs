using BnE.EducationVest.Application.Common.Extensions;
using BnE.EducationVest.Application.Exams.Interfaces;
using BnE.EducationVest.Application.Exams.Mappings;
using BnE.EducationVest.Application.Exams.ViewModels;
using BnE.EducationVest.Application.Exams.ViewModels.Request;
using BnE.EducationVest.Application.Exams.ViewModels.Response;
using BnE.EducationVest.Domain;
using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Common.Helpers;
using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.Enums;
using BnE.EducationVest.Domain.Exam.Extensions;
using BnE.EducationVest.Domain.Exam.Interfaces;
using BnE.EducationVest.Domain.Exam.Interfaces.Infra;
using BnE.EducationVest.Domain.Exam.Interfaces.InfraService;
using BnE.EducationVest.Domain.Exam.RelationEntities;
using BnE.EducationVest.Domain.Exam.ValueObjects;
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
            if (actualQuestionAnswer.Question.Exam.UserHasFinalized(userId))
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

        public async Task<Either<ErrorResponseModel, Guid>> CreateExam(ExamViewModel examViewModel, PreExamVO preExamVO)
        {
            //Colocar na leitura de documento
            for (int i = 0; i < preExamVO.SubjectIdList.Count; i++)
                examViewModel.QuestionList[i].SubjectId = preExamVO.SubjectIdList[i];

            var exam = examViewModel.MapToDomain();
            await _examDomainService.CreateExam(exam);
            return new Either<ErrorResponseModel, Guid>(exam.Id, HttpStatusCode.OK);
        }

        public async Task<Either<ErrorResponseModel, AvailableExamsViewModel>> GetAvailableExamsByUser()
        {
            var token = _httpContextAccessor.GetTokenData();
            var userId = await _userDomainService.GetUserIdByCognitoId(Guid.Parse(token.CognitoId));

            var availableExams = await _examRepository.GetAvailableExamsByUser(userId);
            var response = new AvailableExamsViewModel()
            {
                AvailableExams = new List<AvailableExamViewModel>()
            };
            foreach (var exam in availableExams)
            {
                var userStartedExam = await _examCacheService.VerifyIfUserStartedExam(userId, exam.Id);
                response.AvailableExams.Add(new AvailableExamViewModel()
                {
                    ExamId = exam.Id,
                    ExamName = GetFormatedExamName(exam, false),
                    ExpirationDate = exam.GetActualAvailablePeriod().CloseDate,
                    WasStarted = userStartedExam,

                    QuestionsCount = (exam.Id == Guid.Parse("1ace14ef-7f83-4ad0-a506-e0113cfd1632") || exam.Id == Guid.Parse("47415a56-b108-4001-87f5-bdb3d5095c1b"))  ? 15 : exam.Id == Guid.Parse("265d190a-8199-49c6-85e0-141448c7c47a") ? 30
                                      : (exam.Id == Guid.Parse("f9f6e67c-2ce4-4af7-a0d7-7f5f19c6630c") || exam.Id == Guid.Parse("b6633480-4f02-49c4-88bb-e3f38056e092")) ? 30 : exam.ExamModel.GetQuestionAmount(),

                    LastQuestionAnswered = (userStartedExam) ? _examRepository.GetLastExamQuestionAnsweredByUserAsync(exam.Id, userId).Result.Index : null,
                    WasFinalized = exam.Finalizeds.Count > 0
                });
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

        public async Task UploadPreExam(UploadExamPeriodsRequestViewModel uploadExamPeriodsRequestViewModel)
        {
            await _examCacheService.SavePreExam(new PreExamVO(uploadExamPeriodsRequestViewModel.ExamModel,
                                              uploadExamPeriodsRequestViewModel.ExamType,
                                              uploadExamPeriodsRequestViewModel.ExamNumber,
                                              uploadExamPeriodsRequestViewModel.ExamPeriods.Select(x => x.MapToVO()).ToList(),
                                              uploadExamPeriodsRequestViewModel.Subjects,
                                              uploadExamPeriodsRequestViewModel.ExamTopic,
                                              uploadExamPeriodsRequestViewModel.ExamFatherId));
        }
        public async Task<PreExamVO> GetPreExamVO(EExamModel examModel, EExamType examType, int number, EExamTopic examTopic)
        {
            var examPeriodVO = await _examCacheService.GetPreExam(examModel, examType, number, examTopic);
            return examPeriodVO;
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
            exams.RemoveAll(x => exams.Exists(exm => exm.FatherExamModuleId == x.Id) || x.FatherExamModuleId == null);

            return new RealizedExamListViewModel()
            {
                RealizedExams =
                                                    exams.Select(x => new RealizedExamViewModel()
                                                    {
                                                        ExamId = x.Id,
                                                        Name = GetFormatedExamName(x, true),
                                                        ImageUrl = "https://dev-reports-images.s3.sa-east-1.amazonaws.com/logo-insper.png"
                                                    })
            };
        }
        public async Task SetExamComparation(Guid examId)
        {
            var examWithQuestionAndAnswers = await _examRepository.GetExamAllQuestionsWithAnswers(examId);
            //TEMP - Ajustar relacionamento de exam pai e filho
            if (examWithQuestionAndAnswers.Id == Guid.Parse("f9f6e67c-2ce4-4af7-a0d7-7f5f19c6630c"))
                examWithQuestionAndAnswers.SetFatherExamModule(Guid.Parse("83c6d582-98fb-4058-bca8-7fbed3c8372f"));

            //Matematica
            var fatherExamWithQuestionAndAnswers = examWithQuestionAndAnswers.FatherExamModuleId == null
                ? null
                : await _examRepository.GetExamAllQuestionsWithAnswers(examWithQuestionAndAnswers.FatherExamModuleId.Value);
            //TEMP - Ajustar relacionamento de exam pai e filho
            var allQuestions = examWithQuestionAndAnswers.Questions.ToList();
            allQuestions.AddRange(fatherExamWithQuestionAndAnswers.Questions);
            var answersGroupByUser = allQuestions.SelectMany(x => x.QuestionAnswers.GroupBy(x => x.User));
            allQuestions.ForEach(x => x.QuestionDifficulty = CalculateQuestionDifficulty(x));
            var userIdWithTotalScore = new Dictionary<Guid, double>();

            var totalScoreSum = 0.0;
            var portugueseSum = 0.0;
            var mathSum = 0.0;
            var users = examWithQuestionAndAnswers.Finalizeds.Select(x => x.User);
            foreach (var user in users)
            {
                var userTotalScore = fatherExamWithQuestionAndAnswers.GetUserTotalScore(user.Id, examWithQuestionAndAnswers.ExamTopic == EExamTopic.NatureSciences, examWithQuestionAndAnswers.Questions);
                var userPortugueseScore = fatherExamWithQuestionAndAnswers.GetUserPortuguesePerformance(user.Id);
                var userMathScore = fatherExamWithQuestionAndAnswers.GetUserMathPerformance(user.Id);

                totalScoreSum += userTotalScore;
                mathSum += userMathScore;
                portugueseSum += userPortugueseScore;
                userIdWithTotalScore.Add(user.Id, userTotalScore);
            }

            var totalAverage = totalScoreSum / users.Count();
            var mathAverage = mathSum / users.Count();
            var portugueseAverage = portugueseSum / users.Count();
            var userIdWithTotalScoreOrdered = userIdWithTotalScore.OrderByDescending(x => x.Value);


            ExamGeneralMetrics examGeneralMetric = new ExamGeneralMetrics
            {
                MathAverage = Math.Round(mathAverage, 2),
                PortugueseAverage = Math.Round(portugueseAverage, 2),
                TotalScoreAverage = Math.Round(totalAverage, 2),
                UserIdListOrdered = userIdWithTotalScoreOrdered.Select(x => x.Key).ToList(),
                QuestionDifficulties = allQuestions.Select(x => new QuestionDifficulty { QuestionId = x.Id, Difficulty = (int)x.QuestionDifficulty }).ToList()
            };

            await _examCacheService.SaveReportMetrics(examGeneralMetric, examId);

            await _examRepository.AddGeneralMetricAsync(new GeneralMetric(examId, examGeneralMetric));
        }

        private EQuestionDifficulty CalculateQuestionDifficulty(Question question)
        {
            double questionAcerts = question.QuestionAnswers.Count(x => x.IsCorrect());
            var acertsPercentage = (questionAcerts / question.QuestionAnswers.Count()) * 100;
            if (acertsPercentage <= 40)
                return EQuestionDifficulty.Hard;
            if (acertsPercentage <= 70)
                return EQuestionDifficulty.Medium;
            if (acertsPercentage > 70)
                return EQuestionDifficulty.Easy;
            return EQuestionDifficulty.Calculating;
        }
        public async Task<ExamReportViewModel> GetUserExamReport(Guid examId)
        {
            var tokenData = _httpContextAccessor.GetTokenData();
            var userId = await _userDomainService.GetUserIdByCognitoId(Guid.Parse(tokenData.CognitoId));
            var examWithQuestionAndAnswers = await _examRepository.GetExamWithQuestionsAndUserAnswers(examId, userId);
            //TEMP - Ajustar relacionamento de exam pai e filho
            if (examWithQuestionAndAnswers.Id == Guid.Parse("f9f6e67c-2ce4-4af7-a0d7-7f5f19c6630c"))
                examWithQuestionAndAnswers.SetFatherExamModule(Guid.Parse("83c6d582-98fb-4058-bca8-7fbed3c8372f"));

            var fatherExamWithQuestionAndAnswers = examWithQuestionAndAnswers.FatherExamModuleId == null 
                ? null 
                : await _examRepository.GetExamWithQuestionsAndUserAnswers(examWithQuestionAndAnswers.FatherExamModuleId.Value, userId);
            //TEMP - Ajustar relacionamento de exam pai e filho
            var fatherExamsWithAnswers = fatherExamWithQuestionAndAnswers.Questions;
            var examsQuestionsWithAnswers = fatherExamsWithAnswers.ToList();
            foreach (var item in examWithQuestionAndAnswers.Questions)
            {
                item.SetIndex(item.Index + fatherExamsWithAnswers.Count());
                examsQuestionsWithAnswers.Add(item);
            }
            var generalMetrics = await _examCacheService.GetReportMetrics(examId);
            examsQuestionsWithAnswers.ForEach(x => x.QuestionDifficulty = (EQuestionDifficulty)generalMetrics.QuestionDifficulties.First(general => general.QuestionId == x.Id).Difficulty);

            var questionsWithAnswers = examsQuestionsWithAnswers.OrderBy(x => x.Index);
            var questionsGroupsBySubject = questionsWithAnswers.GroupBy(x => x.Subject.Name);
            //TODO: Separa mappings em outros metodos
            var subjectsDifficulties = new List<ExamReportSubjectDifficultyViewModel>();
            var subjectsDistribution = new List<ExamReportSubjectDistributionViewModel>();
            var acertsAndErrorsBySubject = new List<ExamReportAcertsAndErrorBySubject>();
            //VERIFICAR COMO DEFINIREMOS DIFICULDADEEEEEEE
            foreach (var questionGroup in questionsGroupsBySubject)
            {
                double groupQuestionCount = questionGroup.Count();
                subjectsDifficulties.Add(new ExamReportSubjectDifficultyViewModel()
                {
                    Name = questionGroup.Key,
                    Easy = $"{Math.Round((questionGroup.Count(x => x.QuestionDifficulty == EQuestionDifficulty.Easy) / groupQuestionCount * 100), 2)}%",
                    Medium = $"{Math.Round((questionGroup.Count(x => x.QuestionDifficulty == EQuestionDifficulty.Medium) / groupQuestionCount * 100)),2}%",
                    Hard = $"{Math.Round((questionGroup.Count(x => x.QuestionDifficulty == EQuestionDifficulty.Hard) / groupQuestionCount * 100),2)}%"
                });
                subjectsDistribution.Add(new ExamReportSubjectDistributionViewModel()
                {
                    Name = questionGroup.Key,
                    QuestionNumbers = questionGroup.Select(x => x.Index)
                });
                acertsAndErrorsBySubject.Add(new ExamReportAcertsAndErrorBySubject()
                {
                    Subject = questionGroup.Key,
                    QuestionCount = (int)groupQuestionCount,
                    CorrectCount = questionGroup.Count(x => (x.GetUserAnswer(userId) == null) ? false : x.GetUserAnswer(userId).IsCorrect())
                });
            }
            var acertsAndErrorsByQuestion = GetAcertsAndErrorsByQuestion(questionsWithAnswers, userId);
            var userPerformances = new List<ExamReportPerformanceViewModel>()
            {
                new ExamReportPerformanceViewModel()
                {
                    Name = "Pontuação",
                    Value = Math.Round(fatherExamWithQuestionAndAnswers.GetUserTotalScore(userId, examWithQuestionAndAnswers.ExamTopic == EExamTopic.NatureSciences, examWithQuestionAndAnswers.Questions), 2)
                },
                new ExamReportPerformanceViewModel()
                {
                    Name = "Matemática",
                    Value = Math.Round(fatherExamWithQuestionAndAnswers.GetUserMathPerformance(userId), 2)
                },
                new ExamReportPerformanceViewModel()
                {
                    Name = "Português",
                    Value = Math.Round(fatherExamWithQuestionAndAnswers.GetUserPortuguesePerformance(userId), 2)
                }
            };
            if (examWithQuestionAndAnswers.ExamTopic == EExamTopic.HumanSciences)
                userPerformances.AddRange(GetUserPerformancePlus(examWithQuestionAndAnswers.Questions, userId));
            else
                userPerformances.AddRange(GetUserPerformanceForEngineering(examWithQuestionAndAnswers.Questions, userId));

            var classPerformance = new List<ExamReportPerformanceViewModel>()
            {
                 new ExamReportPerformanceViewModel()
                {
                    Name = "Pontuação",
                    Value = generalMetrics.TotalScoreAverage
                },
                new ExamReportPerformanceViewModel()
                {
                    Name = "Matemática",
                    Value = generalMetrics.MathAverage
                },
                new ExamReportPerformanceViewModel()
                {
                    Name = "Português",
                    Value = generalMetrics.PortugueseAverage
                }
            };
            return new ExamReportViewModel()
            {
                ClassPerformance = classPerformance,
                TotalStudents = generalMetrics.UserIdListOrdered.Count(),
                Rank = generalMetrics.UserIdListOrdered.IndexOf(userId) + 1,
                ExamName = GetFormatedExamName(examWithQuestionAndAnswers, true),
                ExamDate = examWithQuestionAndAnswers.CreatedDate,
                Performance = userPerformances,
                SubjectsDifficulties = new ExamReportSubjectDifficultyViewModelCard() { SubjectDifficultyRanks = subjectsDifficulties },
                SubjectsDistribution = new ExamReportSubjectDistributionViewModelCard() { subjectDistributionTopics = subjectsDistribution },
                AcertsAndErrorsBySubject = new ExamReportAcertsAndErrorBySubjectCard() { ExamReportAcertsAndErrorBySubjectCardTopics = acertsAndErrorsBySubject },
                AcertsAndErrorsByQuestion = new ExamReportAcertsAndErrorByQuestionCard()
                {
                    ExamReportAcertsAndErrorByQuestionCardTopics = acertsAndErrorsByQuestion.ToList(),
                    ExplanationTable =
                new List<ExamReportAcertsAndErrorByQuestionExplanationTable>()
                {
                    new ExamReportAcertsAndErrorByQuestionExplanationTable()
                    {
                        Name = "Menor ou igual a 40%",
                        Value = "Difícil"
                    },
                    new ExamReportAcertsAndErrorByQuestionExplanationTable()
                    {
                        Name = "Entre 40 % e 70%",
                        Value = "Moderada"
                    },
                    new ExamReportAcertsAndErrorByQuestionExplanationTable()
                    {
                        Name = "Maior que 70 %",
                        Value = "Fácil"
                    },
                }
                }
            };
        }

        #region ExamReportPrivateMethods
        private List<ExamReportPerformanceViewModel> GetUserPerformancePlus(List<Question> questions, Guid userId)
        {
            return new List<ExamReportPerformanceViewModel>()
            {
                new ExamReportPerformanceViewModel()
                {
                    Name = "Geografia",
                    Value = Math.Round((double)questions.Where(x => x.Subject.IsGeography()).ToList()
                                        .Count(x => x.GetUserAnswer(userId) == null ? false : x.GetUserAnswer(userId).IsCorrect()), 2)
                },
                new ExamReportPerformanceViewModel()
                {
                    Name = "Sociologia",
                    Value = Math.Round((double)questions.Where(x => x.Subject.IsSociology()).ToList()
                                        .Count(x => x.GetUserAnswer(userId) == null ? false : x.GetUserAnswer(userId).IsCorrect()), 2)
                },
                new ExamReportPerformanceViewModel()
                {
                    Name = "Filosofia",
                    Value = Math.Round((double)questions.Where(x => x.Subject.IsPhilosophy()).ToList()
                                        .Count(x => x.GetUserAnswer(userId) == null ? false : x.GetUserAnswer(userId).IsCorrect()), 2)
                },
                new ExamReportPerformanceViewModel()
                {
                    Name = "História",
                    Value = Math.Round((double)questions.Where(x => x.Subject.IsHistory()).ToList()
                                        .Count(x => x.GetUserAnswer(userId) == null ? false : x.GetUserAnswer(userId).IsCorrect()), 2)
                }
            };
        }
        private List<ExamReportPerformanceViewModel> GetUserPerformanceForEngineering(List<Question> questions, Guid userId)
        {
            return new List<ExamReportPerformanceViewModel>()
            {
                new ExamReportPerformanceViewModel()
                {
                    Name = "Fisíca",
                    Value = Math.Round((double)questions.Where(x => x.Subject.IsPhysical()).ToList()
                                        .Count(x => x.GetUserAnswer(userId) == null ? false : x.GetUserAnswer(userId).IsCorrect()), 2)
                },
                new ExamReportPerformanceViewModel()
                {
                    Name = "Quimica",
                    Value = Math.Round((double)questions.Where(x => x.Subject.IsChemistry()).ToList()
                                        .Count(x => x.GetUserAnswer(userId) == null ? false : x.GetUserAnswer(userId).IsCorrect()), 2)
                },
                new ExamReportPerformanceViewModel()
                {
                    Name = "Biologia",
                    Value = Math.Round((double)questions.Where(x => x.Subject.IsBiology()).ToList()
                                        .Count(x => x.GetUserAnswer(userId) == null ? false : x.GetUserAnswer(userId).IsCorrect()), 2)
                }
            }; 
        }
        private List<ExamReportAcertsAndErrorByQuestion> GetAcertsAndErrorsByQuestion(IOrderedEnumerable<Question> questionsWithAnswers, Guid userId)
        {
            return questionsWithAnswers.Select(x => new ExamReportAcertsAndErrorByQuestion()
            {
                QuestionNumber = x.Index,
                Subject = x.Subject.Name,
                ChosenAlternative = x.GetUserAnswer(userId) == null ? "N/A" : x.GetUserAnswer(userId).ChosenAlternative.GetRespectiveIndexCharacter().ToString(),
                RightAlternative = x.GetRightAlternative().GetRespectiveIndexCharacter().ToString(),
                Difficulty = x.QuestionDifficulty.GetEnumDescription(),
            }).ToList();
        }
        #endregion
        public async Task DeleteUserAnswers(Guid examId)
        {
            var tokenData = _httpContextAccessor.GetTokenData();
            var userId = await _userDomainService.GetUserIdByCognitoId(Guid.Parse(tokenData.CognitoId));
            await _examRepository.DeleteAllUserAnswersInExam(userId, examId);
            await _examCacheService.DeleteUserStartedExam(userId, examId);
        }
        public async Task<SubjectEvolutionsResponseViewModel> GetEvolutional()
        {
            var tokenData = _httpContextAccessor.GetTokenData();
            var userId = await _userDomainService.GetUserIdByCognitoId(Guid.Parse(tokenData.CognitoId));
            //TODO: ATUALIZAR QUANDO DEFINIR QUANDO UM RELATORIO VAI APARECER, EX: FINALIZOU MAS EXAME AINDA ESTÁ DISPONIVEL
            var finalizedsExams = await _examRepository.GetUserFinalizedExamsWithAnswers(userId);
            var mathPrincipalSubjectEvolution = new SubjectEvolution()
            {
                Name = "Matemática",
                Evolution = new List<Evolution>(),
                SubTopics = new List<SubTopic>()
            };
            var portuguesePrincipalSubjectEvolution = new SubjectEvolution()
            {
                Name = "Português",
                Evolution = new List<Evolution>(),
                SubTopics = new List<SubTopic>()
            };
            var totalScorePrincipalSubjectEvolution = new SubjectEvolution()
            {
                Name = "Pontuação Total",
                Evolution = new List<Evolution>(),
                SubTopics = new List<SubTopic>()
            };
            foreach (var finalizedExam in finalizedsExams)
            {
                var finalizedExamQuestionsGroupBySubject =
                    finalizedExam.Questions.GroupBy(x => x.Subject);
                var mathSubTopicsQuestions = finalizedExamQuestionsGroupBySubject
                                        .Where(x => x.Key.SubjectFather != null && x.Key.IsMathTopic())
                                        .ToList();
                var portugueseSubTopicsQuestions = finalizedExamQuestionsGroupBySubject
                                            .Where(x => x.Key.SubjectFather != null && x.Key.IsPortugueseTopic())
                                            .ToList();


                mathPrincipalSubjectEvolution.Evolution.Add(
                    new Evolution()
                    {
                        Value = finalizedExam.GetUserMathPerformance(userId),
                        Date = finalizedExam.CreatedDate
                    });
                portuguesePrincipalSubjectEvolution.Evolution.Add(
                    new Evolution()
                    {
                        Value = finalizedExam.GetUserPortuguesePerformance(userId),
                        Date = finalizedExam.CreatedDate
                    });
                totalScorePrincipalSubjectEvolution.Evolution.Add(
                    new Evolution()
                    {
                        Value = finalizedExam.GetUserTotalScore(userId, false, null),
                        Date = finalizedExam.CreatedDate
                    });
                AddOrUpdateSubtopicValue(mathPrincipalSubjectEvolution, mathSubTopicsQuestions, finalizedExam.CreatedDate, userId);
                AddOrUpdateSubtopicValue(portuguesePrincipalSubjectEvolution, portugueseSubTopicsQuestions, finalizedExam.CreatedDate, userId);
            }

            return new SubjectEvolutionsResponseViewModel()
            {
                ChartExplanation = new ChartExplanation(),
                SubjectsEvolution = new List<SubjectEvolution>() { mathPrincipalSubjectEvolution, portuguesePrincipalSubjectEvolution }
            };
        }
        private void AddOrUpdateSubtopicValue(SubjectEvolution principalSubjectEvolution, List<IGrouping<Subject, Question>> questionGroupBySubjectsList, DateTime examDate, Guid userId)
        {
            foreach (var questionGroupBySubjects in questionGroupBySubjectsList)
            {
                if (principalSubjectEvolution.SubTopics.FirstOrDefault(x => x.Name == questionGroupBySubjects.Key.Name) == null)
                    principalSubjectEvolution.SubTopics.Add(
                    new SubTopic()
                    {
                        Name = questionGroupBySubjects.Key.Name,
                        Evolution = new List<Evolution>()
                        {
                            new Evolution()
                            {
                                Value = questionGroupBySubjects.Count(x => x.GetUserAnswer(userId).IsCorrect()),
                                Date = examDate
                            }
                        }
                    });
                else
                    principalSubjectEvolution.SubTopics.First(x => x.Name == questionGroupBySubjects.Key.Name).Evolution
                        .Add
                        (
                            new Evolution()
                            {
                                Value = questionGroupBySubjects.Count(x => x.GetUserAnswer(userId).IsCorrect()),
                                Date = examDate
                            }
                        );

            }

        }
        private ExamReportViewModel GetMockExamReport()
        {
            var subjectsDifficulties = new List<ExamReportSubjectDifficultyViewModel>()
            {
                new ExamReportSubjectDifficultyViewModel()
                {
                    Name = "Matemática",
                    Easy = "70%",
                    Medium = "80%",
                    Hard = "50%"
                },
                 new ExamReportSubjectDifficultyViewModel()
                {
                    Name = "Português",
                    Easy = "70%",
                    Medium = "30%",
                    Hard = "50%"
                }
            };
            var subjectsDistribution = new List<ExamReportSubjectDistributionViewModel>()
            {
             new ExamReportSubjectDistributionViewModel()
                {
                    Name = "Português",
                    QuestionNumbers = new List<int>(){0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15 }
                },
                        new ExamReportSubjectDistributionViewModel()
                {
                    Name = "Polinomios",
                    QuestionNumbers = new List<int>(){16, 17,17,19,20,21,22,23,24,25,26,27,28,29,30}
                },
                                     new ExamReportSubjectDistributionViewModel()
                {
                    Name = "Matematica financeira",
                    QuestionNumbers = new List<int>(){31,32,33,34,35,36,37,38,39,40}
                },
                                                  new ExamReportSubjectDistributionViewModel()
                {
                    Name = "Geometria analitica",
                    QuestionNumbers = new List<int>(){41,42,43,44,45,46,47,48,49,50 }
                },
            };
            var acertsAndErrorsBySubject = new List<ExamReportAcertsAndErrorBySubject>()
            {
                new ExamReportAcertsAndErrorBySubject()
                {
                    Subject = "Português",
                    QuestionCount = 15,
                    CorrectCount = 12
                },
                 new ExamReportAcertsAndErrorBySubject()
                {
                    Subject = "Polinomios",
                    QuestionCount = 10,
                    CorrectCount = 6
                },
                  new ExamReportAcertsAndErrorBySubject()
                {
                    Subject = "Matematica financeira",
                    QuestionCount = 10,
                    CorrectCount = 8
                },
                   new ExamReportAcertsAndErrorBySubject()
                {
                    Subject = "Geometria Analitica",
                    QuestionCount = 10,
                    CorrectCount = 4
                },
            };
            var acertsAndErrorsByQuestion = new List<ExamReportAcertsAndErrorByQuestion>()
            {

                new ExamReportAcertsAndErrorByQuestion()
                {
                    QuestionNumber = 1,
                    Subject = "Português",
                    //Pegar alternativa pelo index (ex: index 0 = A)
                    ChosenAlternative = "A",
                    RightAlternative = "B",
                    Difficulty = "Fácil"
                },
                  new ExamReportAcertsAndErrorByQuestion()
                {
                    QuestionNumber = 2,
                    Subject = "Português",
                    //Pegar alternativa pelo index (ex: index 0 = A)
                    ChosenAlternative = "A",
                    RightAlternative = "B",
                    Difficulty = "Fácil"
                },
                    new ExamReportAcertsAndErrorByQuestion()
                {
                    QuestionNumber = 3,
                    Subject = "Português",
                    //Pegar alternativa pelo index (ex: index 0 = A)
                    ChosenAlternative = "A",
                    RightAlternative = "B",
                    Difficulty = "Fácil"
                },
                      new ExamReportAcertsAndErrorByQuestion()
                {
                    QuestionNumber = 4,
                    Subject = "Português",
                    //Pegar alternativa pelo index (ex: index 0 = A)
                    ChosenAlternative = "A",
                    RightAlternative = "B",
                    Difficulty = "Difícil"
                },
                        new ExamReportAcertsAndErrorByQuestion()
                {
                    QuestionNumber = 5,
                    Subject = "Português",
                    //Pegar alternativa pelo index (ex: index 0 = A)
                    ChosenAlternative = "A",
                    RightAlternative = "A",
                    Difficulty = "Médio"
                },
                new ExamReportAcertsAndErrorByQuestion(){
                    QuestionNumber = 6,
                    Subject = "Português",
                    //Pegar alternativa pelo index (ex: index 0 = A)
                    ChosenAlternative = "A",
                    RightAlternative = "B",
                    Difficulty = "Fácil"
                },
                  new ExamReportAcertsAndErrorByQuestion()
                {
                    QuestionNumber = 7,
                    Subject = "Português",
                    //Pegar alternativa pelo index (ex: index 0 = A)
                    ChosenAlternative = "A",
                    RightAlternative = "B",
                    Difficulty = "Fácil"
                },
                    new ExamReportAcertsAndErrorByQuestion()
                {
                    QuestionNumber = 8,
                    Subject = "Português",
                    //Pegar alternativa pelo index (ex: index 0 = A)
                    ChosenAlternative = "A",
                    RightAlternative = "B",
                    Difficulty = "Fácil"
                },
                      new ExamReportAcertsAndErrorByQuestion()
                {
                    QuestionNumber = 9,
                    Subject = "Português",
                    //Pegar alternativa pelo index (ex: index 0 = A)
                    ChosenAlternative = "A",
                    RightAlternative = "B",
                    Difficulty = "Difícil"
                },
                        new ExamReportAcertsAndErrorByQuestion()
                {
                    QuestionNumber = 10,
                    Subject = "Português",
                    //Pegar alternativa pelo index (ex: index 0 = A)
                    ChosenAlternative = "A",
                    RightAlternative = "A",
                    Difficulty = "Médio"
                },
                new ExamReportAcertsAndErrorByQuestion()
                {
                    QuestionNumber = 11,
                    Subject = "Português",
                    //Pegar alternativa pelo index (ex: index 0 = A)
                    ChosenAlternative = "A",
                    RightAlternative = "B",
                    Difficulty = "Fácil"
                },
                  new ExamReportAcertsAndErrorByQuestion()
                {
                    QuestionNumber = 12,
                    Subject = "Português",
                    //Pegar alternativa pelo index (ex: index 0 = A)
                    ChosenAlternative = "A",
                    RightAlternative = "B",
                    Difficulty = "Fácil"
                },
                    new ExamReportAcertsAndErrorByQuestion()
                {
                    QuestionNumber = 13,
                    Subject = "Português",
                    //Pegar alternativa pelo index (ex: index 0 = A)
                    ChosenAlternative = "A",
                    RightAlternative = "B",
                    Difficulty = "Fácil"
                },
                      new ExamReportAcertsAndErrorByQuestion()
                {
                    QuestionNumber = 14,
                    Subject = "Português",
                    //Pegar alternativa pelo index (ex: index 0 = A)
                    ChosenAlternative = "A",
                    RightAlternative = "B",
                    Difficulty = "Difícil"
                },
                        new ExamReportAcertsAndErrorByQuestion()
                {
                    QuestionNumber = 15,
                    Subject = "Português",
                    //Pegar alternativa pelo index (ex: index 0 = A)
                    ChosenAlternative = "A",
                    RightAlternative = "A",
                    Difficulty = "Médio"
                }
            };

            var userPerformances = new List<ExamReportPerformanceViewModel>()
            {
                new ExamReportPerformanceViewModel()
                {
                    Name = "Pontuação",
                    Value = 500.00
                },
                new ExamReportPerformanceViewModel()
                {
                    Name = "Matemática",
                    Value = 16
                },
                new ExamReportPerformanceViewModel()
                {
                    Name = "Português",
                    Value = 430
                }
            };
            return new ExamReportViewModel()
            {
                Performance = userPerformances,
                SubjectsDifficulties = new ExamReportSubjectDifficultyViewModelCard() { SubjectDifficultyRanks = subjectsDifficulties },
                SubjectsDistribution = new ExamReportSubjectDistributionViewModelCard() { subjectDistributionTopics = subjectsDistribution },
                AcertsAndErrorsBySubject = new ExamReportAcertsAndErrorBySubjectCard() { ExamReportAcertsAndErrorBySubjectCardTopics = acertsAndErrorsBySubject },
                AcertsAndErrorsByQuestion = new ExamReportAcertsAndErrorByQuestionCard()
                {
                    ExamReportAcertsAndErrorByQuestionCardTopics = acertsAndErrorsByQuestion,
                    ExplanationTable =
                new List<ExamReportAcertsAndErrorByQuestionExplanationTable>()
                {
                    new ExamReportAcertsAndErrorByQuestionExplanationTable()
                    {
                        Name = "Menor ou igual a 40%",
                        Value = "Difícil"
                    },
                    new ExamReportAcertsAndErrorByQuestionExplanationTable()
                    {
                        Name = "Entre 40 % e 70%",
                        Value = "Moderada"
                    },
                    new ExamReportAcertsAndErrorByQuestionExplanationTable()
                    {
                        Name = "Maior que 70 %",
                        Value = "Fácil"
                    },
                }
                }
            };
        }
        private string GetFormatedExamName(Exam exam, bool isReport)
        {
            var baseName = $"Simulado { exam.ExamNumber} - { Enum.GetName(typeof(EExamModel), exam.ExamModel)}";
            if (isReport)
                return baseName;
            return $"{baseName} - {exam.ExamTopic.GetEnumDescription()}";
        }
    }
}
