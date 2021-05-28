using BnE.EducationVest.Domain.Exam.Enums;

namespace BnE.EducationVest.Domain.Exam.ValueObjects
{
    //TODO: ATUALIZAR, NAO É UM VALUE OBJECT
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
        public void UpdateValueToImageUrl(string imageUrl)
        {
            if (Type == ECompleteTextIncrementType.Equation)
                throw new System.Exception();

            Value = imageUrl;
        }
    }
}
