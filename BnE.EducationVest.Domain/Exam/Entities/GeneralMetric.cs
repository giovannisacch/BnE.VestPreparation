using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Exam.ValueObjects;
using System;

namespace BnE.EducationVest.Domain.Exam.Entities
{
    public class GeneralMetric : EntityBase
    {
        public GeneralMetric(Guid examId, ExamGeneralMetrics examMetric)
        {
            ExamId = examId;
            MetricValue = examMetric;
        }
        internal GeneralMetric() { }
        public Guid ExamId { get; set; }
        public Exam Exam { get; private set; }
        public ExamGeneralMetrics MetricValue { get; private set; }
    }
}
