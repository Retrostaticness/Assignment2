using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace Assignment2
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    // Redirect to login page if user is not logged in
                    Response.Redirect("Login.aspx");
                }

                if (!SampleDataExists())
                {
                    InsertSampleData();
                }

                BindFlowerItems();
            }
        }

        private bool SampleDataExists()
        {
            // Check if at least one item exists in FlowerItems
            string connectionString = "Data Source=LAPTOP-8J5671QM\\SQLEXPRESS02;Initial Catalog=FlowerShop;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TOP 1 * FROM FlowerItems";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }

        private void ClearFlowerItems()
        {
            // Clear existing items from FlowerItems
            string connectionString = "Data Source=LAPTOP-8J5671QM\\SQLEXPRESS02;Initial Catalog=FlowerShop;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM FlowerItems";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void InsertSampleData()
        {
            // Clear existing items before inserting sample data
            ClearFlowerItems();

            string connectionString = "Data Source=LAPTOP-8J5671QM\\SQLEXPRESS02;Initial Catalog=FlowerShop;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sampleQuery = "INSERT INTO FlowerItems (ItemName, Price, ImagePath) VALUES " +
                    "('Rose Bouquet', 29.99, 'images/rose_bouquet.jpg'), " +
                    "('Sunflower Arrangement', 24.99, 'images/sunflower_arrangement.jpg'), " +
                    "('Tulip Bouquet', 19.99, 'images/tulip_bouquet.jpg')";

                using (SqlCommand sampleCommand = new SqlCommand(sampleQuery, connection))
                {
                    sampleCommand.ExecuteNonQuery();
                }
            }
        }

        private void BindFlowerItems()
        {
            string connectionString = "Data Source=LAPTOP-8J5671QM\\SQLEXPRESS02;Initial Catalog=FlowerShop;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM FlowerItems";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    rptFlowerItems.DataSource = dt;
                    rptFlowerItems.DataBind();
                }
            }
        }

        [WebMethod]
        public static string AddToCart(int itemID)
        {
            if (HttpContext.Current.Session["UserID"] != null)
            {
                int userID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
                int quantity = 1; // You might allow the user to choose quantity

                if (InsertIntoCart(userID, itemID, quantity))
                {
                    return "Item added to cart successfully!";
                }
                else
                {
                    return "Error adding item to cart.";
                }
            }
            else
            {
                return "User not logged in";
            }
        }

        private static bool InsertIntoCart(int userID, int itemID, int quantity)
        {
            string connectionString = "Data Source=LAPTOP-8J5671QM\\SQLEXPRESS02;Initial Catalog=FlowerShop;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Cart (UserID, ItemID, Quantity) VALUES (@UserID, @ItemID, @Quantity)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@ItemID", itemID);
                    command.Parameters.AddWithValue("@Quantity", quantity);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
    }
}