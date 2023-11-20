using nmhh_stickers.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nmhh_stickers
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
           

            switch (USERS.login(tbUser.Text, tbPass.Text))
            {
                case 1:
                    Session["username"] = tbUser.Text.Trim();
                    Response.Redirect("Admin.aspx");
                    break;
                case 2:
                    Session["username"] = tbUser.Text.Trim();
                    Response.Redirect("add.aspx");
                    break;
                default:
                    lblerror.Visible = true;
                    break;
            }
                
        }
    }
}