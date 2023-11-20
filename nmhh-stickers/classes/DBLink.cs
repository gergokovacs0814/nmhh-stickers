using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using ClosedXML.Excel;

namespace nmhh_stickers.classes
{
    public class DBLink
    {
        public static string connstring = @"workstation id=nmhhmatrica.mssql.somee.com;packet size=4096;user id=gergo-k-kae_SQLLogin_1;pwd=aj7w11tsky;data source=nmhhmatrica.mssql.somee.com;persist security info=False;initial catalog=nmhhmatrica";

        public static void AddInDB(string a)
        {
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(a, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }


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

        public static List<string> getUsernames()
        {
            List<string> usernames = new List<string>();
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("select username from USERS", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usernames.Add(reader.GetString(0));

                }
            }
            con.Close();

            return usernames;
        }

        public static List<STICKERS> getStickers()
        {
            List<STICKERS> stickers = new List<STICKERS>();
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("select * from MATRICAK", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    stickers.Add(new STICKERS(reader.GetString(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3)));

                }
            }
            con.Close();

            return stickers;
        }

       
    }
}