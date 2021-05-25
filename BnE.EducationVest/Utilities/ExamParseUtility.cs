﻿using BnE.EducationVest.Application.Exams.ViewModels;
using BnE.EducationVest.Domain.Exam.Enums;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace BnE.EducationVest.API.Utilities
{
    public static class ExamParseUtility
    {
        private static Regex _regexRemoveWhitespace = new Regex(@"\s+");

         
        public static ExamViewModel TransformExamWordFileInViewModel(this IFormFile examWordFile) 
        {
            var exam = new ExamViewModel() {QuestionList = new List<QuestionExamViewModel>() };
            using (WordprocessingDocument myDocument = WordprocessingDocument.Open(examWordFile.OpenReadStream(), false))
            {
                var imagesStreamList = myDocument.GetAllImagesStream();
                var paragraphsWithContent = myDocument.MainDocumentPart.Document.Body
                                            .OfType<Paragraph>()
                                            .Where(paragraph => !string.IsNullOrEmpty(paragraph.InnerText) || paragraph.Count() > 1);

                QuestionExamViewModel actualQuestion = new QuestionExamViewModel();
                bool isInAlternatives = false;
                var imagesParagraphsCount = 0;
                var alternativeIndex = 0;
                foreach (var paragraph in paragraphsWithContent)
                {
                    var isImageParagraph = paragraph.Any(child =>
                                                            child.LastChild?.GetType() ==
                                                            typeof(DocumentFormat.OpenXml.Wordprocessing.Drawing)
                                                            );
                    var paragraphContent = paragraph.InnerText;
                    var contentWithoutWhiteSpaces = _regexRemoveWhitespace.Replace(paragraphContent, "");
                    if (contentWithoutWhiteSpaces == "-{Questao}")
                    {
                        exam.QuestionList.Add(actualQuestion);
                        var nextIndex = actualQuestion.Index + 1;
                        actualQuestion = new QuestionExamViewModel();
                        actualQuestion.Index = nextIndex;
                        isInAlternatives = false;
                    }
                    else if (contentWithoutWhiteSpaces == "-{Alternativas}")
                    {
                        actualQuestion.Alternatives = new List<QuestionAlternativeViewModel>();
                        isInAlternatives = true;
                        alternativeIndex = 0;
                    }
                    else if (isInAlternatives)
                    {
                        actualQuestion.Alternatives.Add(new
                          QuestionAlternativeViewModel()
                        {
                            Text = isImageParagraph ? null : GetQuestionTextByParagraph(paragraph,
                                                                                      imagesStreamList,
                                                                                      imagesParagraphsCount),
                            Index = alternativeIndex
                        });
                        alternativeIndex++;
                    }
                    else
                    {
                        if (actualQuestion.Enunciated == null)
                            AddEnunciatedToQuestion(actualQuestion, paragraph,
                                                imagesStreamList, imagesParagraphsCount);
                        else
                            IncrementActualEnunciated(actualQuestion, paragraph,
                                                imagesStreamList, imagesParagraphsCount);
                    }
                    if (isImageParagraph)
                        imagesParagraphsCount++;
                }
                exam.QuestionList.Add(actualQuestion);
            }
            return exam;
        }
        private static void AddEnunciatedToQuestion(QuestionExamViewModel actualQuestion,
                                                    Paragraph paragraph, List<Stream> imagesStreamList, int imagesParagraphsCount)
        {
            actualQuestion.Enunciated = GetQuestionTextByParagraph(paragraph,
                                                                   imagesStreamList,
                                                                   imagesParagraphsCount);
        }
        private static void IncrementActualEnunciated(QuestionExamViewModel actualQuestion,
                                                    Paragraph paragraph, List<Stream> imagesStreamList, int imagesParagraphsCount)
        {
            var paragraphAsQuestionText = GetQuestionTextByParagraph(paragraph,
                                                         imagesStreamList,
                                                         imagesParagraphsCount,
                                                      actualQuestion.Enunciated.Increments == null
                                                      ? 0 : actualQuestion.Enunciated.Increments.Last().Index + 1);
            actualQuestion.Enunciated.Content += Environment.NewLine;
            actualQuestion.Enunciated.Content += paragraphAsQuestionText.Content;
            if (paragraphAsQuestionText.Increments != null)
            {
                if (actualQuestion.Enunciated.Increments == null)
                    actualQuestion.Enunciated.Increments = paragraphAsQuestionText.Increments;
                else
                    actualQuestion.Enunciated.Increments.AddRange(paragraphAsQuestionText.Increments);
            }
        }

        private static QuestionTextViewModel GetQuestionTextByParagraph(Paragraph paragraph, List<Stream> imageStreamList,
                                                       int actualImageIndex, int initialIncrementIndex = 0)
        {
            var paragraphContent = new QuestionTextViewModel();
            var content = new StringBuilder();
            var incrementIndex = initialIncrementIndex;
            Type[] mathTypes =
            {
                typeof(DocumentFormat.OpenXml.Math.Paragraph),
                typeof(DocumentFormat.OpenXml.Math.OfficeMath)
            };
            foreach (var item in paragraph)
            {
                var isMath = mathTypes.Contains(item.GetType());
                var isImage = typeof(Drawing) == item.LastChild?.GetType();
                var isTextContent = typeof(Run) == item.GetType();
                if (isMath || isImage)
                {
                    if (paragraphContent.Increments == null)
                        paragraphContent.Increments = new List<IncrementViewModel>();
                    content.Append("{" + incrementIndex + "}");
                    paragraphContent.Increments.
                        Add(
                            new IncrementViewModel()
                            {
                                Index = incrementIndex,
                                Value = isMath ? GetMathMLFormat(item.OuterXml) : null,
                                ImageStream = isMath ? null : imageStreamList[actualImageIndex],
                                Type = isMath ? ECompleteTextIncrementType.Equation : ECompleteTextIncrementType.Image
                            });
                    incrementIndex++;
                }
                else
                    content.Append(item.InnerText);
            }
            paragraphContent.Content = content.ToString();
            return paragraphContent;
        }
        private static  string GetMathMLFormat(string officeMathXML)
        {
            XslCompiledTransform xslTransform = new XslCompiledTransform();
            xslTransform.Load(@".\utilities\libs\omml2mml.xsl");
            using (XmlReader reader = XmlReader.Create(new StringReader(officeMathXML)))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    XmlWriterSettings settings = xslTransform.OutputSettings.Clone();

                    // Configure xml writer to omit xml declaration.
                    settings.ConformanceLevel = ConformanceLevel.Fragment;
                    settings.OmitXmlDeclaration = true;

                    XmlWriter xw = XmlWriter.Create(ms, settings);

                    // Transform our OfficeMathML to MathML
                    xslTransform.Transform(reader, xw);
                    ms.Seek(0, SeekOrigin.Begin);

                    StreamReader sr = new StreamReader(ms, Encoding.UTF8);
                    string MathML = sr.ReadToEnd();
                    return MathML;
                }
            }
        }
        private static List<Stream> GetAllImagesStream(this WordprocessingDocument document)
        {
            var images = document.MainDocumentPart.ImageParts;
            var streamList = new List<Stream>();
            for (int index = 0; index < images.Count(); index++)
            {
                var image = images.ElementAt(index);
                var imageDocumentPart = image.OpenXmlPackage.Package.GetPart(image.Uri);
                streamList.Add(imageDocumentPart.GetStream());
            }
            return streamList;
        }
    }
}