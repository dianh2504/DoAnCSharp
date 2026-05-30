using MySqlConnector;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace DoAnCSharp_WPF.Models
{
    public class MSCUtil
    {
        public static MySqlConnection getConnection()
        {
            string connectionString = "Server=localhost;Port=3306;Database=quanlysinhvien;User ID = root;Password = ;";
            
                try
                {
                MySqlConnection c = new MySqlConnection(connectionString);
                c.Open();
                return c;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
        }
    }
}
