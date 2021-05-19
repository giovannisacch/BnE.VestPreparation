using BnE.EducationVest.Domain.Exam.Entities;
using BnE.EducationVest.Domain.Exam.Enums;
using BnE.EducationVest.Domain.Exam.ValueObjects;
using BnE.EducationVest.Domain.Users.Entities;
using BnE.EducationVest.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Infra.Data.Exams
{
    public static class ExamSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var firstPeriod = DateTime.Now.Date.AddDays(4).AddHours(10);
            var mathSubject = new Subject("Matemática");
            var portSubject = new Subject("Português");
            var percentageSubject = new Subject("Porcentagem");
            percentageSubject.SetSubjectFather(mathSubject.Id);
            //Apartar regions em metodos
            #region QuestionEnunciateds
            var questionsEnunciatedsQuiz = new List<IncrementedTextVO>()
            {
                new IncrementedTextVO(
                    "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente",
                    new List<CompleteTextIncrementVO>(){
                        new CompleteTextIncrementVO(
                            0,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            1,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            2,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>",
                            ECompleteTextIncrementType.Equation
                            )
                }),
                new IncrementedTextVO("Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número",
                 new List<CompleteTextIncrementVO>(){
                        new CompleteTextIncrementVO(
                            0,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            1,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            2,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            3,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            4,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>",
                            ECompleteTextIncrementType.Equation
                            )
                    }
                ),
                new IncrementedTextVO("Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ",
                                        null),
                new IncrementedTextVO("Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a",
                new List<CompleteTextIncrementVO>(){
                        new CompleteTextIncrementVO(
                            0,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:mi>θ</mml:mi></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            1,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            2,
                            "https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png",
                            ECompleteTextIncrementType.Image
                            ),
                        new CompleteTextIncrementVO(
                            3,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            4,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>",
                            ECompleteTextIncrementType.Equation
                            )
                    }
                )
            };

            var questionsEnunciatedsFGV = new List<IncrementedTextVO>()
            {
                new IncrementedTextVO(
                    "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente",
                    new List<CompleteTextIncrementVO>(){
                        new CompleteTextIncrementVO(
                            0,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            1,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            2,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>",
                            ECompleteTextIncrementType.Equation
                            )
                }),
                new IncrementedTextVO("Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número",
                 new List<CompleteTextIncrementVO>(){
                        new CompleteTextIncrementVO(
                            0,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            1,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            2,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            3,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            4,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>",
                            ECompleteTextIncrementType.Equation
                            )
                    }
                ),
                new IncrementedTextVO("Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ",
                                        null),
                new IncrementedTextVO("Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a",
                new List<CompleteTextIncrementVO>(){
                        new CompleteTextIncrementVO(
                            0,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:mi>θ</mml:mi></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            1,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            2,
                            "https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png",
                            ECompleteTextIncrementType.Image
                            ),
                        new CompleteTextIncrementVO(
                            3,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            4,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>",
                            ECompleteTextIncrementType.Equation
                            )
                    }
                )
            };

            var questionsEnunciatedsFGVPast = new List<IncrementedTextVO>()
            {
                new IncrementedTextVO(
                    "No país das comunicações, cuja população é x (em milhões de habitantes), uma notícia de interesse nacional foi divulgada e, t horas após a divulgação, o número de pessoas que tomaram conhecimento da notícia é dado por  f(t) = {0}Considere: {1}5{2}2,32 Sabendo que, uma hora pós a divulgação, a metade da população já tinha conhecimento da notícia, é correto afirmar que a população desse país, em milhões de habitantes, é, aproximadamente",
                    new List<CompleteTextIncrementVO>(){
                        new CompleteTextIncrementVO(
                            0,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:mfrac><mml:mrow><mml:mi>x</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn><mml:mo>+</mml:mo><mml:msup><mml:mrow><mml:mn>5</mml:mn><mml:mi> </mml:mi><mml:mo>∙</mml:mo><mml:mi> </mml:mi><mml:mn>2</mml:mn><mml:mi> </mml:mi></mml:mrow><mml:mrow><mml:mfrac><mml:mrow><mml:mo>-</mml:mo><mml:mi> </mml:mi><mml:mi>x</mml:mi><mml:mi> </mml:mi><mml:mo>.</mml:mo><mml:mi> </mml:mi><mml:mi>t</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:mrow></mml:msup><mml:mi> </mml:mi></mml:mrow></mml:mfrac></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            1,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:msub><mml:mrow><mml:mi>L</mml:mi><mml:mi>o</mml:mi><mml:mi>g</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            2,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:mi> </mml:mi><mml:mo>≅</mml:mo><mml:mi> </mml:mi></mml:math>",
                            ECompleteTextIncrementType.Equation
                            )
                }),
                new IncrementedTextVO("Se {0}, {1}, {2}, ... , {3} são os ângulos internos de um heptágono convexo e se as medidas destes ângulos formam, nesta ordem, uma progressão aritmética, então, a medida, em graus, do ângulo {4}é um número",
                 new List<CompleteTextIncrementVO>(){
                        new CompleteTextIncrementVO(
                            0,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>1</mml:mn></mml:mrow></mml:msub></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            1,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:msub></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            2,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>3</mml:mn></mml:mrow></mml:msub></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            3,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>7</mml:mn></mml:mrow></mml:msub></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            4,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:msub><mml:mrow><mml:mi>a</mml:mi></mml:mrow><mml:mrow><mml:mn>4</mml:mn></mml:mrow></mml:msub><mml:mi> </mml:mi></mml:math>",
                            ECompleteTextIncrementType.Equation
                            )
                    }
                ),
                new IncrementedTextVO("Das expressões latinas abaixo, todas de largo uso na linguagem culta, a única que contribui para exprimir corretamente uma afirmação presente no texto ocorre na frase:  ",
                                        null),
                new IncrementedTextVO("Um objeto é formado por 4 hastes rígidas conectadas em seus extremos por articulações, cujos centros são os vértices de um paralelogramo. As hastes movimentam‐se de tal forma que o paralelogramo permanece sempre no mesmo plano. A cada configuração desse objeto, associa‐se {0}, a medida do menor  ângulo interno do paralelogramo. A área da região delimitada pelo paralelogramo quando {1}90° é A\r\n{2}\r\nPara que a área da região delimitada pelo paralelogramo seja {3} , o valor de {4}necessariamente, igual a",
                new List<CompleteTextIncrementVO>(){
                        new CompleteTextIncrementVO(
                            0,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:mi>θ</mml:mi></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            1,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:mi>θ</mml:mi><mml:mo>=</mml:mo><mml:mi> </mml:mi></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            2,
                            "https://dev-reports-images.s3-sa-east-1.amazonaws.com/teste/Simulado01-Insper-2.png",
                            ECompleteTextIncrementType.Image
                            ),
                        new CompleteTextIncrementVO(
                            3,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:mfrac><mml:mrow><mml:mi>A</mml:mi></mml:mrow><mml:mrow><mml:mn>2</mml:mn></mml:mrow></mml:mfrac></mml:math>",
                            ECompleteTextIncrementType.Equation
                            ),
                        new CompleteTextIncrementVO(
                            4,
                            "<mml:math xmlns:mml=\"http://www.w3.org/1998/Math/MathML\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\"><mml:mi>θ</mml:mi><mml:mi> </mml:mi><mml:mi>é</mml:mi><mml:mo>,</mml:mo><mml:mi> </mml:mi></mml:math>",
                            ECompleteTextIncrementType.Equation
                            )
                    }
                )
            };
            #endregion
            #region QuestList
            var questionListQuiz = new List<Question>()
            {
                new Question(0, questionsEnunciatedsQuiz[0], new List<Alternative>(){
                    new Alternative(new IncrementedTextVO("menor do que 128.", null), true, 0),
                    new Alternative(new IncrementedTextVO("entre 128 e 129.", null), false, 1),
                    new Alternative(new IncrementedTextVO("entre 129 e 130.", null), false, 2),
                    new Alternative(new IncrementedTextVO("entre 130 e 131.", null), false, 3),
                    new Alternative(new IncrementedTextVO("maior que 131", null), false, 4),
                }, mathSubject.Id),
                new Question(1, questionsEnunciatedsQuiz[1], new List<Alternative>(){
                    new Alternative(new IncrementedTextVO("4,64", null), true, 0),
                    new Alternative(new IncrementedTextVO("8,32", null), false, 1),
                    new Alternative(new IncrementedTextVO("6.62", null), false, 2),
                    new Alternative(new IncrementedTextVO("3,68", null), false, 3),
                    new Alternative(new IncrementedTextVO("5,34", null), false, 4),
                }, percentageSubject.Id),
                new Question(2, questionsEnunciatedsQuiz[2], new List<Alternative>(){
                    new Alternative(new IncrementedTextVO("O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null), true, 0),
                    new Alternative(new IncrementedTextVO("O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null), false, 1),
                    new Alternative(new IncrementedTextVO("As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null), false, 2),
                    new Alternative(new IncrementedTextVO("Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null), false, 3),
                    new Alternative(new IncrementedTextVO("E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null), false, 4)
                }, portSubject.Id),
                new Question(3, questionsEnunciatedsQuiz[3], new List<Alternative>(){
                     new Alternative(new IncrementedTextVO("15°", null), true, 0),
                    new Alternative(new IncrementedTextVO("22,5°", null), false, 1),
                    new Alternative(new IncrementedTextVO("45°", null), false, 2),
                    new Alternative(new IncrementedTextVO("30°", null), false, 3),
                    new Alternative(new IncrementedTextVO("60°", null), false, 4),
                }, percentageSubject.Id)

            };

            var questionListFGV = new List<Question>()
            {
                new Question(0, questionsEnunciatedsFGV[0], new List<Alternative>(){
                    new Alternative(new IncrementedTextVO("menor do que 128.", null), true, 0),
                    new Alternative(new IncrementedTextVO("entre 128 e 129.", null), false, 1),
                    new Alternative(new IncrementedTextVO("entre 129 e 130.", null), false, 2),
                    new Alternative(new IncrementedTextVO("entre 130 e 131.", null), false, 3),
                    new Alternative(new IncrementedTextVO("maior que 131", null), false, 4),
                }, mathSubject.Id),
                new Question(1, questionsEnunciatedsFGV[1], new List<Alternative>(){
                    new Alternative(new IncrementedTextVO("4,64", null), true, 0),
                    new Alternative(new IncrementedTextVO("8,32", null), false, 1),
                    new Alternative(new IncrementedTextVO("6.62", null), false, 2),
                    new Alternative(new IncrementedTextVO("3,68", null), false, 3),
                    new Alternative(new IncrementedTextVO("5,34", null), false, 4),
                }, percentageSubject.Id),
                new Question(2, questionsEnunciatedsFGV[2], new List<Alternative>(){
                    new Alternative(new IncrementedTextVO("O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null), true, 0),
                    new Alternative(new IncrementedTextVO("O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null), false, 1),
                    new Alternative(new IncrementedTextVO("As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null), false, 2),
                    new Alternative(new IncrementedTextVO("Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null), false, 3),
                    new Alternative(new IncrementedTextVO("E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null), false, 4)
                }, portSubject.Id),
                new Question(3, questionsEnunciatedsFGV[3], new List<Alternative>(){
                     new Alternative(new IncrementedTextVO("15°", null), true, 0),
                    new Alternative(new IncrementedTextVO("22,5°", null), false, 1),
                    new Alternative(new IncrementedTextVO("45°", null), false, 2),
                    new Alternative(new IncrementedTextVO("30°", null), false, 3),
                    new Alternative(new IncrementedTextVO("60°", null), false, 4),
                }, percentageSubject.Id)

            };

            var questionListPastFGV = new List<Question>()
            {
                new Question(0, questionsEnunciatedsFGVPast[0], new List<Alternative>(){
                    new Alternative(new IncrementedTextVO("menor do que 128.", null), true, 0),
                    new Alternative(new IncrementedTextVO("entre 128 e 129.", null), false, 1),
                    new Alternative(new IncrementedTextVO("entre 129 e 130.", null), false, 2),
                    new Alternative(new IncrementedTextVO("entre 130 e 131.", null), false, 3),
                    new Alternative(new IncrementedTextVO("maior que 131", null), false, 4),
                }, mathSubject.Id),
                new Question(1, questionsEnunciatedsFGVPast[1], new List<Alternative>(){
                    new Alternative(new IncrementedTextVO("4,64", null), true, 0),
                    new Alternative(new IncrementedTextVO("8,32", null), false, 1),
                    new Alternative(new IncrementedTextVO("6.62", null), false, 2),
                    new Alternative(new IncrementedTextVO("3,68", null), false, 3),
                    new Alternative(new IncrementedTextVO("5,34", null), false, 4),
                }, percentageSubject.Id),
                new Question(2, questionsEnunciatedsFGVPast[2], new List<Alternative>(){
                    new Alternative(new IncrementedTextVO("O debate é uma condição sine qua non para que da tese e da antítese resulte uma síntese.", null), true, 0),
                    new Alternative(new IncrementedTextVO("O principal objetivo do terrorismo contemporâneo é manter o status quo por meio de mensagens falsas.", null), false, 1),
                    new Alternative(new IncrementedTextVO("As pessoas devem replicar, ipsis litteris, relatos pré-concebidos que circulam na rede.", null), false, 2),
                    new Alternative(new IncrementedTextVO("Ao repercutir na internet fatos que causam grande comoção, os internautas devem checá-los a posteriori.", null), false, 3),
                    new Alternative(new IncrementedTextVO("E Recomenda-se seguir a intuição, ao divulgar informações pelas redes sociais ou, lato sensu, ao retuitá-las.", null), false, 4)
                }, portSubject.Id),
                new Question(3, questionsEnunciatedsFGVPast[3], new List<Alternative>(){
                     new Alternative(new IncrementedTextVO("15°", null), true, 0),
                    new Alternative(new IncrementedTextVO("22,5°", null), false, 1),
                    new Alternative(new IncrementedTextVO("45°", null), false, 2),
                    new Alternative(new IncrementedTextVO("30°", null), false, 3),
                    new Alternative(new IncrementedTextVO("60°", null), false, 4),
                }, percentageSubject.Id)

            };
            #endregion

            var user = new User("Giovanni Sacchitiello", "41758132841", "11991392711", "Masculino", "sacchitiellogiovanni@gmail.com", 
                                DateTime.Parse("2000/05/05"), new AddressVO("03320020", "Rua antonio ciucio", "Carrão", "São Paulo", "SP", "148"), false);

            var examQuizPeriods = new List<ExamPeriodVO>()
            {
                new ExamPeriodVO(firstPeriod, firstPeriod.AddHours(2)),
                new ExamPeriodVO(firstPeriod.AddDays(1), firstPeriod.AddDays(1).AddHours(2))
            };
            var examQuiz = new Exam(1, EExamType.Quiz, examQuizPeriods, questionListQuiz);

            var actualPeriod = DateTime.Now;
            var examFgvPeriods = new List<ExamPeriodVO>()
            {
                new ExamPeriodVO(actualPeriod, actualPeriod.AddHours(4)),
                new ExamPeriodVO(actualPeriod.AddDays(1), actualPeriod.AddDays(1).AddHours(2))
            };
            var examFGV = new Exam(1, EExamType.FGV, examFgvPeriods, questionListFGV);

            var pastPeriod = DateTime.Now.AddDays(-2);
            var examFgvPastPeriods = new List<ExamPeriodVO>()
            {
                new ExamPeriodVO(pastPeriod, pastPeriod.AddHours(2)),
                new ExamPeriodVO(pastPeriod.AddDays(1), pastPeriod.AddDays(1).AddHours(2))
            };
            var examFGVPast = new Exam(2, EExamType.FGV, examFgvPastPeriods, questionListPastFGV);

            var examList = new List<Exam>()
            {
                examQuiz,
                examFGV,
                examFGVPast
            };

            modelBuilder.Entity<Subject>().HasData(mathSubject, portSubject, percentageSubject);


            modelBuilder.Entity<Exam>(x =>
            {
                x.HasData(examList.Select(x => x.MapToAnonnymousObject()));
            });

            var alternatives = examList.SelectMany(exam => exam.Questions.SelectMany(question => question.Alternatives.Select(alt => alt.MapToAnonnymousObject(question.Id))));
            modelBuilder.Entity<Alternative>().HasData(alternatives);


            modelBuilder.Entity<User>().HasData(user);

            modelBuilder.Entity<IncrementedTextVO>(x =>
            {
                //Enunciado das questões
                x.HasData(examList
                            .SelectMany(exam => exam.Questions.Select(question => question.Enunciated.MapToAnonnymousObject()))
                          );
                //Texto das alternativas com complementos
                x.HasData(examList
                           .SelectMany(exam => exam.Questions
                           .SelectMany(question => question.Alternatives
                           .Select(x => x.TextContent.MapToAnonnymousObject())))
                         );
            });

            

            modelBuilder.Entity<Question>().HasData(examList
                            .SelectMany(exam => exam.Questions
                            .Select(question =>
                                    question.MapToAnonnymousObject(exam.Id, question.Enunciated.Id, question.SubjectId)
                                    )
                            )
                         );

            modelBuilder.Entity<ExamPeriodVO>().HasData(examList
                           .SelectMany(exam => exam.Periods
                                .Select(period => period.MapToAnonnymousObject(exam.Id))
                                )
                        );



        }

        private static object MapToAnonnymousObject(this ExamPeriodVO examPeriod, Guid examId)
        {
            return new
            {
                examPeriod.Id,
                examPeriod.OpenDate,
                examPeriod.CloseDate,
                ExamId = examId
            };
        }
        private static object MapToAnonnymousObject(this Exam exam)
        {
            return new
            {
                exam.Id,
                exam.CreatedDate,
                exam.UpdatedDate,
                exam.ExamNumber,
                exam.ExamType
            };
        }
        private static object MapToAnonnymousObject(this Question question, Guid examId, Guid EnunciatedId, Guid SubjectId)
        {
            return new
            {
                question.Id,
                question.CreatedDate,
                question.UpdatedDate,
                ExamId = examId,
                EnunciatedId,
                SubjectId,
                question.Index
            };
        }
        private static object MapToAnonnymousObject(this IncrementedTextVO incrementedText)
        {
            return new
            {
                incrementedText.Id,
                incrementedText.Content,
                incrementedText.Increments
            };
        }
        private static object MapToAnonnymousObject(this Alternative alternative, Guid questionId)
        {
            return new
            {
                QuestionId = questionId,
                TextContentId = alternative.TextContent.Id,
                alternative.Index,
                alternative.IsCorrect
            };
        }
    }
}
