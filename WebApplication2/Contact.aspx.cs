using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((String)Session["loggedIn"] != "t")
                Response.Redirect("Default.aspx");

            if ((String)Session["username"] == "admin")
                Response.Redirect("AdminPage.aspx");

            lb_error.Visible = false;
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["loggedIn"] = "f";
            Response.Redirect("Default.aspx");
        }

        protected void btn_network_req_Click(object sender, EventArgs e)
        {
            String query = "INSERT INTO dbo.request (username,status) VALUES (@username, @status)";
            String connectionString = "Data Source=192.168.0.212;Initial Catalog=testDB;User ID=sa;Password=7v!SkU{r";
            using (SqlConnection connection2 = new SqlConnection(
                connectionString))
            {
                SqlCommand command = new SqlCommand(
                    query, connection2);
                command.Parameters.AddWithValue("@username", Session["username"]);
                command.Parameters.AddWithValue("@Status", 0);
                connection2.Open();
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
                    lb_error.Visible = false;
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    lb_error.Text = "Request is pending. Please contact Administrator";
                    lb_error.Visible = true;
                }
            }
        }


    }
}