using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels
{
    public class ExamReportViewModel
    {
        public string ExamName { get; set; } = "Simulado Insper 2";
        public DateTime ExamDate { get; set; } = DateTime.Now;
        public IEnumerable<ExamReportPerformanceViewModel> Performance { get; set; }
        public ExamReportSubjectDifficultyViewModelCard SubjectsDifficulties { get; set; }
        public ExamReportSubjectDistributionViewModelCard SubjectsDistribution { get; set; }
        public ExamReportAcertsAndErrorBySubjectCard AcertsAndErrorsBySubject { get; set; }
        public ExamReportAcertsAndErrorByQuestionCard AcertsAndErrorsByQuestion { get; set; }
    }
    public class ExamReportPerformanceViewModel
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }
    public class ExamReportSubjectDifficultyViewModel
    {

        public string Name { get; set; }
        public string Easy { get; set; }
        public string Medium { get; set; }
        public string Hard { get; set; }
    }
    public class ExamReportSubjectDifficultyViewModelCard
    {
        public string Title { get; set; } = "Dificuldade das Matérias";
        public string IntroductionText { get; set; } = @"O objetivo deste tópico é apresentar uma visão qual do simulado, informando quais matérias caíram, quantas questões de cada assunto, o assunto específico e sua representatividade no simulado.";
        public List<ExamReportSubjectDifficultyViewModel> SubjectDifficultyRanks { get; set; }
    }
    public class ExamReportSubjectDistributionViewModel
    {

        public string Name { get; set; }
        public IEnumerable<int> QuestionNumbers { get; set; }
    }
    public class ExamReportSubjectDistributionViewModelCard
    {
        public string Title { get; set; } = "Distribuição de matérias";
        public string IntroductionText { get; set; } = @"O objetivo deste tópico é apresentar uma visão qual do simulado, informando quais matérias caíram, quantas questões de cada assunto, o assunto específico e sua representividade no simulado.";
        public List<ExamReportSubjectDistributionViewModel> subjectDistributionTopics { get; set; }
    }
    public class ExamReportAcertsAndErrorBySubject
    {

        public string Subject { get; set; }
        public int QuestionCount { get; set; }
        public int CorrectCount { get; set; }
    }
    public class ExamReportAcertsAndErrorBySubjectCard
    {
        public string Title { get; set; } = "Erros e acertos por matéria";
        public string IntroductionText { get; set; } = "Nesse tópico, o objetivo é deixar claro para você como foi seu desempenho em cada matéria específica, com o objetivo de você conseguir analisar suas facilidades e dificuldadades, além do proveito de aprendizado específico.";
        public List<ExamReportAcertsAndErrorBySubject> ExamReportAcertsAndErrorBySubjectCardTopics { get; set; }
    }
    public class ExamReportAcertsAndErrorByQuestionCard
    {
        public string Title { get; set; } = "Erros e acertos por questão";
        public string IntroductionText { get; set; } = "Nesse tópico vamos trazer uma analise de questão por questão. Cada uma delas foi classificada em facil, moderada e difícil de acordo com o percentual de acertos de todos os candidatos.";
        public List<ExamReportAcertsAndErrorByQuestionExplanationTable> ExplanationTable { get; set; }
        public List<ExamReportAcertsAndErrorByQuestion> ExamReportAcertsAndErrorByQuestionCardTopics { get; set; }
    }
    public class ExamReportAcertsAndErrorByQuestion
    {
        public int QuestionNumber { get; set; }
        public string Subject { get; set; }
        public string ChosenAlternative { get; set; }
        public string RightAlternative { get; set; }
        public string Difficulty { get; set; }
    }
    public class ExamReportAcertsAndErrorByQuestionExplanationTable
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
