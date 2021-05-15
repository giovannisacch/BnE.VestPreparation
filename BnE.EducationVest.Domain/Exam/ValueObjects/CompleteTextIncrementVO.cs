using BnE.EducationVest.Domain.Exam.Enums;

namespace BnE.EducationVest.Domain.Exam.ValueObjects
{
    public class CompleteTextIncrementVO
    {
        public int Index { get; private set; }
        public object Value { get; private set; }
        public ECompleteTextIncrementType Type { get; private set; }

        public CompleteTextIncrementVO(int index, object value, ECompleteTextIncrementType type)
        {
            Index = index;
            Value = value;
            Type = type;
        }
    }
}
