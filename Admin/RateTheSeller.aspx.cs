using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Security.Cryptography;
using System.Text;



namespace Thr_fty.Admin
{
    public partial class RateTheSeller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGridViewData();
            DataTable ratingData = GetRatingData();
            if (ratingData != null && ratingData.Rows.Count > 0)
            {
                
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

                // Retrieve data from Session
               
                string sellerUsername = Session["SellerUsername"] as string;

                // Use the retrieved information as needed

                lblSellerUsername.Text = sellerUsername;


                lblSellerUsername.Text = "Tell others what you think about : " + sellerUsername;
            }
        }

        

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string sellerUsername = Session["SellerUsername"] as string;
            string loggedInUsername = Session["Username"] as string;
            string productName = Session["ProductName"] as string;
            string ratingDescription = txtRatingDescription.InnerText;
            string selectedValue = DropDownList1.SelectedValue;
            int selectedRating;


            // Insert the rating into the database
            if (int.TryParse(selectedValue, out selectedRating))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
                using (OleDbConnection connection = new OleDbConnection(connectionString))

                {
                    connection.Open();

                    // Use a parameterized query to prevent SQL injection
                    string insertQuery = "INSERT INTO Rating (Rating_for, Rating_by, Rating, Rating_description, Product_name) VALUES (@RatingFor, @RatingBy, @Rating, @Description, @ProductName)";

                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@RatingFor", sellerUsername);
                        cmd.Parameters.AddWithValue("@RatingBy", loggedInUsername);
                        cmd.Parameters.AddWithValue("@Rating", selectedRating);
                        cmd.Parameters.AddWithValue("@Description", ratingDescription);
                        cmd.Parameters.AddWithValue("@ProductName", productName);

                        cmd.ExecuteNonQuery();
                    }
                    // Calculate and update the average rating for the seller in the Users table
                    double averageRating = CalculateAverageRating(sellerUsername);
                    UpdateSellerRating(sellerUsername, averageRating);
                }
                string script = "showItemAddedAlert();";

                // Register the script for execution
                ClientScript.RegisterStartupScript(this.GetType(), "showItemAddedAlert", script, true);

            }
            else
            {
                Response.Write("<script>alert('Select rating')</script>");
            }    
        }
        protected DataTable GetRatingData()
        {
            DataTable ratingData = new DataTable();

            string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string sqlcommand = "SELECT [Rating_for], [Rating] FROM [Rating] WHERE [Rating_for] = @Username";
                using (OleDbCommand cmd = new OleDbCommand(sqlcommand, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", Session["SellerUsername"]);

                    try
                    {
                        connection.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        ratingData.Load(reader); // Load the data into the DataTable.
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception 
                    }
                }
            }

            return ratingData;
        }
        protected double CalculateAverageRating(string sellerUsername)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
            double totalRating = 0;
            int ratingCount = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string sqlcommand = "SELECT [Rating] FROM [Rating] WHERE [Rating_for] = @Username";
                using (OleDbCommand cmd = new OleDbCommand(sqlcommand, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", sellerUsername);

                    try
                    {
                        connection.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            double ratingValue;
                            if (double.TryParse(reader["Rating"].ToString(), out ratingValue))
                            {
                                totalRating += ratingValue;
                                ratingCount++;
                            }
                        }

                        if (ratingCount > 0)
                        {
                            return totalRating / ratingCount;
                        }
                        else
                        {
                            return totalRating;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that may occur during database retrieval.
                        
                    }
                }
            }

            return 0; 
        }


        protected void UpdateSellerRating(string sellerUsername, double averageRating)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string sqlcommand = "UPDATE [Users] SET [Seller_rating] = @AverageRating WHERE [Username] = @Username";
                using (OleDbCommand cmd = new OleDbCommand(sqlcommand, connection))
                {
                    cmd.Parameters.AddWithValue("@AverageRating", averageRating);
                    cmd.Parameters.AddWithValue("@Username", sellerUsername);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that may occur during the database update.
                       
                    }
                }
            }
        }
    }

} 