﻿using BnE.EducationVest.Domain.Common.Infra;
using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.RelationEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Interfaces.Infra
{
    public interface IExamRepository : IBaseRepository<Entities.Exam>
    {
        Task<List<Entities.Exam>> GetAvailableExamsByUser(Guid userId);
        Task<Entities.Exam> GetByIdWithAllIncludes(Guid id);
        Task AddExamPeriodsAsync(Entities.Exam exam);
        Task AddExamQuestionAnswer(QuestionAnswer questionAnswer);
        Task UpdateExamQuestionAnswer(QuestionAnswer questionAnswer);
        Task<QuestionAnswer> GetQuestionAnswerByIdAndUser(Guid questionAnswerId, Guid userId);
        Task<List<Question>> GetExamQuestions(Guid examId, Guid userId, int from, int amount);
        Task<Entities.Exam> GetExamWithQuestionsAndUserAnswers(Guid examId, Guid userId);
        Task<Entities.Exam> GetExamWithPeriodsById(Guid examId);
        Task FinalizeExam(FinalizedExam finalizedExam);
        Task<List<Subject>> GetSubjects();
        Task<List<Entities.Exam>> GetUserFinalizedExams(Guid userId);
        Task<List<Entities.Exam>> GetUserFinalizedExamsWithAnswers(Guid userId);
        Task<Question> GetLastExamQuestionAnsweredByUserAsync(Guid examId, Guid userId);
        Task DeleteAllUserAnswersInExam(Guid userId, Guid examId);
        Task<Entities.Exam> GetExamAllQuestionsWithAnswers(Guid examId);
        Task<QuestionAnswer> GetLastQuestionAnswerByUserAsync(Guid questionId, Guid userId);
        Task AddGeneralMetricAsync(GeneralMetric generalMetric);
        Task<GeneralMetric> GetGeneralMetricsByExamId(Guid examId);
        Task AddQuestionsAnswersRange(List<QuestionAnswer> questionAnswers);
        Task<List<Entities.Exam>> GetExamsByFilter(Guid? userId, int? examTopic, int? examModel, int? examNumber);
    }
}
