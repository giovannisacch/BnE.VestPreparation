using BnE.EducationVest.Domain.Exam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Extensions
{
    public static class AlternativeIndexExtension
    {
        public static char GetRespectiveIndexCharacter(this Alternative alternative)
        {
            switch (alternative.Index)
            {
                case 0:
                    return 'A';
                case 1:
                    return 'B';
                case 2:
                    return 'C';
                case 3:
                    return 'D';
                case 4:
                    return 'E';
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
