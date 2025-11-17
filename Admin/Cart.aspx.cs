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
using System.IO;


namespace Thr_fty.Admin
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridViewData();
            }
            else if (Request.Form["__EVENTTARGET"] == "DeleteButtonPostBack")
            {
                // Check if the delete action is confirmed
                if (Request.Form["__EVENTARGUMENT"] == "")
                {
                    // Retrieve the information from session variables
                    string productName = Session["DeleteProductName"] as string;
                    string sellerUsername = Session["DeleteSellerUsername"] as string;
                    string price = Session["DeletePrice"] as string;
                    string fileName = Session["DeleteFileName"] as string;

                    // Execute the delete action with the provided information
                    PerformDeleteAction(productName, sellerUsername, price, fileName);

                    // Clear the session variables
                    Session.Remove("DeleteProductName");
                    Session.Remove("DeleteSellerUsername");
                    Session.Remove("DeletePrice");
                    Session.Remove("DeleteFileName");
                }
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
                string sqlcommand1 = "SELECT  DISTINCT [Item_img_dir] AS [ImgDir], [Item_name] AS [ItemName], [Seller_username] AS [SellerUsername],[Item_price] AS [Price] FROM [Item_in_Cart] WHERE [Buyer_username] = @Username";
                OleDbCommand cmd = new OleDbCommand(sqlcommand1, dbConn);
                cmd.Parameters.AddWithValue("@Username", Session["Username"]);
                dbConn.Open();
                OleDbDataReader User = cmd.ExecuteReader();
                GridView1.DataSource = User;
                GridView1.DataBind();
                dbConn.Close();
               
                if (GridView1.Rows.Count > 0)
                {
                    btnClear.Visible = true; // Show the "Clear Cart" button
                }
                else
                {
                    btnClear.Visible = false; // Hide the "Clear Cart" button
                    lblMessage2.Text = "The Cart is empty";
                }


            }
        }


        protected void btnFinilise_Click(object sender, EventArgs e)
        {
            // Get the GridView row associated with the clicked button
            GridViewRow clickedRow = (GridViewRow)((Button)sender).NamingContainer;
            string productName = ((Label)clickedRow.FindControl("productName")).Text;
            string sellerUsername = ((Label)clickedRow.FindControl("productSeller")).Text;
            string price = ((Label)clickedRow.FindControl("productPrice")).Text;

            // Find the Image control in the GridView row
            Image imgDir = (Image)clickedRow.FindControl("ImgDir");

            // Check if the Image control is not null
            if (imgDir != null)
            {
                // Retrieve the ImageUrl property
                string ImageDir = imgDir.ImageUrl;

                // Check if ImageDir is not null or empty before storing it in the session
                if (!string.IsNullOrEmpty(ImageDir))
                {
                    // Extract the file name from the image directory
                    string fileName = System.IO.Path.GetFileName(ImageDir);

                    // Store the data in Session variables
                    Session["ProductName"] = productName;
                    Session["SellerUsername"] = sellerUsername;
                    Session["ImageDir"] = fileName;
                    Session["ItemPrice"] = price;

                    // Redirect to the "SendPurchaseRequest.aspx" page
                    Response.Redirect("~/Admin/SendPurchaseRequest.aspx");
                }
                else
                {
                    Response.Write("Image directory is not valid.");
                }
            }
            else
            {
                // Handle the case where the Image control was not found
                // You can log an error or display a message to the user.
                // For example:
                Response.Write("Image control not found in the GridView row.");
            }



        }
        private void PerformDeleteAction(string productName, string sellerUsername, string price, string fileName)
        {
            string CS = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
            using (OleDbConnection dbConn = new OleDbConnection(CS))
            {
                string sqlcommand1 = "DELETE FROM [Item_in_Cart] WHERE [Buyer_username] = @Username AND [Item_img_dir] = @ImgFileName  AND [Item_name] = @ItemName AND [Seller_username] = @SellerUsername AND [Item_Price] = @Price";
                using (OleDbCommand cmd = new OleDbCommand(sqlcommand1, dbConn))
                {
                    cmd.Parameters.AddWithValue("@Username", Session["Username"]);
                    cmd.Parameters.AddWithValue("@ImgFileName", fileName);
                    cmd.Parameters.AddWithValue("@ItemName", productName);
                    cmd.Parameters.AddWithValue("@SellerUsername", sellerUsername);
                    cmd.Parameters.AddWithValue("@Price", price);

                    dbConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // After deleting the row, rebind the GridView to reflect the changes
            BindGridViewData();


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow clickedRow = (GridViewRow)((Button)sender).NamingContainer;

            // Store the information about the item to be deleted in session variables
            string productName = ((Label)clickedRow.FindControl("productName")).Text;
            string sellerUsername = ((Label)clickedRow.FindControl("productSeller")).Text;
            string price = ((Label)clickedRow.FindControl("productPrice")).Text;
            Image imgDir = (Image)clickedRow.FindControl("ImgDir");
            string ImageDir = imgDir.ImageUrl;
            string fileName = System.IO.Path.GetFileName(ImageDir);

            Session["DeleteProductName"] = productName;
            Session["DeleteSellerUsername"] = sellerUsername;
            Session["DeletePrice"] = price;
            Session["DeleteFileName"] = fileName;

            // Register the JavaScript function to show the confirmation dialog
            ClientScript.RegisterStartupScript(this.GetType(), "confirmDeleteScript", "confirmDelete();", true);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            //string script = "confirmDelete2;";

            //// Register the script for execution
            //ClientScript.RegisterStartupScript(this.GetType(), "ConfDelete", script, true);
            if (Page.IsValid)
            {
                string CS = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
                using (OleDbConnection dbConn = new OleDbConnection(CS))
                {
                    string sqlcommand1 = "DELETE FROM [Item_in_Cart] WHERE [Buyer_username] = @Username ";
                    using (OleDbCommand cmd1 = new OleDbCommand(sqlcommand1, dbConn))
                    {
                        cmd1.Parameters.AddWithValue("@Username", Session["Username"]);

                        try
                        {
                            dbConn.Open();
                            cmd1.ExecuteNonQuery();
                            lblMessage.Text = "Cart has been cleared.";
                            lblMessage.Visible = true;
                        }
                        catch (Exception)
                        {
                            // Handle any exceptions here
                        }
                    }
                }

                BindGridViewData();
            }
        }
    }
}