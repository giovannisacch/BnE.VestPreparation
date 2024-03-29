﻿using BnE.EducationVest.API.Utilities;
using BnE.EducationVest.Application.Exams.Interfaces;
using BnE.EducationVest.Application.Exams.Mappings;
using BnE.EducationVest.Application.Exams.ViewModels;
using BnE.EducationVest.Application.Exams.ViewModels.Request;
using BnE.EducationVest.Application.Exams.ViewModels.Response;
using BnE.EducationVest.Domain.Exam.Enums;
using BnE.EducationVest.Domain.Exam.Interfaces.InfraService;
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
        private readonly IExamReportService _examReportService;
        public ExamController(IExamApplicationService examApplicationService, IExamReportService examReportService)
        {
            _examApplicationService = examApplicationService;
            _examReportService = examReportService;
        }
        /// <summary>
        /// API Utilizada para definir os periodos do exame antes de fazer upload do arquivo da prova
        /// </summary>
        /// <param name="uploadExamPeriodsRequestViewModel"></param>
        /// <returns></returns>
        [HttpPost("periods")]
        public async Task<IActionResult> UploadExamPeriods(UploadExamPeriodsRequestViewModel uploadExamPeriodsRequestViewModel)
        {
            await _examApplicationService.UploadPreExam(uploadExamPeriodsRequestViewModel);
            return Ok();
        }
        //[HttpPost("")]
        //public async Task<IActionResult> CreateExam([FromQuery] EExamModel examModel, EExamType examType, int number, EExamTopic examTopic)
        //{
        //    var preExam = await _examApplicationService.GetPreExamVO(examModel, examType, number, examTopic);
            
        //}
        /// <summary>
        /// API Utilizada para subir o arquivo da prova
        /// </summary>
        /// <param name="examFile"></param>
        /// <param name="examModel"></param>
        /// <param name="examType"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpPost("upload")]
        public async Task<IActionResult> UploadExamFile(IFormFile examFile, [FromQuery]EExamModel examModel, EExamType examType, int number, EExamTopic examTopic)
        {
            var preExam = await _examApplicationService.GetPreExamVO(examModel, examType, number, examTopic);
            var viewModel = examFile.TransformExamWordFileInViewModel(preExam.Periods.Select(x => x.MapToViewModel()).ToList(), examModel, examType, number, examTopic, preExam.FatherExamModuleId);
            var response = await _examApplicationService.CreateExam(viewModel, preExam);
            return StatusCode((int)response.StatusCode,
                           response.IsSuccess
                           ? response.SuccessResponseModel
                           : response.ErrorResponseModel);
        }
        /// <summary>
        /// API que busca os exames que estão dísponiveis(estão com periodo vingente e não foram realizados) para o usuario que está logado
        /// </summary>
        /// <returns></returns>
        /// 
        [AllowAnonymous]
        [HttpGet("availables")]
        public async Task<IActionResult> GetAvailableExams()
        {
            var response = await _examApplicationService.GetAvailableExamsByUser();
            return StatusCode((int)response.StatusCode,
               response.IsSuccess
               ? response.SuccessResponseModel
               : response.ErrorResponseModel);
        }
        /// <summary>
        /// Busca todos os exames(usado apenas em backoffice para ver os exames em fase de desenvolvimento)
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> GetAllExams()
        {
            var response = await _examApplicationService.GetAllExams();
            return StatusCode((int)response.StatusCode,
               response.IsSuccess
               ? response.SuccessResponseModel
               : response.ErrorResponseModel);
        }

        /// <summary>
        /// Busca as questões de um exame, podendo trazer a resposta caso o usuario ja tenha respondido(busca resposta quando o parametro WasStarted é igual a true)
        /// Utiliza paginação começando da pagina 1
        /// </summary>
        /// <param name="getQuestionListPaginatedRequest"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("questions")]
        public async Task<IActionResult> GetExamQuestions([FromQuery]GetQuestionListPaginatedRequestViewModel getQuestionListPaginatedRequest)
        {
            var response = await _examApplicationService.GetQuestions(getQuestionListPaginatedRequest);
            return StatusCode((int)response.StatusCode,
              response.IsSuccess
              ? response.SuccessResponseModel
              : response.ErrorResponseModel);
        }
        /// <summary>
        /// Adiciona novos periodos em um exame já existente
        /// </summary>
        /// <param name="examId"></param>
        /// <param name="periodViewModel"></param>
        /// <returns></returns>
        [HttpPut("period")]
        public async Task<IActionResult> AddExamPeriod(Guid examId, List<ExamPeriodViewModel> periodViewModel)
        {
            var response = await _examApplicationService.AddExamPeriods(examId, periodViewModel);
            return StatusCode((int)response.StatusCode,
              response.IsSuccess
              ? response.SuccessResponseModel
              : response.ErrorResponseModel);
        }
        /// <summary>
        /// Adiciona resposta para uma questão
        /// </summary>
        /// <param name="answerQuestionResponse"></param>
        /// <returns></returns>
        ///
        [AllowAnonymous()]
        [HttpPost("answer")]
        public async Task<IActionResult> AnswerQuestion(AnswerQuestionRequestViewModel answerQuestionResponse)
        {
            var response = await _examApplicationService.AddExamQuestionAnswer(answerQuestionResponse);

            return StatusCode((int)response.StatusCode,
              response.IsSuccess
              ? new {answerId = response.SuccessResponseModel }
              : response.ErrorResponseModel);
        }
        /// <summary>
        /// Atualiza a alternativa escolhida para uma resposta
        /// </summary>
        /// <param name="updateAnswerQuestionResponse"></param>
        /// <returns></returns>
        [HttpPut("answer")]
        public async Task<IActionResult> UpdateAnswerQuestion(UpdateAnswerQuestionRequestViewModel updateAnswerQuestionResponse)
        {
            var response = await _examApplicationService.UpdateExamQuestionAnswer(updateAnswerQuestionResponse);

            return StatusCode((int)response.StatusCode,
              response.IsSuccess
              ? response.SuccessResponseModel
              : response.ErrorResponseModel);
        }

        /// <summary>
        /// Finaliza um exame
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("finalize")]
        public async Task<IActionResult> FinalizeExam(Guid examId)
        {
            await _examApplicationService.FinalizeExam(examId);

            return Ok();
        }

        /// <summary>
        /// Busca todos os tópicos disponiveis
        /// </summary>
        /// <returns></returns>
        [HttpGet("subjects")]
        public async Task<IActionResult> GetSubjects()
        {
            var response = await _examApplicationService.GetSubjects();

            return Ok(new {Subjects = response});
        }
        /// <summary>
        /// Busca todos os exames realizados pelo usuario logado
        /// </summary>
        /// <returns></returns>
        [HttpGet("realizeds")]
        public async Task<IActionResult> GetUserRealizedExams()
        {
            var response = await _examApplicationService.GetUserRealizedExamList();

            return Ok(response);
        }
        [HttpGet("filter")]
        public async Task<IActionResult> GetExamFilters()
        {
            return Ok(await _examApplicationService.GetReportFilters());
        }
        [HttpPost("generalScore")]
        public async Task<IActionResult> SetGeneralScore(Guid examId)
        {
            await _examApplicationService.SetExamComparation(examId);
            return Ok();
        }
        /// <summary>
        /// Busca todos os dados para a tela de relatorio de um exame especifico
        /// Caso seja chamado por um perfil de professor, necessita passar o student id como query parameter
        /// </summary>
        /// <returns></returns>
        [HttpGet("report/{id}")]
        public async Task<IActionResult> GetUserReports(Guid id, [FromQuery] Guid? studentId)
        {
            var response = await _examApplicationService.GetUserExamReport(id, studentId);

            return Ok(response);
        }
        /// <summary>
        /// Usado para remover as respostas de um usuario num exame especifico, usado apenas em dev, deve ser excluido em prd
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        [HttpDelete("answers/{examId}")]
        public async Task<IActionResult> DeleteUserAnswers(Guid examId)
        {
            await _examApplicationService.DeleteUserAnswers(examId);
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost("teste")]
        public async Task<IActionResult> Teste(string teste)
        {
            await _examReportService.ScheduleExamReport(teste);
            return Ok();
        }
        /// <summary>
        /// API utilizada para atualizar as métricas de comparação num exam
        /// Chamada pela função Lambd(AWS) call-updateReportMetrics
        /// </summary>
        /// <param name="examId"></param>
        /// <returns></returns>
        [HttpPut("examReport")]
        public async Task<IActionResult> UpdateGeneralExamReport(string examId)
        {
            return Ok();
        }
        /// <summary>
        /// Busca o evolucional de todos exames realizados pelo usuario logado
        /// </summary>
        /// <returns></returns>
        [HttpGet("evolutional")]
        public async Task<IActionResult> GetEvolutional()
        {
            return Ok(await _examApplicationService.GetEvolutional());
        }

        /// <summary>
        /// Informa o tempo gasto na questão
        /// </summary>
        /// <returns></returns>
        [HttpPost("secondsSpent-question")]
        public async Task<IActionResult> AddSecondsSpent(Guid questionId, long secondsSpent)
        {
            await _examApplicationService.AddSecondsSpent(questionId, secondsSpent);
            return Ok();
        }

        [HttpPost("resultByExcel")]
        public async Task<IActionResult> UploadResultsByExcel(Guid examId, IFormFile resultsSheet)
        {
            var response = await _examApplicationService.SaveExcelResultsToUserAnswers(examId, resultsSheet);
            return StatusCode((int)response.StatusCode,
                                  response.IsSuccess
                                  ? response.SuccessResponseModel
                                  : response.ErrorResponseModel);
        }
        [HttpGet("realizeds/filter")]
        public async Task<IActionResult> GetRealizedExamsByFilters([FromQuery]Guid? userId, int? examTopic, int? examModel, int? examNumber)
        {
            return Ok(await _examApplicationService.GetRealizedExamsByFilters(userId,examTopic,examModel,examNumber));
        }
        [HttpGet("create/filter")]
        public async Task<IActionResult> GetCreateExamFilters()
        {
            return Ok(await _examApplicationService.GetCreateExamFilters());
        }
    }
}
