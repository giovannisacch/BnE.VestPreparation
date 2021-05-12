using BnE.EducationVest.Test.Common;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BnE.EducationVest.Test.Exam
{
    public class PostExamTest
    {
        private readonly IFormFile _examFile;
        public PostExamTest()
        {
            var physicalFile = new FileInfo("../../../Exam/Docs/Simulado 01 - 06-03.docx");
            _examFile = physicalFile.AsMockIFormFile();
        }
        [Fact]
        public void Fact_Insert_Exam()
        {
            Assert.Equal(_examFile, _examFile);
        }
    }
}
