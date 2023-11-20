using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace nmhh_stickers.classes
{
    public class DBLink
    {
        public static string connstring = @"workstation id=nmhhmatrica.mssql.somee.com;packet size=4096;user id=gergo-k-kae_SQLLogin_1;pwd=aj7w11tsky;data source=nmhhmatrica.mssql.somee.com;persist security info=False;initial catalog=nmhhmatrica";

        public static List<USERS> getUsers()
        {
            List<USERS> users = new List<USERS>();
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("select * from USERS", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new USERS(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3)));

                }
            }
            con.Close();

            return users;
        }
    }
}