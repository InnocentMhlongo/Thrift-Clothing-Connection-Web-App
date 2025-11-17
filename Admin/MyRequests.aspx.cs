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
    public partial class MyRequests : System.Web.UI.Page
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
                string sqlcommand1 = "SELECT [Img_dir] AS [ImgDir], [Item_name] AS [ItemName], [Seller_username] AS [SellerUsername], [Description] AS [Message], [Mobile_number] AS [Mobile] " +
                                     "FROM [Notification] " +
                                     "WHERE [Buyer_username] = @Username ";

               

                // Check the selected sort option from DropDownList
                if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "Sort")
                {
                    // Newest sorting
                    sqlcommand1 += "ORDER BY [Date_added] DESC";
                }
                else if (DropDownList1.SelectedValue == "2")
                {
                    // Oldest sorting
                    sqlcommand1 += "ORDER BY [Date_added] ASC";
                }

                OleDbCommand cmd = new OleDbCommand(sqlcommand1, dbConn);
                cmd.Parameters.AddWithValue("@Username", Session["Username"]);
                dbConn.Open();
                OleDbDataReader User = cmd.ExecuteReader();
                GridView1.DataSource = User;
                GridView1.DataBind();

                if(GridView1.Rows.Count > 0)
                {
                    DropDownList1.Visible = true; // Show the "Clear Cart" button
                }
                else
                {
                    DropDownList1.Visible = false; // Hide the "Clear Cart" button
                    lblMessage2.Text = "You did not request for anything";
                }

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
                
                string sellerUsername = ((Label)clickedRow.FindControl("lblUsername")).Text;
                string productName = ((Label)clickedRow.FindControl("productName")).Text;

                Image imgDir = (Image)clickedRow.FindControl("productImg");

                string ImageDir = imgDir.ImageUrl;
                string imgFileName = System.IO.Path.GetFileName(ImageDir);

                // Perform the delete operation in the database
                string CS = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
                using (OleDbConnection dbConn = new OleDbConnection(CS))
                {
                    string sqlcommand1 = "DELETE FROM [Notification] WHERE [Buyer_username] = @Username AND [Img_dir] = @ImgFileName  AND [Item_name] = @ItemName AND [Seller_username] = @SellerUsername";
                    using (OleDbCommand cmd = new OleDbCommand(sqlcommand1, dbConn))
                    {
                        cmd.Parameters.AddWithValue("@Username", Session["Username"]);
                        cmd.Parameters.AddWithValue("@ImgFileName", imgFileName);
                        cmd.Parameters.AddWithValue("@ItemName", productName);
                        cmd.Parameters.AddWithValue("@SellerUsername", sellerUsername);

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