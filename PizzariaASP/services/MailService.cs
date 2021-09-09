using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PizzariaASP.services
{
    public class MailService : IMailService
    {
        private readonly MailConfiguration _config;

        public MailService(MailConfiguration config)
        {
            _config = config;
        }

        public bool SendEmail(string sub, string message, params string[] toList)
        {
            using (SmtpClient client = new SmtpClient())
            {
                client.Credentials = new NetworkCredential(_config.Email, _config.Password);
                client.Host = _config.Host;
                client.Port = _config.Port;
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.Subject = sub;
                mail.Body = message;
                foreach (string to in toList)
                {
                    mail.To.Add(to);
                }
                mail.From = new MailAddress(_config.Email);
                try
                {
                    client.Send(mail);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
