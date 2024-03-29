﻿using BnE.EducationVest.Application.Exams.ViewModels;
using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.Enums;
using BnE.EducationVest.Domain.Exam.ValueObjects;
using System;
using System.Collections.Generic;
using System.IO;
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
                             examViewModel.ExamType, examViewModel.ExamTopic
                             );
            if(examViewModel.ExamFatherId != null)
                exam.SetFatherExamModule(examViewModel.ExamFatherId.Value);
            return exam;
        }

        public static ExamPeriodVO MapToVO(this ExamPeriodViewModel examPeriodViewModel)
        {
            return new ExamPeriodVO(examPeriodViewModel.OpenDate, examPeriodViewModel.CloseDate );
        }

        public static Question MapToDomain(this QuestionExamViewModel questionViewModel)
        {
            var question = new Question(questionViewModel.Index, 
                                questionViewModel.Enunciated.MapToVO(), 
                                questionViewModel.Alternatives.Select(x => x.MapToDomain()).ToList(),
                                questionViewModel.SubjectId);
            if (questionViewModel.SupportingText != null)
                question.SetSupportingText(questionViewModel.SupportingText.MapToSupportText());
            return question;
        }
        
        public static Alternative MapToDomain(this QuestionAlternativeViewModel questionAlternativeViewModel)
        {
            return new Alternative( questionAlternativeViewModel.Text.MapToVO(), 
                                    questionAlternativeViewModel.IsCorrect, 
                                    questionAlternativeViewModel.Index);
        }
        public static SupportingText MapToSupportText(this QuestionTextViewModel questionTextViewModel)
        {
            return new SupportingText(questionTextViewModel.MapToVO());
        }
        public static IncrementedTextVO MapToVO(this QuestionTextViewModel questionTextViewModel)
        {
            return new IncrementedTextVO(questionTextViewModel.Content, 
                                    questionTextViewModel.Increments?.Select(x => x.MapToVO()).ToList());
        }

        public static CompleteTextIncrementVO MapToVO(this IncrementViewModel incrementViewModel)
        {
            return new CompleteTextIncrementVO(incrementViewModel.Index,
                                            (
                                                (incrementViewModel.Type == ECompleteTextIncrementType.Equation) ?
                                                                                        incrementViewModel.Value :
                                                                                        (incrementViewModel.ImageStream)
                                             ),
                                            incrementViewModel.Type);
        }
        //private static byte[] TransformStreamInByteArray(Stream sourceStream) 
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        sourceStream.CopyTo(memoryStream);
        //        return memoryStream.ToArray();
        //    }
        //}
    }
}
