using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Exam.Enums;
using BnE.EducationVest.Domain.Exam.ValueObjects;
using System;
using System.Collections.Generic;

namespace BnE.EducationVest.Domain.Exam.Entities
{
    public class Exam : EntityBase
    {
        public int ExamNumber { get; set; }
        public EExamType ExamType { get; private set; }
        public List<ExamPeriodVO> Periods { get; private set; }
        public List<Question> Questions { get; private set; }

        internal Exam() { }
        public Exam(int examNumber, EExamType examType, List<ExamPeriodVO> periods, List<Question> questions)
        {
            ExamNumber = examNumber;
            ExamType = examType;
            SetExamPeriods(periods);
            SetQuestionsList(questions);
        }

        public void SetQuestionsList(List<Question> questions)
        {
            //TODO: Externalizar para "Factory" por tipo de prova - quantidad e msg de erro
            var insperQuestionsCount = 50;
            if (ExamType == EExamType.Insper && questions.Count != insperQuestionsCount)
                throw new DomainErrorException($"ExamType_Does_not_expect_{questions.Count}_questions");
            Questions = questions;

        }
        public void SetExamPeriods(List<ExamPeriodVO> periods)
        {
            if (periods == null || periods.Count < 1)
                throw new DomainErrorException(ErrorConstants.EMPTY_EXAM_PERIODS);
            Periods = periods;
        }
        public void AddPeriod(DateTime openDate, DateTime closeDate)
        {
            if (Periods == null)
                Periods = new List<ExamPeriodVO>();
            Periods.Add(new ExamPeriodVO(openDate, closeDate));
        }

        public void AddQuestion(Question question)
        {
            if (Questions == null)
                Questions = new List<Question>();
            Questions.Add(question);
        }

        public override bool Equals(object obj)
        {
            var typedObj = (Exam)obj;
            return Id == typedObj.Id;
        }
    }
}
