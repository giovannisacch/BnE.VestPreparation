using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Common.SettingsModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Infra.Service.Common
{
    public class MailSenderService : IMailSenderService
    {
        private readonly EmailSettings _emailSettings;
        public MailSenderService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            string toEmail = string.IsNullOrEmpty(email) ? _emailSettings.ToEmail : email;

            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(_emailSettings.FromEmail, "B&E Assessoria")
            };

            mail.To.Add(new MailAddress(toEmail));

            mail.Subject = "BNE_EDU " + subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            //outras opções
            //mail.Attachments.Add(new Attachment(arquivo));
            //

            using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
            {
                smtp.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.UsernamePassword);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            };
        }
    }
}
