using BnE.EducationVest.Domain.Exam.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Entities
{
    public class SupportingText 
    {
        //TODO: ANALISAR SE NAO FAZ SENTIDO VIRAR UM VALUE OBJECT
        public Guid Id { get; private set; }
        public Guid ContentId { get; private set; }
        public IncrementedTextVO Content { get; private set; }
        public List<Question> Questions { get; private set; }

        public SupportingText(Guid contentId)
        {
            Id = Guid.NewGuid();
            ContentId = contentId;
        }
        public SupportingText(IncrementedTextVO content)
        {
            Id = Guid.NewGuid();
            Content = content;
        }

        internal SupportingText()
        {

        }
    }
}
