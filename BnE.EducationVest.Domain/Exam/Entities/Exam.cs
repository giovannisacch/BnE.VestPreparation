using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Exam.Enums;
using BnE.EducationVest.Domain.Exam.RelationEntities;
using BnE.EducationVest.Domain.Exam.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BnE.EducationVest.Domain.Exam.Entities
{
    public class Exam : EntityBase
    {
        public int ExamNumber { get; set; }
        public Guid? FatherExamModuleId { get; private set; }
        public EExamModel ExamModel { get; private set; }
        public EExamType ExamType { get; private set; }
        public EExamTopic ExamTopic { get; private set; }
        public List<ExamPeriodVO> Periods { get; private set; }
        public List<Question> Questions { get; private set; }
        public List<FinalizedExam> Finalizeds { get; private set; }
        public List<Exam> ChildExamModule { get; private set; }
        public Exam FatherExamModule { get; private set; }
        public List<GeneralMetric> GeneralMetrics { get; private set; }

        internal Exam() { }
        public Exam(int examNumber, EExamModel examModel, List<ExamPeriodVO> periods, List<Question> questions, EExamType examType, EExamTopic examTopic)
        {
            ExamNumber = examNumber;
            ExamModel = examModel;
            SetExamPeriods(periods);
            SetQuestionsList(questions);
            ExamType = examType;
            ExamTopic = examTopic;
        }
        public void SetFatherExamModule(Guid fatherExamModuleId)
        {
            FatherExamModuleId = fatherExamModuleId;
        }
        public int GetPortugueseQuestionCount()
        {
            return Questions.Count(x => x.Subject.IsPortugueseTopic());
        }
        public int GetMathQuestionCount()
        {
            return Questions.Count(x => x.Subject.IsMathTopic());
        }
        public ExamPeriodVO GetActualAvailablePeriod()
        {
            return Periods
                .FirstOrDefault(x => x.OpenDate <= DateTime.Now && x.CloseDate > DateTime.Now.AddMinutes(10));
        }
        public IEnumerable<Question> GetQuestionsWithImageInEnunciated()
        {
            return Questions.Where(x => x.HasImageInEnunciated());
        }
        public bool IsAvailable()
        {
            return GetActualAvailablePeriod() != null;
        }
        public bool UserHasFinalized(Guid userId)
        {
            return Finalizeds.Any(x => x.UserId == userId);
        }
        public void SetQuestionsList(List<Question> questions)
        {
            //TODO: Externalizar para "Factory" por tipo de prova - quantidad e msg de erro
            //var insperQuestionsCount = 50;
            //if (ExamModel == EExamModel.Insper && questions.Count != insperQuestionsCount)
            //    throw new DomainErrorException($"ExamType_Does_not_expect_{questions.Count}_questions");
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
