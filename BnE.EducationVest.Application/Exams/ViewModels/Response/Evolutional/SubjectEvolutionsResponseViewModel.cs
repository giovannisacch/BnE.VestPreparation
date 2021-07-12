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
        public List<SubjectEvolution> SubjectsEvolution { get; set; }
    }
    public class ChartExplanation
    {
        public string ExplanationTitle { get; set; } = "Titulo de explicação de evolução";
        public string ExplanationDescription { get; set; } =
            @"
                Mussum Ipsum, cacilds vidis litro abertis. Em pé sem cair, deitado sem dormir, sentado sem cochilar e fazendo pose. Leite de capivaris, leite de mula manquis sem cabeça. 
               Mais vale um bebadis conhecidiss, que um alcoolatra anonimis. Diuretics paradis num copo é motivis de denguis.
             ";
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

    public class SubjectEvolution
    {
        public string Name { get; set; }
        public List<Evolution> Evolution { get; set; }
        public List<SubTopic> SubTopics { get; set; }
    }

}
