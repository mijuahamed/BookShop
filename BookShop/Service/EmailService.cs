using BookShop.Models;
using Microsoft.Extensions.Options;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Service
{
    public class EmailService : IEmailService
    {
        private const string templatePath = @"EmailTemplate/{0}.html";
        private readonly SMTPConfigModel _smtpConfigModel;
        public EmailService(IOptions<SMTPConfigModel> sMTPConfigModel)
        {
            _smtpConfigModel = sMTPConfigModel.Value;
        }
        private async Task SendEmail(UserEmailOptions userEmailOptions)
        {
            MailMessage mail = new MailMessage
            {
                Subject = userEmailOptions.Subject,
                Body = userEmailOptions.Body,
                From = new MailAddress(_smtpConfigModel.SenderAddress, _smtpConfigModel.SenderDisplayName),
                IsBodyHtml = _smtpConfigModel.IsBodyHTML
            };
            foreach (var toEmail in userEmailOptions.ToEmails)
            {
                mail.To.Add(toEmail);
            }
            NetworkCredential networkCredential = new NetworkCredential(_smtpConfigModel.UserName, _smtpConfigModel.Password);
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpConfigModel.Host,
                Port = _smtpConfigModel.Port,
                EnableSsl = _smtpConfigModel.EnableSSl,
                UseDefaultCredentials = _smtpConfigModel.UseDefaultCredentials,
                Credentials = networkCredential
            };
            mail.BodyEncoding = Encoding.Default;
            await smtpClient.SendMailAsync(mail);
        }
        private string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(templatePath, templateName));
            return body;
        }

        public async Task SendTestEmail(UserEmailOptions userEmailOptions)
        {
            userEmailOptions.Subject = "This is tect email option from book shop";
            userEmailOptions.Body = GetEmailBody("TestEmail");
            await SendEmail(userEmailOptions);
        }

    }
}
