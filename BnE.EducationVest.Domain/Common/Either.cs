using System.Net;

namespace BnE.EducationVest.Domain.Common
{
    public class Either<Err, Sucess>
    {
        public ErrorResponseModel ErrorResponseModel { get; private set; }
        public Sucess SuccessResponseModel { get; private set; }
        public bool IsSuccess { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }

        public Either(ErrorResponseModel error, HttpStatusCode statusCode)
        {
            ErrorResponseModel = error;
            StatusCode = statusCode;
            this.IsSuccess = false;
        }

        public Either(Sucess successResponseModel, HttpStatusCode statusCode)
        {
            this.SuccessResponseModel = successResponseModel;
            StatusCode = statusCode;
            this.IsSuccess = true;
        }
    }
}
