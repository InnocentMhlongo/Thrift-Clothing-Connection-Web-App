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
    public partial class ManangeListings : System.Web.UI.Page
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

                string sqlcommand1 = "SELECT [Image_dir] , [Item_name] , [Item_Price], [Seller_username]" +
                                     "FROM [Clothing_item] " +
                                     "WHERE [Seller_username] = @Username ";

                OleDbCommand cmd = new OleDbCommand(sqlcommand1, dbConn);
                cmd.Parameters.AddWithValue("@Username", Session["Username"]);
                dbConn.Open();

                OleDbDataReader User = cmd.ExecuteReader();

                // Check if there are listings in the result set
                if (User.HasRows)
                {
                    // Define the SQL command for sorting by date
                    string sortColumn = "Date_added"; // Change to the actual date column name
                    string sortOrder = "DESC"; // Change to "ASC" for oldest sorting

                    string sortedSql = $"{sqlcommand1} ORDER BY [{sortColumn}] {sortOrder}";

                    if (DropDownList1.SelectedValue == "2")
                    {
                        // Oldest sorting
                        sortOrder = "ASC";
                        sortedSql = $"{sqlcommand1} ORDER BY [{sortColumn}] {sortOrder}";
                    }
                    else if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "Sort")
                    {
                        sortOrder = "DESC";
                        sortedSql = $"{sqlcommand1} ORDER BY [{sortColumn}] {sortOrder}";
                    }

                    // Create a new command for sorting
                    OleDbCommand sortedCmd = new OleDbCommand(sortedSql, dbConn);
                    sortedCmd.Parameters.AddWithValue("@Username", Session["Username"]);

                    OleDbDataReader sortedUser = sortedCmd.ExecuteReader();

                    GridView1.DataSource = sortedUser;
                    GridView1.DataBind();
                }
                else
                {
                    // Listings are empty, hide DropDownList and display a message
                    DropDownList1.Visible = false;
                    lblMessage2.Text = "Your Listings are empty";
                }

                User.Close();
                dbConn.Close();
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
                
                string productName = ((Label)clickedRow.FindControl("productName")).Text;

                Image imgDir = (Image)clickedRow.FindControl("productImg");

                string ImageDir = imgDir.ImageUrl;
                string imgFileName = System.IO.Path.GetFileName(ImageDir);

                // Perform the delete operation in the database
                string CS = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
                using (OleDbConnection dbConn = new OleDbConnection(CS))
                {
                    string sqlcommand1 = "DELETE FROM [Clothing_item] WHERE [Seller_username] = @Username AND [Image_dir] = @ImgFileName  AND [Item_name] = @ItemName ";
                    using (OleDbCommand cmd = new OleDbCommand(sqlcommand1, dbConn))
                    {
                        cmd.Parameters.AddWithValue("@Username", Session["Username"]);
                        cmd.Parameters.AddWithValue("@ImgFileName", imgFileName);
                        cmd.Parameters.AddWithValue("@ItemName", productName);
                        

                        dbConn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                // After deleting the row, rebind the GridView to reflect the changes
                BindGridViewData();
            }
        }

       
    }
}