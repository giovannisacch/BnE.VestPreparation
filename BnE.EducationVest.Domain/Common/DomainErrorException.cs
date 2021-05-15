using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Common
{
    public class DomainErrorException : Exception
    {
        public DomainErrorException()
        {
        }

        public DomainErrorException(string message)
            : base(message)
        {
        }

        public DomainErrorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
