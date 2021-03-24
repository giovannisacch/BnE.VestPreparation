namespace BnE.EducationVest.Domain.Common
{
    public class ErrorResponseModel
    {
        public ErrorResponseModel(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
