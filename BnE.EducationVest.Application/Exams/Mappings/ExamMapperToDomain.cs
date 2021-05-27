using BnE.EducationVest.Application.Exams.ViewModels;
using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.Enums;
using BnE.EducationVest.Domain.Exam.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.Mappings
{
    public static class ExamMapperToDomain
    {
        public static Exam MapToDomain(this ExamViewModel examViewModel)
        {
            var exam = new Exam(examViewModel.ExamNumber, examViewModel.ExamModel,
                             examViewModel.Periods.Select(x => x.MapToVO()).ToList(),
                             examViewModel.QuestionList.Select(x => x.MapToDomain()).ToList(),
                             examViewModel.ExamType
                             );
            return exam;
        }

        public static ExamPeriodVO MapToVO(this ExamPeriodViewModel examPeriodViewModel)
        {
            return new ExamPeriodVO(examPeriodViewModel.OpenDate, examPeriodViewModel.CloseDate );
        }

        public static Question MapToDomain(this QuestionExamViewModel questionViewModel)
        {
            return new Question(questionViewModel.Index, 
                                questionViewModel.Enunciated.MapToVO(), 
                                questionViewModel.Alternatives.Select(x => x.MapToDomain()).ToList(),
                                questionViewModel.SubjectId);
        }
        
        public static Alternative MapToDomain(this QuestionAlternativeViewModel questionAlternativeViewModel)
        {
            return new Alternative( questionAlternativeViewModel.Text.MapToVO(), 
                                    questionAlternativeViewModel.IsCorrect, 
                                    questionAlternativeViewModel.Index);
        }

        public static IncrementedTextVO MapToVO(this QuestionTextViewModel questionTextViewModel)
        {
            return new IncrementedTextVO(questionTextViewModel.Content, 
                                    questionTextViewModel.Increments.Select(x => x.MapToVO()).ToList());
        }

        public static CompleteTextIncrementVO MapToVO(this IncrementViewModel incrementViewModel)
        {
            return new CompleteTextIncrementVO(incrementViewModel.Index,
                                            (
                                                (incrementViewModel.Type == ECompleteTextIncrementType.Equation) ?
                                                                                        incrementViewModel.Value :
                                                                                        incrementViewModel.ImageStream
                                             ),
                                            incrementViewModel.Type);
        }
    }
}
