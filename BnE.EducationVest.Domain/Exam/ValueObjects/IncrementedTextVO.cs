using BnE.EducationVest.Domain.Exam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.ValueObjects
{
    public class IncrementedTextVO
    {
        public Guid Id { get; private set; }
        public string Content { get; private set; }
        public List<CompleteTextIncrementVO> Increments { get; private set; }

        public Question Question { get; private set; }
        public Alternative Alternative { get; private set; }

        public IncrementedTextVO(string content, List<CompleteTextIncrementVO> increments)
        {
            Id = Guid.NewGuid();
            Content = content;
            Increments = increments;
        }
    }
}
