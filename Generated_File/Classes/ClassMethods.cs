using Devart.Data.MySql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generated_File.Classes
{
     static class ClassMethods
    {

        public static List<T> Joins<T>(this List<T> first, List<T> second)
        {
            if (first == null)
            {
                return second;
            }
            if (second == null)
            {
                return first;
            }

            return first.Concat(second).ToList();
        }


        //For mySql-Connection and MariaDB

        public static List<string> GetTables(string username, string password, string host, string port, string database)
        {
            List<string> TableNames = new List<string>();
            try
            {
                MySqlConnection connection = new MySqlConnection("User Id=" + username + ";Password=" + password + ";Host=" + host + ";Port=" + port + ";Database=" + database + ";Unicode=False;Persist Security Info=False;Character Set=utf8;Tiny As Boolean=True;Found Rows=True");

                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "SHOW TABLES;";
                MySqlDataReader Reader;
                connection.Open();
                Reader = command.ExecuteReader();
                while (Reader.Read())
                {
                    string row = "";
                    for (int i = 0; i < Reader.FieldCount; i++)
                        row += Reader.GetValue(i).ToString();
                    TableNames.Add(row);
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured " + ex.Message);
            }


            return TableNames;

        }

        //fOR Sql-Server Conn
        public static List<string> SQLSERVERGET(string host, string database, string username, string password)
        {
            List<string> TableNames = new List<string>();
            try
            {
                string connection_string = "Data Source=" + host + ",1433;Network Library=DBMSSOCN;Initial Catalog=" + database + ";User ID=" + username + ";Password=" + password + ";";
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();
                    DataTable schema = connection.GetSchema("Tables");

                    foreach (DataRow row in schema.Rows)
                    {
                        TableNames.Add(row[2].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured " + ex.Message);
            }

            return TableNames;

        }
    }
}
