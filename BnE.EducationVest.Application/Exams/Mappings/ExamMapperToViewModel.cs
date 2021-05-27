using BnE.EducationVest.Application.Exams.ViewModels;
using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.ValueObjects;
using System.Linq;

namespace BnE.EducationVest.Application.Exams.Mappings
{
    public static class ExamMapperToViewModel
    {
        public static ExamViewModel MapToViewModel(this Exam exam) 
        {
            return new ExamViewModel()
            {
                Id = exam.Id,
                ExamNumber = exam.ExamNumber,
                ExamModel = exam.ExamModel,
                QuestionList = exam.Questions?.Select(x => x.MapToViewModel()).ToList(),
                Periods = exam.Periods?.Select(x => x.MapToViewModel()).ToList(),
                ExamType = exam.ExamType
            };
        }
        public static ExamPeriodViewModel MapToViewModel(this ExamPeriodVO examPeriod)
        {
            return new ExamPeriodViewModel()
            {
                OpenDate = examPeriod.OpenDate,
                CloseDate = examPeriod.CloseDate
            };
        }
        public static QuestionExamViewModel MapToViewModel(this Question question)
        {
            return new QuestionExamViewModel()
            {
                QuestionId = question.Id,
                Enunciated = question.Enunciated.MapToViewModel() ,
                Index = question.Index,
                Alternatives = question.Alternatives.Select(x => x.MapToViewModel()).ToList(),
                Answer = (question.QuestionAnswers != null && question.QuestionAnswers.Count > 0) 
                        ? question.QuestionAnswers.First().MapToViewModel() : null,
                SupportingText = question.SupportingText?.Content.MapToViewModel()
            };
        }
        public static QuestionAnswerViewModel MapToViewModel(this QuestionAnswer questionAnswer)
        {
            return new QuestionAnswerViewModel()
            {
                ChosenAlternativeId = questionAnswer.ChosenAlternativeId,
                AnswerId = questionAnswer.Id
            };
        }
        public static QuestionAlternativeViewModel MapToViewModel(this Alternative alternative)
        {
            return new QuestionAlternativeViewModel()
            {
                AlternativeId = alternative.Id,
                Text = alternative.TextContent.MapToViewModel(),
                IsCorrect = false,
                Index = alternative.Index
            };
        }
        public static QuestionTextViewModel MapToViewModel(this IncrementedTextVO incrementedText)
        {
            return new QuestionTextViewModel()
            {
                Content = incrementedText.Content,
                Increments = incrementedText.Increments?.Select(x => x.MapToViewModel()).ToList()
            };
        }

        public static IncrementViewModel MapToViewModel(this CompleteTextIncrementVO completeTextIncrementVO)
        {
            return new IncrementViewModel()
            {
                Index = completeTextIncrementVO.Index,
                Type = completeTextIncrementVO.Type,
                Value = completeTextIncrementVO.Value as string
            };
        }
    }
}
