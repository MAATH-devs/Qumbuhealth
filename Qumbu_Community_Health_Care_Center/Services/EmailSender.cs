using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Net;
using System.Net.Mail;

namespace Qumbu_Community_Health_Care_Center.Services
{
    public class EmailSender: IEmailSender
    {
        public EmailSender() 
        {
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string from = "monkiMajor@gmail.com";
            string Password = "sydroybluqeorckp";
            string SenderName = "Admin";
            MailMessage message = new MailMessage();
            message.From = new MailAddress(from);
            message.Subject = subject;
            message.Body = "<html><body>" + htmlMessage + "</html></body>";
            message.To.Add(new MailAddress(email));
            message.IsBodyHtml = true;

            var smtpclient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(from, Password),
                EnableSsl = true,
            };
            smtpclient.Send(message);
        }
    }
}
