using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nmhh_stickers.classes;

namespace nmhh_stickers
{
    public partial class add : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Default.aspx");

            }
        }



        protected void btAdd_Click(object sender, EventArgs e)
        {
            

            if (tbBarcode.Text.Length == 9 && tbBarcode.Text.All(char.IsDigit))
            {
                if (STICKERS.addSticker(tbBarcode.Text, cbLaptop.Checked, Convert.ToString(Session["username"])))
                {
                    Response.Write("<script>alert('This barcode has already been added to the list.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('The form of the barcode is not correct');</script>");
            }

            
            tbBarcode.Text = null;
            cbLaptop.Checked = false;
        }
    }
}