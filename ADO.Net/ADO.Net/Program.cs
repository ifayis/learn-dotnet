using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

    internal class Program
    {
        static void Main(string[] args)
        {
        string connStr = @"Server=localhost\SQLEXPRESS;Database=studentsDB;Trusted_Connection=True;";
        using (SqlConnection con = new SqlConnection(connStr))
         {
            con.Open();

            string query = "select id,name,detailsid from Students";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr["id"]} - {dr["name"]} - {dr["detailsid"]}");
            }

            dr.Close();
         }
        }
    }
