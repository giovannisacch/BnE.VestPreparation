using System.ComponentModel;

namespace BnE.EducationVest.Domain.Exam.Enums
{
    public enum EQuestionDifficulty
    {
        [Description("Calculando...")]
        Calculating,
        [Description("Fácil")]
        Easy,
        [Description("Médio")]
        Medium,
        [Description("Difícil")]
        Hard
    }
}
