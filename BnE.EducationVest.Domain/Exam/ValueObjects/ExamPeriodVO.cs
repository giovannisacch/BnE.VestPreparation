using BnE.EducationVest.Domain.Common;
using System;

namespace BnE.EducationVest.Domain.Exam.ValueObjects
{
    public class ExamPeriodVO
    {
        public Guid Id { get; private set; }
        public DateTime OpenDate { get; private set; }
        public DateTime CloseDate { get; private set; }
        public Guid ExamId { get; private set; }
        public Entities.Exam Exam { get; private set; }

        internal ExamPeriodVO()
        {

        }
        public ExamPeriodVO(DateTime openDate, DateTime closeDate)
        {
            Id = Guid.NewGuid();
            if (openDate > closeDate)
                throw new DomainErrorException(ErrorConstants.PERIOD_OPENDATE_SHOULD_BE_EARLIER_THAN_CLOSEDATE);
            OpenDate = openDate;
            CloseDate = closeDate;
        }
        public override string ToString()
        {
            return $"De {OpenDate:dd/MM/yyyy hh:mm} até {CloseDate:dd/MM/yyyy hh:mm}";
        }
        public override bool Equals(object obj)
        {
            var objParsed = obj as ExamPeriodVO;
            return OpenDate.Equals(objParsed.OpenDate) 
                && CloseDate.Equals(objParsed.CloseDate);
        }
    }
}
