using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;

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

            MAILER mail = new MAILER();

            mail.ToAddress = email;
            mail.Body = "Welcome! <br><br> Your username: " + uname + "<br>and your password: " + pass + "<br><br>Best Regards,<br>Nmhh-stickers";
            mail.Subject = "NMHH Sticker database";
            try
            {
                MAILER.sendMail(mail);
                DBLink.AddInDB("Insert into USERS (username, password, jog, ceg) values ('" + uname + "' , '" + Pass.HashPassword(pass) + "', '2','" + company + "')");

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void updatePass(string uname, string email)
        {
            string pass = Pass.CreatePassword(6);

            MAILER mail = new MAILER();

            mail.ToAddress = email;
            mail.Body = "Dear " + uname + "! <br><br>Your new password is: " + pass + "<br>Best Regards,<br>Nmhh-stickers";
            mail.Subject = "New password";
            try
            {
                MAILER.sendMail(mail);
                DBLink.AddInDB("UPDATE USERS SET password = '" + Pass.HashPassword(pass) + "'WHERE username = '"+ uname +"';");

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}