using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment2
{
    public partial class ViewCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCartItems();
                CalculateTotalPrice();
            }
        }

        private void BindCartItems()
        {
            string connectionString = "Data Source=LAPTOP-8J5671QM\\SQLEXPRESS02;Initial Catalog=FlowerShop;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int userID = Convert.ToInt32(Session["UserID"]);
                string query = "SELECT c.Quantity, f.ItemName, f.Price " +
                               "FROM Cart c " +
                               "JOIN FlowerItems f ON c.ItemID = f.ItemID " +
                               "WHERE c.UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    rptCartItems.DataSource = dt;
                    rptCartItems.DataBind();
                }
            }
        }

        private void CalculateTotalPrice()
        {
            string connectionString = "Data Source=LAPTOP-8J5671QM\\SQLEXPRESS02;Initial Catalog=FlowerShop;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int userID = Convert.ToInt32(Session["UserID"]);
                string query = "SELECT SUM(f.Price * c.Quantity) " +
                               "FROM Cart c " +
                               "JOIN FlowerItems f ON c.ItemID = f.ItemID " +
                               "WHERE c.UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        decimal totalPrice = Convert.ToDecimal(result);
                        litTotalPrice.Text = totalPrice.ToString("C");
                    }
                    else
                    {
                        litTotalPrice.Text = "$0.00";
                    }
                }
            }
        }

        protected void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            // Add logic to confirm the order, update database, etc.
            ClearCart();  // Clear the cart upon order confirmation
            Response.Redirect("OrderConfirmed.aspx");
        }

        private void ClearCart()
        {
            string connectionString = "Data Source=LAPTOP-8J5671QM\\SQLEXPRESS02;Initial Catalog=FlowerShop;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int userID = Convert.ToInt32(Session["UserID"]);
                string query = "DELETE FROM Cart WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}