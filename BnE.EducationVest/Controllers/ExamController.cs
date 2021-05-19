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
            var response = await _examApplicationService.GetAvailableExamsByUser();
            return StatusCode((int)response.StatusCode,
               response.IsSuccess
               ? response.SuccessResponseModel
               : response.ErrorResponseModel);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllExams()
        {
            var response = await _examApplicationService.GetAllExams();
            return StatusCode((int)response.StatusCode,
               response.IsSuccess
               ? response.SuccessResponseModel
               : response.ErrorResponseModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAvailableExams(Guid id)
        {
            var response = await _examApplicationService.GetExam(id);
            return StatusCode((int)response.StatusCode,
              response.IsSuccess
              ? response.SuccessResponseModel
              : response.ErrorResponseModel);
        }

        [HttpPut("period")]
        public async Task<IActionResult> AddExamPeriod(Guid examId, List<ExamPeriodViewModel> periodViewModel)
        {
            var response = await _examApplicationService.AddExamPeriods(examId, periodViewModel);
            return StatusCode((int)response.StatusCode,
              response.IsSuccess
              ? response.SuccessResponseModel
              : response.ErrorResponseModel);
        }
    }
}
