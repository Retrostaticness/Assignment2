using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Assignment2
{
    public partial class Register : System.Web.UI.Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-8J5671QM\\SQLEXPRESS02;Initial Catalog=FlowerShop;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Users (UserName, Password, Email) VALUES (@UserName, @Password, @Email)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", txtUsername.Text.Trim());
                    command.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    command.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Registration successful
                        lblStatus.Text = "Registration successful!";
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        // Registration failed
                        lblStatus.Text = "Registration failed. Please try again.";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                    }

                    lblStatus.Visible = true;
                }
            }
        }
    }
}