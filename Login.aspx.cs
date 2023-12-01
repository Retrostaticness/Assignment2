using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-8J5671QM\\SQLEXPRESS02;Initial Catalog=FlowerShop;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT UserID FROM Users WHERE UserName = @UserName AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", txtUsername.Text.Trim());
                    command.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        // Login successful
                        Session["UserID"] = Convert.ToInt32(result);
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        // Login failed
                        lblErrorMessage.Text = "Invalid username or password. Please try again.";
                        lblErrorMessage.Visible = true;
                    }
                }
            }
        }
    }
}