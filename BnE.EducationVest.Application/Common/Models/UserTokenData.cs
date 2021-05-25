using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Common.Models
{
    public class UserTokenData
    {
        public IEnumerable<string> CognitoGroups { get; set; }
        public string CognitoId { get; set; }
        public string Scope { get; set; }
        public string ExpirationTimespan { get; set; }
        public string ClientId { get; set; }
    }
}
