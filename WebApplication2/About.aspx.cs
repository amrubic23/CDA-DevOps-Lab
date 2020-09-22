using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace WebApplication2
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_new_account_Click(object sender, EventArgs e)
        {
            
            if ((tb_user.Text == "") && (tb_pass1.Text == "") && (tb_pass2.Text == ""))
            {
                lb_error.Text = "All fields must be filled out";
                lb_error.Visible = true;
            }
            else if (tb_pass1.Text != tb_pass2.Text)
            {
                lb_error.Text = "Passwords do not match";
                lb_error.Visible = true;
            }
            else
            {
                string pass = encrypt(tb_pass1.Text);
                lb_error.Visible = false;
                String query = "INSERT INTO dbo.users (username,password) VALUES (@username, @password)";
                String connectionString = "Data Source=192.168.0.212;Initial Catalog=testDB;User ID=sa;Password=7v!SkU{r";
                using (SqlConnection connection = new SqlConnection(
                    connectionString))
                {
                    SqlCommand command = new SqlCommand(
                        query, connection);
                    command.Parameters.AddWithValue("@username", tb_user.Text);
                    command.Parameters.AddWithValue("@password", encrypt(tb_pass1.Text));
                    connection.Open();
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(String.Format("{0}, {1}",
                                    reader[0], reader[1]));
                            }
                        }
 
                        Response.Redirect("Default.aspx");
                        connection.Close();
                    }
                    catch (System.Data.SqlClient.SqlException )
                    {
                        lb_error.Text = "User already exists. Please use a different username";
                        tb_user.Text = "";
                        lb_error.Visible = true;
                        connection.Close();
                    }
                }
                
            }
        }

        public string encrypt(string encryptString)
        {
            string EncryptionKey = "CDA DevOps Lab Build";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }

        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "CDA DevOps Lab Build";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }


    }
}