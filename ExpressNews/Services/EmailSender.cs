using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace ExpressNews.Services
{
    public class EmailSender: IEmailSender
    {
        //private readonly IEmailSender _emailSender;
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SmtpClient client = new SmtpClient
            {
                Port = 587,
                Host = "smtp.gmail.com", 
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("expressnewscontact@gmail.com", "eydd dadk plbf uqcw")//Express@2024!  expressnewscontact@gmail.com 
                //eydd dadk plbf uqcw
            };

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("expressnewscontact@gmail.com"),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true // Set the body to HTML
            };

            // Ensure the recipient's email address is added correctly
            mailMessage.To.Add(new MailAddress(email));

            return client.SendMailAsync(mailMessage);//client.SendMailAsync("expressnewscontact@gmail.com", email, subject, htmlMessage);
        }
    }
}
