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
        public List<Subject> SubjectChilds { get; private set; }
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
        public bool IsGeography()
        {
            if (SubjectFather == null)
                return Name == "Geografia";
            return SubjectFather.IsGeography();
        }
        public bool IsSociology()
        {
            if (SubjectFather == null)
                return Name == "Sociologia";
            return SubjectFather.IsSociology();
        }
        public bool IsPhilosophy()
        {
            if (SubjectFather == null)
                return Name == "Filosofia";
            return SubjectFather.IsPhilosophy();
        }
        public bool IsHistory()
        {
            if (SubjectFather == null)
                return Name == "História";
            return SubjectFather.IsHistory();
        }
        public bool IsPhysical()
        {
            if (SubjectFather == null)
                return Name == "Fisíca";
            return SubjectFather.IsPhysical();
        }
        public bool IsChemistry()
        {
            if (SubjectFather == null)
                return Name == "Quimica";
            return SubjectFather.IsChemistry();
        }
        public bool IsBiology()
        {
            if (SubjectFather == null)
                return Name == "Biologia";
            return SubjectFather.IsBiology();
        }
    }
}
