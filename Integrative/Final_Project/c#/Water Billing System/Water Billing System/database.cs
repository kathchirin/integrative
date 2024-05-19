using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data;
using System.IO;

namespace Water_Billing_System
{
    class database
    {
        public static int idContent = 0;
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource = 127.0.0.1;port =3306;username =root;password=;database=waterbilling";
            MySqlConnection connection = new MySqlConnection(sql);
            try
            {
                connection.Open();
            }
            catch (MySqlException x)
            {
                MessageBox.Show("MySql Connecgtion! \n " + x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return connection;
        }

        public static void saveUpdaDel(string sql, string action)
        {
            string query = sql;
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (MySqlException x)
            {
                MessageBox.Show("Error! \n" +  x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        public static void datagridViewing(string sqlQuery, DataGridView dataview)
        {
            string sql = sqlQuery;
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataAdapter result = new MySqlDataAdapter(command);
            
            DataTable table = new DataTable();
            result.Fill(table);
            dataview.DataSource = table;
            dataview.Columns[0].Visible = false;

            connection.Close();
        }
        private static string encrypt(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute hash from the password string
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string representation
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2")); // Convert to hexadecimal format
                }

                string hashedPassword = builder.ToString();
                return hashedPassword.Substring(0,20);
            }
        }
    
        public static bool VerifyAccount(string username, string password)
        {
            using (MySqlConnection connection = GetConnection())
            {
                string query = "SELECT count(*) FROM account WHERE username = '"+username+"' AND password = '"+encrypt(password)+"'";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    try
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error verifying account! \n " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }
        public static void getUnpaid(int client_id, DataGridView dataview, Label label)
        {
         
            string sql = "SELECT `billing_id`, `month`, `year`,`status` FROM `billing_info` WHERE status='Unpaid' and client_id=" + client_id;
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataAdapter result = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            result.Fill(table);
            dataview.DataSource = table;
            dataview.Columns[0].Visible = false;
            connection.Close();
            
            string query = "SELECT count(*) as Balance from billing_info WHERE status='Unpaid' and client_id=" + client_id;
            MySqlConnection connections = GetConnection();
            MySqlCommand commands = new MySqlCommand(query, connections);
            try
            {
                MySqlDataReader dataReader = commands.ExecuteReader();
                while (dataReader.Read())
                {
                        label.Text = (20 * int.Parse((dataReader["Balance"] + ""))).ToString();  
                }
                dataReader.Close();
            }
            catch (MySqlException x)
            {
                MessageBox.Show("Error!\n" + x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connections.Close();
        }

        
    }
}
