using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels
{
    public class SubjectEvolutionsResponseViewModel
    {
        public ChartExplanation ChartExplanation { get; set; }
        public List<SubjectsEvolution> SubjectsEvolution { get; set; }
    }
    public class ChartExplanation
    {
        public string ExplanationTitle { get; set; }
        public string ExplanationDescription { get; set; }
    }

    public class Evolution
    {
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }

    public class SubTopic
    {
        public string Name { get; set; }
        public List<Evolution> Evolution { get; set; }
    }

    public class SubjectsEvolution
    {
        public string Name { get; set; }
        public List<Evolution> Evolution { get; set; }
        public List<SubTopic> SubTopics { get; set; }
    }

}
