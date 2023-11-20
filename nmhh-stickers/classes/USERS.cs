using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;

namespace nmhh_stickers.classes
{
    public class USERS
    {
        private string username;
        private string password;
        private int access;
        private string company;

        public USERS(string username, string password, int access, string company) 
        {
            this.username = username;
            this.password = password;
            this.access = access;
            this.company = company;
        }

        public string getUsername()
        {
            return username;
        }

        public string getCompany()
        {
            return company;
        }

        

        public static int login(string uname, string pass)
        {
            List<USERS> users = new List<USERS>();
            bool verified = false;

            users = DBLink.getUsers();
            foreach (USERS user in users)
            {
                if (user.username == uname)
                {
                    if (Pass.VerifyHashedPassword(user.password,pass))
                    {
                        verified = true;
                    }
                }
            }
            if (verified)
            {
                int access = 0;

                foreach (USERS user in users)
                {
                    if (uname == user.username) access = user.access;
                }
                switch (access)
                {
                    case 1: 
                        return 1; 
                        break;
                    case 2: 
                        return 2;
                        break;
                    default: 
                        return 0;
                        break;
                }
            }
            else return 0;
        }

        public static void addNewUser(string uname, string email, string company)
        {
            string pass = Pass.CreatePassword(6);

            MailMessage message = new MailMessage("nmhhmatrica.noreply@gmail.com", email);

            message.Subject = "NMHH Sticker database";
            message.Body = "Welcome! <br><br> Your username: "+ uname + "<br>and your password: "+ pass + "<br>Best Regards,<br>Nmhh-stickers";
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
                DBLink.AddInDB("Insert into USERS (username, password, jog, ceg) values ('" + uname + "' , '" + Pass.HashPassword(pass) + "', '2','" + company + "')");
            }

            catch (Exception ex)
            {
                throw ex;
            }
           

        }
    }
}