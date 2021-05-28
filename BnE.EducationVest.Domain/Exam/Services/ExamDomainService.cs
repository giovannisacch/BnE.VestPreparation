﻿using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.Enums;
using BnE.EducationVest.Domain.Exam.Interfaces;
using BnE.EducationVest.Domain.Exam.Interfaces.Infra;
using BnE.EducationVest.Domain.Exam.Interfaces.InfraService;
using BnE.EducationVest.Domain.Exam.ValueObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Services
{
    public class ExamDomainService : IExamDomainService
    {
        private readonly IExamRepository _examRepository;
        private readonly IExamCacheService _examCacheService;
        private readonly IExamFileStorageService _examFileStorageService;
        public ExamDomainService(IExamCacheService examCacheService, IExamRepository examRepository,
                                 IExamFileStorageService examFileStorageService)
        {
            _examCacheService = examCacheService;
            _examRepository = examRepository;
            _examFileStorageService = examFileStorageService;
        }
        public async Task<List<Question>> GetExamQuestionsWithAnswers(Guid examId, Guid userId, int pageNumber, bool userAlreadyStarted)
        {
            var from = (pageNumber - 1) * 10;
            var to = (pageNumber) * 10;
            if (userAlreadyStarted)
                return await _examRepository.GetExamQuestions(examId, userId, from, to);

            var questionList = await _examCacheService.GetQuestionsByPageAsync(examId, pageNumber);
            if (questionList == null)
            {
                var exam = await _examRepository.GetExamWithPeriodsById(examId);
                questionList = await _examRepository.GetExamQuestions(examId, userId, from, to);
                await _examCacheService.SaveQuestionListByPage(exam, questionList, pageNumber);
            }

            return questionList;
        }
        public async Task AnswerExamQuestion(Guid examId, QuestionAnswer questionAnswer)
        {
            var questionList = await _examCacheService.GetQuestionsByPageAsync(examId, 1);
            var questionInQuestionList = questionList.FirstOrDefault(x => x.Id == questionAnswer.QuestionId);
            if (questionInQuestionList != null && questionInQuestionList.Index == 0)
            {
                var exam = await _examRepository.GetExamWithPeriodsById(examId);
                await _examCacheService.SaveUserStartedExam(questionAnswer.UserId, exam);
            }
            await _examRepository.AddExamQuestionAnswer(questionAnswer);
        }
        public async Task CreateExam(Entities.Exam exam)
        {
            foreach (var question in exam.Questions)
            {
                var imageNamePrefix = $"{Enum.GetName(typeof(EExamModel), exam.ExamModel)}/{Enum.GetName(typeof(EExamType), exam.ExamType)}/{exam.Id}/{question.Index}/";

                var questionEnunciatedImages = question.Enunciated.GetIncrementsWithImageType();
                if(questionEnunciatedImages != null)
                    questionEnunciatedImages.ToList().ForEach(async x => await UpdateIncrementImageContentToImageUrl(x, 
                                                                                                imageNamePrefix + $"enunciated/{question.Enunciated.Id}/{x.Index}"));
                var supportTextImages = question.SupportingText?.Content.GetIncrementsWithImageType();
                supportTextImages.ToList().ForEach(async x => await UpdateIncrementImageContentToImageUrl(x,
                                                                                                imageNamePrefix + $"supportText/{x.Index}"));
                if (supportTextImages != null)
                foreach (var alternative in question.Alternatives)
                {
                    var alternativeIncrementsWithImageType = alternative.TextContent.GetIncrementsWithImageType();
                    if (alternativeIncrementsWithImageType == null)
                        continue;
                        alternativeIncrementsWithImageType.ToList().ForEach(async x => await UpdateIncrementImageContentToImageUrl(x,
                                                                                                    imageNamePrefix + $"alternative/{alternative.Index}/{x.Index}"));
                    }
            }
        }

        public async Task UpdateIncrementImageContentToImageUrl(CompleteTextIncrementVO increment, string imageName)
        {
            var imageStream = increment.Value as byte[];
            var url = await _examFileStorageService.UploadExamImage(imageStream, imageName);
            increment.UpdateValueToImageUrl(url);
        }
    }
}
