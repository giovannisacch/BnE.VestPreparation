using BnE.EducationVest.API.Utilities;
using BnE.EducationVest.Application.Exams.Interfaces;
using BnE.EducationVest.Application.Exams.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BnE.EducationVest.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
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

        [HttpGet("availables")]
        public async Task<IActionResult> GetAvailableExams()
        {
            return Ok(await _examApplicationService.GetAvailableExamsByUser());
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllExams()
        {
            return Ok(await _examApplicationService.GetAllExams());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAvailableExams(Guid id)
        {
            return Ok(await _examApplicationService.GetExam(id));
        }

        [HttpPut("period")]
        public async Task<IActionResult> AddExamPeriod(Guid examId, List<ExamPeriodViewModel> periodViewModel)
        {
            await _examApplicationService.AddExamPeriods(examId, periodViewModel);
            return Ok();
        }
    }
}
