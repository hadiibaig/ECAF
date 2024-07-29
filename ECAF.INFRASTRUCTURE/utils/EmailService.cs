using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.utils
{
   public static class EmailService
    {
        public static void SendEmail(string receiver, string subject, string message)
        {
            try
            {
                var senderEmail = new MailAddress("something@techfusionworks.com", "ECAF");
                var receiverEmail = new MailAddress(receiver, "Receiver");
                var password = "Admin@123#$@#";
                var sub = subject;
                var body = message;
                var smtp = new SmtpClient
                {
                    Host = "smtp.hostinger.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(mess);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
