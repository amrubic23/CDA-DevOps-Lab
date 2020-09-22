using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((String)Session["loggedIn"] != "t")
                Response.Redirect("Default.aspx");

            if ((String)Session["username"] != "admin")
                Response.Redirect("Contact.aspx");

        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session["loggedIn"] = "f";
            Response.Redirect("Default.aspx");
        }

 

        protected void btn_update_Click(object sender, EventArgs e)
        {
            for(int i=0; i< cb_NR.Items.Count; i++)
            {
                if(cb_NR.Items[i].Selected)
                {
                    String query = "UPDATE dbo.request SET status = @status WHERE username = @username;";
                    String connectionString = "Data Source=192.168.0.212;Initial Catalog=testDB;User ID=sa;Password=7v!SkU{r";
                    using (SqlConnection connection2 = new SqlConnection(
                        connectionString))
                    {
                        SqlCommand command = new SqlCommand(
                            query, connection2);
                        command.Parameters.AddWithValue("@username", cb_NR.Items[i].Value);
                        command.Parameters.AddWithValue("@Status", 1);
                        connection2.Open();
                        try
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine(String.Format("{0}, {1}",
                                        reader[0], reader[1]));
                                    string test = reader.GetString(0);
                                    string test2 = reader.GetString(1);
                                }
                            }

                        }
                        catch (System.Data.SqlClient.SqlException)
                        {
                        }
                    }
                    cb_NR.Items.RemoveAt(i);
                    i--;
                }
                
            }
           
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}