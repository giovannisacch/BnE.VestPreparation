using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.ValueObjects
{
    public class ExamPeriodVO
    {
        public DateTime OpenDate { get; private set; }
        public DateTime CloseDate { get; private set; }

        public ExamPeriodVO(DateTime openDate, DateTime closeDate)
        {
            OpenDate = openDate;
            CloseDate = closeDate;
        }
        public override string ToString()
        {
            return $"De {OpenDate:dd/MM/yyyy hh:mm} até {CloseDate:dd/MM/yyyy hh:mm}";
        }
        public override bool Equals(object obj)
        {
            return OpenDate.Equals(obj.GetType().GetProperty("OpenDate")) 
                && CloseDate.Equals(obj.GetType().GetProperty("CloseDate"));
        }
    }
}
