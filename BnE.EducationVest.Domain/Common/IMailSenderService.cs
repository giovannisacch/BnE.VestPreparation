using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Common
{
    public interface IMailSenderService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
