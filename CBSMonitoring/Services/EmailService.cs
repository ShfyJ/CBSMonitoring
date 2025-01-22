using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CBSMonitoring.Services
{
    public class EmailService
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _fromEmail;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;

        public EmailService(IConfiguration configuration)
        {
            _smtpHost = configuration["EmailSettings:SmtpHost"]!;
            _smtpPort = int.Parse(configuration["EmailSettings:SmtpPort"]!);
            _fromEmail = configuration["EmailSettings:FromEmail"]!;
            _smtpUsername = configuration["EmailSettings:SmtpUsername"]!;
            _smtpPassword = configuration["EmailSettings:SmtpPassword"]!;
        }

        public void SendEmail(string toEmail, string subject, string body)
        {
            using var client = new SmtpClient(_smtpHost, _smtpPort);
            client.EnableSsl = false;
            client.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);

            using var mailMessage = new MailMessage(_fromEmail, toEmail);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            client.Send(mailMessage);

            //using (var client = new SmtpClient("mail.ung.uz", 25))
            //{
            //    client.UseDefaultCredentials = false;
            //    client.Credentials = new NetworkCredential("ib@ung.uz", "sc@ryPaper45");
            //    client.EnableSsl = true;  // Ensure SSL/TLS encryption is enabled

            //    using (var mailMessage = new MailMessage("noreply@ib.ung.uz", "j.shofiyev@ung.uz"))
            //    {
            //        mailMessage.Subject = subject;
            //        mailMessage.Body = body;
            //        client.Send(mailMessage);
            //    }
            //}
        }

        

    }
}
