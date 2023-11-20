using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nmhh_stickers.classes;

namespace nmhh_stickers.classes
{
    public class STICKERS
    {
        private string barcode;
        private int vatID;
        private string company;
        private string date;

        public STICKERS(string barcode, int vatID, string company, string date)
        {
            this.barcode = barcode;
            this.vatID = vatID;
            this.company = company;
            this.date = date;
        }

        public static bool addSticker(string bcode, bool isItLaptop, string username)
        {
            List<STICKERS> stickers = new List<STICKERS>();
            List<USERS> users = new List<USERS>();
            bool isItContain = true;
            stickers = DBLink.getStickers();
            users = DBLink.getUsers();
            string company="default";


            foreach(USERS user in users)
            {
                if(user.getUsername() == username)
                {
                    company = user.getCompany();
               
                }
            }

            List<string> barcodes = new List<string>();

            foreach (STICKERS sticker in stickers)
            {
                barcodes.Add(sticker.barcode);
            }



            if (barcodes.Contains(bcode))
            {
                isItContain = true;
            }
            else
            {
                string vatNum = "8517";
                if(isItLaptop)
                {
                    vatNum = "8471";
                }

                isItContain=false;
                DBLink.AddInDB("insert into MATRICAK(barcode, vatNum, company, date) values ('" + bcode + "', '" + vatNum + "', '" + company + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "')");

            }
            return isItContain;
        }
    }
}