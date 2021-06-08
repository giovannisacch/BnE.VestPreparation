using BnE.EducationVest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Entities
{
    public class Subject : EntityBase
    {
        public string Name { get; private set; }
        public Guid? SubjectFatherId { get; private set; }
        public Subject SubjectFather { get; private set; }
        public List<Subject> SubjectChild { get; private set; }
        public List<Question> Questions { get; private set; }
        public Subject(string name)
        {
            Name = name;
        }
        public void SetSubjectFather(Guid subjectFatherId)
        {
            SubjectFatherId = subjectFatherId;
        }
        public bool IsMathTopic()
        {
            if (SubjectFather == null)
                return Name == "Matemática";
            return SubjectFather.IsMathTopic();
        }
        public bool IsPortugueseTopic()
        {
            if (SubjectFather == null)
                return Name == "Português";
            return SubjectFather.IsPortugueseTopic();
        }
    }
}
