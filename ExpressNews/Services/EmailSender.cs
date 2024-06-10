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
                Host = "smtp.gmail.com", //or another email sender provider
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("expressnewscontact@gmail.com", "eydd dadk plbf uqcw")//Express@2024!  expressnewscontact@gmail.com 
                //eydd dadk plbf uqcw
            };

            return client.SendMailAsync("expressnewscontact@gmail.com", email, subject, htmlMessage);
        }
    }
}
