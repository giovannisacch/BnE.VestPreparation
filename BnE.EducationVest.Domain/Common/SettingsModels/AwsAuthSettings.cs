using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Common.SettingsModels
{
    public class AwsAuthSettings
    {
        public int Region { get; set; }
        public int AcessKey { get; set; }
        public int SecretKey { get; set; }
        public int UserPoolClientId { get; set; }
        public int UserPoolClientSecret { get; set; }
        public int UserPoolId { get; set; }
    }
}
