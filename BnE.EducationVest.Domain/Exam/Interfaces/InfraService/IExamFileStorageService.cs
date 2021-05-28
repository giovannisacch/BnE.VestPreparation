using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Interfaces.InfraService
{
    public interface IExamFileStorageService
    {
        Task<string> UploadExamImage(byte[] fileContent, string keyName);
    }
}
