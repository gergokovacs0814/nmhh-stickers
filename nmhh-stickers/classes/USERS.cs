using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}