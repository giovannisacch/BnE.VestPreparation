using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Exam.Enums;
using BnE.EducationVest.Domain.Exam.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Entities
{
    public class Exam : EntityBase
    {
        public int ExamNumber { get; set; }
        public EExamType ExamType { get; private set; }
        public List<ExamPeriodVO> Periods { get; private set; }
        public List<Question> Questions { get; private set; }

        public Exam(EExamType examType, List<ExamPeriodVO> periods)
        {
            ExamType = examType;
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
