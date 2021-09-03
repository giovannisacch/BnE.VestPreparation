namespace BnE.EducationVest.Infra.Service.Common.Models
{
    public class AWSAuth
    {
        public string Region { get; set; }
        public string AcessKey { get; set; }
        public string SecretKey { get; set; }
        public string UserPoolClientId { get; set; }
        public string UserPoolId { get; set; }
        public string CognitoAuthority { get; set; }
        public string BucketName { get; set; }
    }
}
