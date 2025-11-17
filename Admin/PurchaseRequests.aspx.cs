using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.OleDb;

namespace Thr_fty.Admin
{
    public partial class PurchaseRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridViewData();
            }
        }
        private void BindGridViewData()
        {
            string loggedInUsername = Session["Username"] as string;
            if (string.IsNullOrEmpty(loggedInUsername))
            {
                Response.Redirect("~/Pages/LogIn.aspx");
            }
            else
            {
                string CS = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
                OleDbConnection dbConn = new OleDbConnection(CS);

                // Define the SQL command with a parameter for sorting
                string sqlcommand1 = "SELECT [Img_dir] AS [ImgDir], [Item_name] AS [ItemName], [Buyer_username] AS [BuyerUsername], [Description] AS [Message], [Mobile_number] AS [Mobile], [Price] AS [Price]" +
                    " FROM [Notification]" +
                    " WHERE [Seller_username] = @Username";

                // Check the selected sort option from DropDownList
                if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "Sort")
                {
                    // Newest sorting
                    sqlcommand1 += " ORDER BY [Date_added] DESC";
                }
                else if (DropDownList1.SelectedValue == "2")
                {
                    // Oldest sorting
                    sqlcommand1 += " ORDER BY [Date_added] ASC";
                }

                OleDbCommand cmd = new OleDbCommand(sqlcommand1, dbConn);
                cmd.Parameters.AddWithValue("@Username", Session["Username"]);
                dbConn.Open();
                OleDbDataReader User = cmd.ExecuteReader();
                GridView1.DataSource = User;
                GridView1.DataBind();

                if (GridView1.Rows.Count > 0)
                {
                    DropDownList1.Visible = true; // Show the "Clear Cart" button
                }
                else
                {
                    DropDownList1.Visible = false; // Hide the "Clear Cart" button
                    lblMessage2.Text = "You have no purchase requests";
                }

                dbConn.Close();
            }
        }
        protected double CalculateTotalAccumulatedAmount()
        {
            string sellerUsername = Session["Username"] as string;
            if (string.IsNullOrEmpty(sellerUsername))
            {
                // Handle the case where the sellerUsername is not found in the session.
                return 0;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
            double totalAmount = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string sqlcommand = "SELECT [Price] FROM [Purchase] WHERE [Seller_username] = @Username";
                using (OleDbCommand cmd = new OleDbCommand(sqlcommand, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", sellerUsername);

                    try
                    {
                       
                        connection.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            double AmountValue;
                            if (double.TryParse(reader["Price"].ToString(), out AmountValue))
                            {
                                totalAmount += AmountValue;
                                
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that may occur during database retrieval.
                        // You can log the error or display a user-friendly message.
                    }
                }
            }

            return totalAmount;
        }

        protected void UpdateSellerAmount(double accumulatedAmount)
        {
            string sellerUsername = Session["Username"] as string;
            if (string.IsNullOrEmpty(sellerUsername))
            {
                // Handle the case where the sellerUsername is not found in the session.
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string sqlcommand = "UPDATE [Users] SET [Accumulated_amount] = @AccumulatedAmount WHERE [Username] = @Username";
                using (OleDbCommand cmd = new OleDbCommand(sqlcommand, connection))
                {
                    cmd.Parameters.AddWithValue("@AccumulatedAmount", accumulatedAmount);
                    cmd.Parameters.AddWithValue("@Username", sellerUsername);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that may occur during the database update.
                        // You can log the error or display a user-friendly message.
                    }
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Call the BindGridViewData method to rebind the GridView with the selected sorting option
            BindGridViewData();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                GridViewRow clickedRow = (GridViewRow)((Button)sender).NamingContainer;

                // Get the values from the GridView for the clicked row

                string buyerUsername = ((Label)clickedRow.FindControl("lblUsername")).Text;
                string productName = ((Label)clickedRow.FindControl("productName")).Text;

                Image imgDir = (Image)clickedRow.FindControl("productImg");

                string ImageDir = imgDir.ImageUrl;
                string imgFileName = System.IO.Path.GetFileName(ImageDir);

                // Perform the delete operation in the database
                string CS = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
                using (OleDbConnection dbConn = new OleDbConnection(CS))
                {
                    string sqlcommand1 = "DELETE FROM [Notification] WHERE [Seller_username] = @Username AND [Img_dir] = @ImgFileName  AND [Item_name] = @ItemName AND [Buyer_username] = @BuyerUsername";
                    using (OleDbCommand cmd = new OleDbCommand(sqlcommand1, dbConn))
                    {
                        cmd.Parameters.AddWithValue("@Username", Session["Username"]);
                        cmd.Parameters.AddWithValue("@ImgFileName", imgFileName);
                        cmd.Parameters.AddWithValue("@ItemName", productName);
                        cmd.Parameters.AddWithValue("@BuyerUsername", buyerUsername);

                        dbConn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                // After deleting the row, rebind the GridView to reflect the changes
                BindGridViewData();
            }
        }
        protected void btnPurchased_Click(object sender, EventArgs e)
        {
            
            if (sender is Button)
            {
                GridViewRow clickedRow = (GridViewRow)((Button)sender).NamingContainer;
                string buyerUsername = ((Label)clickedRow.FindControl("lblUsername")).Text;
                string productName = ((Label)clickedRow.FindControl("productName")).Text;
                string productPrice = ((Label)clickedRow.FindControl("lblPrice")).Text;

                Image imgDir = (Image)clickedRow.FindControl("productImg");

                string ImageDir = imgDir.ImageUrl;
                string imgFileName = System.IO.Path.GetFileName(ImageDir);
                string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO [Purchase] (Seller_username, Product_name, Picture_data, Buyer_username, Price) VALUES (@SellerUsername, @ItemName, @ImgDir, @BuyerUsername, @Price)";

                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@SellerUsername", Session["Username"]);
                        cmd.Parameters.AddWithValue("@ItemName", productName);
                        cmd.Parameters.AddWithValue("@ImgDir", imgFileName);
                        cmd.Parameters.AddWithValue("@BuyerUsername", buyerUsername);
                        cmd.Parameters.AddWithValue("@Price",productPrice);
                       

                        cmd.ExecuteNonQuery();

                       
                    }
                }
                using (OleDbConnection dbConn = new OleDbConnection(connectionString))
                {
                    string sqlcommand1 = "DELETE FROM [Clothing_item] WHERE [Seller_username] = @Username AND [Image_dir] = @ImgFileName";
                    using (OleDbCommand cmd = new OleDbCommand(sqlcommand1, dbConn))
                    {
                        cmd.Parameters.AddWithValue("@Username", Session["Username"]);
                        cmd.Parameters.AddWithValue("@ImgFileName", imgFileName);
                        //cmd.Parameters.AddWithValue("@ItemName", productName);
                        //cmd.Parameters.AddWithValue("@Price", productPrice);
                        dbConn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                using (OleDbConnection dbConn = new OleDbConnection(connectionString))
                {
                    string sqlcommand1 = "DELETE FROM [Notification] WHERE [Seller_username] = @Username AND [Img_dir] = @ImgFileName  AND [Item_name] = @ItemName AND [Price] = @Price";
                    using (OleDbCommand cmd = new OleDbCommand(sqlcommand1, dbConn))
                    {
                        cmd.Parameters.AddWithValue("@Username", Session["Username"]);
                        cmd.Parameters.AddWithValue("@ImgFileName", imgFileName);
                        cmd.Parameters.AddWithValue("@ItemName", productName);
                        cmd.Parameters.AddWithValue("@Price", productPrice);

                        dbConn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                using (OleDbConnection dbConn = new OleDbConnection(connectionString))
                {
                    string sqlcommand1 = "DELETE FROM [Item_in_Cart] WHERE [Seller_username] = @Username AND [Item_img_dir] = @ImgFileName  AND [Item_name] = @ItemName AND [Item_price] = @Price";
                    using (OleDbCommand cmd = new OleDbCommand(sqlcommand1, dbConn))
                    {
                        cmd.Parameters.AddWithValue("@Username", Session["Username"]);
                        cmd.Parameters.AddWithValue("@ImgFileName", imgFileName);
                        cmd.Parameters.AddWithValue("@ItemName", productName);
                        cmd.Parameters.AddWithValue("@Price", productPrice);

                        dbConn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                BindGridViewData();
                double newTotalAmount = CalculateTotalAccumulatedAmount();
                UpdateSellerAmount(newTotalAmount);
                string script = "showItemAddedAlert();";

                // Register the script for execution
                ClientScript.RegisterStartupScript(this.GetType(), "showItemAddedAlert", script, true);
            }

        }
    }
}