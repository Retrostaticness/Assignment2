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
    public partial class OrderConfirmed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindConfirmedItems();
            }
        }

        private void BindConfirmedItems()
        {
            string connectionString = "Data Source=LAPTOP-8J5671QM\\SQLEXPRESS02;Initial Catalog=FlowerShop;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int userID = Convert.ToInt32(Session["UserID"]);

                // Assuming 'ConfirmedOrders' table has columns 'ItemName', 'Price', 'ImagePath', etc.
                string query = "SELECT ItemName, Price, ImagePath FROM ConfirmedOrders WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    rptConfirmedItems.DataSource = dt;
                    rptConfirmedItems.DataBind();
                }
            }
        }
    }
}