using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace nmhh_stickers.classes
{
    public class MAILER
    {
        private string toAddress;
        private string body;
        private string subject;

        public string ToAddress { get => toAddress; set => toAddress = value; }
        public string Body { get => body; set => body = value; }
        public string Subject { get => subject; set => subject = value; }


        public static void sendMail(MAILER mail)
        {
            string pass = Pass.CreatePassword(6);

            MailMessage message = new MailMessage("nmhhmatrica.noreply@gmail.com", mail.toAddress);

            message.Subject = mail.Subject;
            message.Body = mail.body;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("nmhhmatrica.noreply", "tviwaozwmvoszuxk");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
    }



   
}