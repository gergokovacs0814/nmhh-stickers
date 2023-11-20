using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nmhh_stickers.classes
{
    public class STICKERS
    {
        private string barcode;
        private int vatID;
        private string company;
        private string shop;
        private string date;

        public STICKERS(string barcode, int vatID, string company, string shop, string date)
        {
            this.barcode = barcode;
            this.vatID = vatID;
            this.company = company;
            this.shop = shop;
            this.date = date;
        }

        public static void addSticker(string bcode, bool isItLaptop)
        {


        }
    }
}