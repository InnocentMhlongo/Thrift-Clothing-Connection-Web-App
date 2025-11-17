using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;

namespace Thr_fty.Admin
{
    public partial class RateTheBuyer : System.Web.UI.Page
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
            string buyerUsername = Session["BuyerUsername"] as string;
            if (string.IsNullOrEmpty(buyerUsername))
            {
                // Handle the case where the buyer username is missing or invalid.
                Response.Redirect("~/Pages/LogIn.aspx");
            }
            else
            {
                lblBuyerUsername.Text = "Tell others what you think about: " + buyerUsername;
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string buyerUsername = Session["BuyerUsername"] as string;
            string loggedInUsername = Session["Username"] as string;
            string productName = Session["ProductName"] as string;
            string ratingDescription = txtRatingDescription.InnerText;
            string selectedValue = DropDownList1.SelectedValue;
            int selectedRating;

            if (int.TryParse(selectedValue, out selectedRating))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Rating (Rating_for, Rating_by, Buyer_Rating, Rating_description, Product_name) VALUES (@RatingFor, @RatingBy, @Rating, @Description, @ProductName)";

                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@RatingFor", buyerUsername);
                        cmd.Parameters.AddWithValue("@RatingBy", loggedInUsername);
                        cmd.Parameters.AddWithValue("@Rating", selectedRating);
                        cmd.Parameters.AddWithValue("@Description", ratingDescription);
                        cmd.Parameters.AddWithValue("@ProductName", productName);

                        cmd.ExecuteNonQuery();
                    }

                    double averageRating = CalculateAverageRating(buyerUsername);
                    UpdateSellerRating(buyerUsername, averageRating);
                }
                string script = "showItemAddedAlert();";

                // Register the script for execution
                ClientScript.RegisterStartupScript(this.GetType(), "showItemAddedAlert", script, true);
            }
            else
            {
                // Handle the case where the selected rating is not a valid integer.
                Response.Write("<script>alert('Select a valid rating')</script>");
            }
        }

        protected double CalculateAverageRating(string buyerUsername)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
            double totalRating = 0;
            int ratingCount = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string sqlcommand = "SELECT [Buyer_Rating] FROM [Rating] WHERE [Rating_for] = @Username";
                using (OleDbCommand cmd = new OleDbCommand(sqlcommand, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", buyerUsername);

                    try
                    {
                        connection.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            int ratingValue;
                            if (int.TryParse(reader["Buyer_Rating"].ToString(), out ratingValue))
                            {
                                totalRating += ratingValue;
                                ratingCount++;
                            }
                        }

                        if (ratingCount > 0)
                        {
                            return totalRating / ratingCount;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that may occur during database retrieval.
                        // You can log the error or display a user-friendly message.
                    }
                }
            }

            return 0; // Return 0 if there are no ratings for the user or an error occurs.
        }

        protected void UpdateSellerRating(string buyerUsername, double averageRating)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string sqlcommand = "UPDATE [Users] SET [Buyer_rating] = @AverageRating WHERE [Username] = @Username";
                using (OleDbCommand cmd = new OleDbCommand(sqlcommand, connection))
                {
                    cmd.Parameters.AddWithValue("@AverageRating", averageRating);
                    cmd.Parameters.AddWithValue("@Username", buyerUsername);

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
    }
}