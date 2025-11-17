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
    public partial class SendPurchaseRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string loggedInUsername = Session["Username"] as string;
            if (string.IsNullOrEmpty(loggedInUsername))
            {
                Response.Redirect("~/Admin/Cart.aspx");

            }
            else
            {
                string imgDir = Session["ImageDir"] as string;
                string price = Session["ItemPrice"] as string;

                string CS = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
                using (OleDbConnection dbConn = new OleDbConnection(CS))
                {
                    dbConn.Open();

                    string sqlCommand = "SELECT * FROM [Clothing_item] WHERE Image_dir = ?";
                    OleDbCommand cmd = new OleDbCommand(sqlCommand, dbConn);
                    cmd.Parameters.AddWithValue("Image_dir", imgDir);

                    OleDbDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Read(); // Move to the first row (if not already there)

                        PrequestImg.ImageUrl = "~/Images/" + dataReader.GetString(6); // Verify that column index 12 exists.
                       
                       lblPrice.Text = "R" + Convert.ToDouble(dataReader.GetString(5)); // Verify that column index 8 exists.
                       
                    }

                    dbConn.Close();
                }
            }
        }

        protected void btnRequest_Click(object sender, EventArgs e)
        {
            // Retrieve data from session state
            string buyerUsername = Session["Username"] as string;
            string sellerUsername = Session["SellerUsername"] as string;
            string itemName = Session["ProductName"] as string;
            string imgDir = Session["ImageDir"] as string;
            string price = Session["ItemPrice"] as string;

            // Retrieve data from the TextBox and TextArea
            string mobileNumber = txtMobile.Text;
            string description = txtMessage.Text;

            // Insert the data into your database
            string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Check if a record with the same Buyer_username, ImgDir, and Item_name already exists
                string checkQuery = "SELECT COUNT(*) FROM [Notification] WHERE Seller_username = @SellerUsername AND Item_name = @ItemName AND Img_dir = @ImgDir AND Buyer_username = @BuyerUsername";

                using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@SellerUsername", sellerUsername);
                    checkCmd.Parameters.AddWithValue("@ItemName", itemName);
                    checkCmd.Parameters.AddWithValue("@ImgDir", imgDir);
                    checkCmd.Parameters.AddWithValue("@BuyerUsername", buyerUsername);
                    

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // A record with the same values already exists
                       
                        lblFeedback.Text = "You have already requested this item.";
                    }
                    else
                    {
                        // Record doesn't exist, so insert it
                        string insertQuery = "INSERT INTO [Notification] (Seller_username, Item_name, Img_dir, Buyer_username, Mobile_number, Description, Price) VALUES (@SellerUsername, @ItemName, @ImgDir, @BuyerUsername, @MobileNumber, @Description, @Price)";

                        using (OleDbCommand cmd = new OleDbCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@SellerUsername", sellerUsername);
                            cmd.Parameters.AddWithValue("@ItemName", itemName);
                            cmd.Parameters.AddWithValue("@ImgDir", imgDir);
                            cmd.Parameters.AddWithValue("@BuyerUsername", buyerUsername);
                            cmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                            cmd.Parameters.AddWithValue("@Description", description);
                            cmd.Parameters.AddWithValue("@Price", price);

                            cmd.ExecuteNonQuery();

                        }
                        using (OleDbConnection dbConn = new OleDbConnection(connectionString))
                        {
                            string sqlcommand1 = "DELETE FROM [Item_in_Cart] WHERE [Buyer_username] = @Username AND [Item_img_dir] = @ImgFileName  AND [Item_name] = @ItemName AND [Seller_username] = @Seller";
                            using (OleDbCommand cmd = new OleDbCommand(sqlcommand1, dbConn))
                            {
                                cmd.Parameters.AddWithValue("@Username", Session["Username"]);
                                cmd.Parameters.AddWithValue("@ImgFileName", imgDir);
                                cmd.Parameters.AddWithValue("@ItemName", itemName);
                                cmd.Parameters.AddWithValue("@Seller", sellerUsername);

                                dbConn.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    // Notify the user that the request was successfully submitted
                    string script = "showItemAddedAlert();";

                    
                    ClientScript.RegisterStartupScript(this.GetType(), "ConfDelete", script, true);
                }
            }
            
        }
    }
}