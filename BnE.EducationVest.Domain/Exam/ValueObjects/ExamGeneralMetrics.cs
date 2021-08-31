using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.ValueObjects
{
    public class ExamGeneralMetrics
    {
        public double TotalScoreAverage { get; set; }
        public double PortugueseAverage { get; set; }
        public double MathAverage { get; set; }
        public List<Guid> UserIdListOrdered { get; set; }
        public List<QuestionDifficulty> QuestionDifficulties { get; set; }
    }
    public class QuestionDifficulty
    {
        public Guid QuestionId { get; set; }
        public int Difficulty { get; set; }
    }
}
