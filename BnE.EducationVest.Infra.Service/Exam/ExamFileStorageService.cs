using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using BnE.EducationVest.Domain.Exam.Interfaces.InfraService;
using System.IO;
using System.Threading.Tasks;

namespace BnE.EducationVest.Infra.Service.Exam
{
    public class ExamFileStorageService : IExamFileStorageService
    {
        private readonly RegionEndpoint _bucketRegion = RegionEndpoint.SAEast1;
        private IAmazonS3 _s3Client;
        public ExamFileStorageService()
        {
            _s3Client = new AmazonS3Client("AKIAWOALMJU6CKZG6LU3", "N0YPZzRATQ3TS5xSDTkc2dBOwoJ858kp5xtjU9Od", _bucketRegion);
        }

        public async Task<string> UploadExamImage(byte[] fileContent, string keyName)
        {
            using (var stream = new MemoryStream(fileContent))
            {
                var request = new PutObjectRequest
                {
                    BucketName = "dev-reports-images",
                    InputStream = stream,
                    ContentType = "image/jpg",
                    Key = keyName
                };

                var response = await _s3Client.PutObjectAsync(request);
                if(response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    return $"https://dev-reports-images.s3-sa-east-1.amazonaws.com/{keyName}";
                return null;
            }
        }
    }
}
