using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nmhh_stickers.classes;
using ClosedXML.Excel;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace nmhh_stickers
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            if (!Page.IsPostBack)
            {
                dplbUsername2.Items.Clear();
                foreach (string username in DBLink.getUsernames())
                {
                    dplbUsername2.Items.Add(username);
                }
            }
               
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string constr = @"workstation id=nmhhmatrica.mssql.somee.com;packet size=4096;user id=gergo-k-kae_SQLLogin_1;pwd=aj7w11tsky;data source=nmhhmatrica.mssql.somee.com;persist security info=False;initial catalog=nmhhmatrica";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM MATRICAK"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "Matricak");

                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=SqlExport.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text.Length < 2 || tbEmail.Text.Length < 2 || tbCompany.Text.Length < 2) Response.Write("<script>alert('The given data is not in a correct form');</script>");
            else
            {
                USERS.addNewUser(tbUsername.Text, tbEmail.Text, tbCompany.Text);

                tbCompany.Text = null;
                tbEmail.Text = null;
                tbUsername.Text = null;
                Response.Write("<script>alert('Email was sent');</script>");
            }
        }

        protected void btnNewPass_Click(object sender, EventArgs e)
        {

            

            
            if(tbEmail2.Text.Length > 1 & dplbUsername2.SelectedItem.Text.Length > 1)
            {
                USERS.updatePass(dplbUsername2.SelectedItem.Text, tbEmail2.Text);
                tbCompany.Text = null;
                tbEmail.Text = null;
                tbUsername.Text = null;
                Response.Write("<script>alert('Email was sent');</script>");
            }
            else
            {
                  Response.Write("<script>alert('The given data is not in a correct form');</script>");
            }
            
        }
    }
}