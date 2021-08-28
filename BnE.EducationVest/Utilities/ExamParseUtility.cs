using BnE.EducationVest.Application.Exams.ViewModels;
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
        private static XslCompiledTransform myXslTrans = new XslCompiledTransform();
        private static XsltSettings sets = new XsltSettings(true, true);
        private static XmlUrlResolver resolver = new XmlUrlResolver();
        private static XslCompiledTransform xslTransform = new XslCompiledTransform();

        public static ExamViewModel TransformExamWordFileInViewModel(this IFormFile examWordFile, List<ExamPeriodViewModel> periods, 
                                                                    EExamModel examModel, EExamType examType, int number, 
                                                                    EExamTopic examTopic,
                                                                    Guid? examFatherId) 
        {
            var exam = new ExamViewModel() {ExamModel = examModel, ExamType = examType, ExamNumber = number, Periods = periods, 
                                            QuestionList = new List<QuestionExamViewModel>(), ExamTopic = examTopic, ExamFatherId = examFatherId};
            using (WordprocessingDocument myDocument = WordprocessingDocument.Open(examWordFile.OpenReadStream(), false))
            {
                var paragraphsWithContent = myDocument.MainDocumentPart.Document.Body
                                            .OfType<Paragraph>()
                                            .Where(paragraph => !string.IsNullOrEmpty(paragraph.InnerText) || paragraph.Count() > 1);

                QuestionExamViewModel actualQuestion = new QuestionExamViewModel();
                var supportingTexts = new List<QuestionSupportingTextRequestViewModel>();
                bool isInAlternatives = false;
                var alternativeIndex = 0;
                var isInSupportingText = false;
                var isInAnswerKey = false;
                var actualSupportingText = new QuestionSupportingTextRequestViewModel();
                foreach (var paragraph in paragraphsWithContent)
                {
                    var isImageParagraph = paragraph.Any(child =>
                                                            child.LastChild?.GetType() ==
                                                            typeof(DocumentFormat.OpenXml.Wordprocessing.Drawing)
                                                            );
                    byte[] actualImageByteArray = null;
                    if (isImageParagraph)
                    {
                        var drawing = (Drawing)paragraph.First(child => child.LastChild.GetType() == typeof(DocumentFormat.OpenXml.Wordprocessing.Drawing)).LastChild;
                        var inline = drawing.Inline;
                        if (inline == null)
                            continue;
                        var pic = inline.Graphic.GraphicData.GetFirstChild<DocumentFormat.OpenXml.Drawing.Pictures.Picture>();
                        var embed = pic.BlipFill.Blip.Embed.Value;

                        // Get image flow
                        var part = myDocument.MainDocumentPart.GetPartById(embed);
                        
                        var stream = part.OpenXmlPackage.Package.GetPart(part.Uri).GetStream();

                        actualImageByteArray = ConvertStreamToByteArray(stream);
                    }
                    var paragraphContent = paragraph.InnerText;
                    var contentWithoutWhiteSpaces = _regexRemoveWhitespace.Replace(paragraphContent, "");
                    if (contentWithoutWhiteSpaces == "-{TextoApoio}")
                    {
                        if (actualSupportingText.Questions != null)
                            supportingTexts.Add(actualSupportingText);
                        actualSupportingText = new QuestionSupportingTextRequestViewModel();
                        isInSupportingText = true;
                        isInAlternatives = false;
                    }
                    else if (contentWithoutWhiteSpaces == "-{Questao}")
                    {
                        exam.QuestionList.Add(actualQuestion);
                        var nextIndex = actualQuestion.Index + 1;
                        actualQuestion = new QuestionExamViewModel();
                        actualQuestion.Index = nextIndex;
                        isInAlternatives = false;
                        isInSupportingText = false;
                    }
                    else if (contentWithoutWhiteSpaces == "-{Alternativas}")
                    {
                        actualQuestion.Alternatives = new List<QuestionAlternativeViewModel>();
                        isInAlternatives = true;
                        alternativeIndex = 0;
                    }
                    else if(contentWithoutWhiteSpaces == "-{Gabarito}")
                    {
                        exam.QuestionList.Add(actualQuestion);
                        isInAnswerKey = true;
                    }
                    else if(isInAnswerKey)
                    {
                        //Modelo esperado do paragrafo: 1 E 
                        var alternativeAnswer = paragraphContent.TrimStart().ToUpper().Split(' ');
                        var correctAlternativeIndex = 0;
                        switch (alternativeAnswer[1])
                        {
                            case "A":
                                correctAlternativeIndex = 0;
                                break;
                            case "B":
                                correctAlternativeIndex = 1;
                                break;
                            case "C":
                                correctAlternativeIndex = 2;
                                break;
                            case "D":
                                correctAlternativeIndex = 3;
                                break;
                            case "E":
                                correctAlternativeIndex = 4;
                                break;
                            default:
                                throw new Exception("Verificar gabarito, não foi encontrada alterrnativa: " + paragraphContent.TrimStart());
                        }
                        try
                        {
                            exam.QuestionList.First(x => x.Index == int.Parse(alternativeAnswer[0])).Alternatives[correctAlternativeIndex].IsCorrect = true;

                        }
                        catch (Exception ex)
                        {

                            throw;
                        }
                    }
                    else if (isInAlternatives)
                    {
                        var textContent = GetQuestionTextByParagraph(paragraph,actualImageByteArray);
                        var textLastCharIndex = textContent.Content.Length - 1;
                        if (string.IsNullOrEmpty(textContent.Content))
                            continue;

                        actualQuestion.Alternatives.Add(new
                          QuestionAlternativeViewModel()
                        {
                            Text = textContent,
                            Index = alternativeIndex
                        });
                        alternativeIndex++;
                    }
                    else if (isInSupportingText)
                    {
                        var splitedQuestions = paragraphContent.Split("Questoes:");
                        if(splitedQuestions.Length > 1)
                        {
                            var questionNumbersDividedByComma = splitedQuestions[1];
                            actualSupportingText.Questions = questionNumbersDividedByComma.Split(',').Select(x => int.Parse(x));
                        }
                        else
                        {
                            if (actualSupportingText.Text == null)
                                SetSupportingTextContent(actualSupportingText, paragraph,
                                                    actualImageByteArray);
                            else
                                UpdateSupportingTextContent(actualSupportingText, paragraph,
                                                    actualImageByteArray);
                        }
                    }
                    else
                            {
                        if (actualQuestion.Enunciated == null)
                            AddEnunciatedToQuestion(actualQuestion, paragraph,
                                                actualImageByteArray);
                        else
                            IncrementActualEnunciated(actualQuestion, paragraph,
                                                actualImageByteArray);
                    }
                }
                if(actualSupportingText?.Text != null)
                    supportingTexts.Add(actualSupportingText);

                foreach (var supportText in supportingTexts)
                {
                    exam.QuestionList.Where(x => supportText.Questions.Contains(x.Index)).ToList().ForEach(question => question.SupportingText = supportText.Text);
                }
            }
            exam.QuestionList.RemoveAll(x => x.Alternatives == null);
            return exam;
        }
        private static void AddEnunciatedToQuestion(QuestionExamViewModel actualQuestion,
                                                    Paragraph paragraph, byte[] imageByteArray)
        {
            actualQuestion.Enunciated = GetQuestionTextByParagraph(paragraph,
                                                                   imageByteArray);
        }
        private static void IncrementActualEnunciated(QuestionExamViewModel actualQuestion,
                                                    Paragraph paragraph, byte[] imageByteArray)
        {
            var paragraphAsQuestionText = GetQuestionTextByParagraph(paragraph,
                                                         imageByteArray,
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

        private static void SetSupportingTextContent(QuestionSupportingTextRequestViewModel actualSupportingText,
                                            Paragraph paragraph, byte[] imageByteArray)
        {
            actualSupportingText.Text = GetQuestionTextByParagraph(paragraph,
                                                                   imageByteArray);
        }
        private static void UpdateSupportingTextContent(QuestionSupportingTextRequestViewModel actualSupportingText,
                                                    Paragraph paragraph, byte[] imageByteArray)
        {
            var paragraphAsQuestionText = GetQuestionTextByParagraph(paragraph,
                                                         imageByteArray,
                                                      actualSupportingText.Text.Increments == null
                                                      ? 0 : actualSupportingText.Text.Increments.Last().Index + 1);
            actualSupportingText.Text.Content += Environment.NewLine;
            actualSupportingText.Text.Content += paragraphAsQuestionText.Content;
            if (paragraphAsQuestionText.Increments != null)
            {
                if (actualSupportingText.Text.Increments == null)
                    actualSupportingText.Text.Increments = paragraphAsQuestionText.Increments;
                else
                    actualSupportingText.Text.Increments.AddRange(paragraphAsQuestionText.Increments);
            }
        }

        private static QuestionTextViewModel GetQuestionTextByParagraph(Paragraph paragraph, byte[] image, int initialIncrementIndex = 0)
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
                                Value = isMath ? GetTexFromMathML(GetMathMLFormat(item.OuterXml)) : null,
                                ImageStream = isMath ? null : image,
                                Type = isMath ? ECompleteTextIncrementType.Equation : ECompleteTextIncrementType.Image
                            }
                       );
                    incrementIndex++;

                }
                else
                {
                    content.Append(item.InnerText);
                }
                    
            }
            
            paragraphContent.Content = content.ToString().Trim();
            paragraphContent.Content = RemoveAlternativePrefix(paragraphContent.Content);
            paragraphContent.Increments?.ForEach(x => x.Value = RemoveAlternativePrefix(x.Value));

            return paragraphContent;
        }
        private static string RemoveAlternativePrefix(string content)
        {
            string[] alternativesPrefix = { "A)", "B)", "C)", "D)", "E)" };
            if ( !string.IsNullOrEmpty(content) && content.Length >= 2 && alternativesPrefix.Contains(content.Substring(0, 2)))
                content = content.Remove(0, 2);
            return content;
        }
        private static string GetTexFromMathML(string officeMathXml) 
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(officeMathXml)))
            {
                StringBuilder content = new StringBuilder();

                var xw = new StringWriter(content);
                if(myXslTrans.OutputSettings == null);
                    myXslTrans.Load(@".\utilities\libs\mmltex.xsl", sets, resolver);

                // Transform our OfficeMathML to MathML
                myXslTrans.Transform(reader, null, xw);
                string MathML = content.ToString();
                return MathML;

            }
        }
        private static  string GetMathMLFormat(string officeMathXML)
        {
            if (xslTransform.OutputSettings == null)
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
        public static byte[] ConvertStreamToByteArray(Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
