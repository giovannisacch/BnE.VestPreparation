using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using BnE.EducationVest.Domain.Exam.Interfaces.InfraService;
using BnE.EducationVest.Infra.Service.Common.Models;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;

namespace BnE.EducationVest.Infra.Service.Exam
{
    public class ExamFileStorageService : IExamFileStorageService
    {
        private readonly RegionEndpoint _bucketRegion = RegionEndpoint.SAEast1;
        private IAmazonS3 _s3Client;
        private readonly IOptions<AWSAuth> _awsAuth;
        public ExamFileStorageService(IOptions<AWSAuth> awsAuth)
        {
            _awsAuth = awsAuth;
            _s3Client = new AmazonS3Client(_awsAuth.Value.AcessKey, _awsAuth.Value.SecretKey, _bucketRegion);
        }

        public async Task<string> UploadExamImage(byte[] fileContent, string keyName)
        {
            using (var stream = new MemoryStream(fileContent))
            {
                var request = new PutObjectRequest
                {
                    BucketName = _awsAuth.Value.BucketName,
                    InputStream = stream,
                    ContentType = "image/jpg",
                    Key = keyName
                };

                var response = await _s3Client.PutObjectAsync(request);
                if(response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    return $"https://{_awsAuth.Value.BucketName}.s3-sa-east-1.amazonaws.com/{keyName}";
                return null;
            }
        }
    }
}
