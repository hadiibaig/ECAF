using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Repositories
{
   public class SettingRepository
    {
        private readonly ECAFEntities _db;

        public SettingRepository()
        {
            _db = new ECAFEntities();
        }


        public List<string> GetRoleNames()
        {
            try
            {
                //var smtpClient = new SmtpClient
                //{
                //    Host = "smtp.hostinger.com",
                //    Port = 465,
                //    EnableSsl = true,
                //    DeliveryMethod = SmtpDeliveryMethod.Network,
                //    UseDefaultCredentials = false,
                //    Credentials = new NetworkCredential("Owais@techfusionworks.com", "Admin@123#"),
                //    Timeout = 20000
                //};

                //var mailMessage = new MailMessage
                //{
                //    From = new MailAddress("Owais@techfusionworks.com", "test email"),
                //    Subject = "Test Subject",
                //    Body = "Test Body",
                //    IsBodyHtml = false
                //};
                //mailMessage.To.Add("hadibaig360@gmail.com");

                //smtpClient.Send(mailMessage);


                var senderEmail = new MailAddress("something@techfusionworks.com", "ECAF");
                var receiverEmail = new MailAddress("test65@mailinator.com", "Receiver");
                var password = "Admin@123#$@#";
                var sub = "Ecaf test";
                var body = "Body Test";
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
                    Body = body
                })
                {
                    smtp.Send(mess);
                }





            }
            catch (Exception ex)
            {

            }
            return _db.AspNetRoles.Select(r => r.Name).ToList();
        }
    }
}
