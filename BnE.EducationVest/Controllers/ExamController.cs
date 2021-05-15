using BnE.EducationVest.API.Utilities;
using BnE.EducationVest.Application.Exams.Interfaces;
using BnE.EducationVest.Application.Exams.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BnE.EducationVest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamApplicationService _examApplicationService;
        public ExamController(IExamApplicationService examApplicationService)
        {
            _examApplicationService = examApplicationService;
        }


        [HttpPost("Doc")]
        public async Task<IActionResult> UploadExamFile(IFormFile examFile)
        {
            var viewModel = examFile.TransformExamWordFileInViewModel();
            await _examApplicationService.CreateExam(viewModel);

            return Ok();
        }
    }
}
