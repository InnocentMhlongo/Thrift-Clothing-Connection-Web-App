using System;
using System.Configuration;
using System.Data.OleDb;
using System.Web.UI;

namespace Thr_fty.Admin
{
    public partial class ViewItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DLBind();
            }
        }

        protected void DLBind()
        {
            string CS = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
            using (OleDbConnection dbConn = new OleDbConnection(CS))
            {
                dbConn.Open();

                string sqlCommand = "SELECT * FROM [Clothing_item] WHERE Image_dir = ?";
                OleDbCommand cmd = new OleDbCommand(sqlCommand, dbConn);
                cmd.Parameters.AddWithValue("Image_dir", Session["selectedImageDir"]);

                OleDbDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read(); // Move to the first row (if not already there)

                    imgProduct.ImageUrl = "~/Images/" + dataReader.GetString(6); // Verify that column index 12 exists.
                    productName.Text = dataReader.GetString(8); // Verify that column index 2 exists.
                    productPrice.Text = "R" + Convert.ToDouble(dataReader.GetString(5)); // Verify that column index 8 exists.
                    productBrand.Text = dataReader.GetString(2); // Verify that column index 4 exists.
                    productSize.Text = dataReader.GetString(4); // Verify that column index 7 exists.
                    productCondition.Text = dataReader.GetString(9); // Verify that column index 5 exists.
                    lblDescr.Text = dataReader.GetString(3); // Verify that column index 6 exists.
                }

                dbConn.Close();
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
            using (OleDbConnection dbConn = new OleDbConnection(CS))
            {
                dbConn.Open();

                string sqlCommand = "SELECT [Image_dir], [Item_name], [Item_price],[Seller_username] from [Clothing_item] WHERE Image_dir = ?";
                OleDbCommand cmd = new OleDbCommand(sqlCommand, dbConn);
                cmd.Parameters.AddWithValue("Image_dir", Session["selectedImageDir"]);

                OleDbDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        sqlCommand = "INSERT INTO [Item_in_cart] (Buyer_username, Item_img_dir, Item_name, Item_Price, Seller_username) VALUES (@Buyerusername, @img, @name, @price, @Sellerusername)";

                        cmd = new OleDbCommand(sqlCommand, dbConn);

                        cmd.Parameters.AddWithValue("@Buyerusername", Session["Username"]);
                        cmd.Parameters.AddWithValue("@img", dataReader.GetString(0));
                        cmd.Parameters.AddWithValue("@name", dataReader.GetString(1));
                        cmd.Parameters.AddWithValue("@price", Convert.ToDouble(dataReader["Item_price"]));
                        cmd.Parameters.AddWithValue("@Sellerusername", dataReader.GetString(3));

                        cmd.ExecuteNonQuery(); // Execute the INSERT query here.
                    }
                    dataReader.Close(); // Close the data reader after use.
                }

                dbConn.Close();
            }
            string script = "showItemAddedAlert();";

            // Register the script for execution
            ClientScript.RegisterStartupScript(this.GetType(), "showItemAddedAlert", script, true);
            //string CS = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
            //using (OleDbConnection dbConn = new OleDbConnection(CS))
            //{
            //    dbConn.Open();

            //    string sqlCommand = "SELECT Buyer_username, Item_img_dir, Item_name, item_price, Seller_username FROM [Clothing_item] WHERE Image_dir = @imgDir";
            //    OleDbCommand cmd = new OleDbCommand(sqlCommand, dbConn);
            //    cmd.Parameters.AddWithValue("@imgDir", Session["selectedImageDir"]);

            //    OleDbDataReader dataReader = cmd.ExecuteReader();

            //    if (dataReader.HasRows)
            //    {
            //        while (dataReader.Read())
            //        {
            //            sqlCommand = "INSERT INTO [Item_in_cart] (Buyer_username, Item_img_dir, Item_name, item_price, Seller_username) VALUES (?, ?, ?, ?, ?)";
            //            cmd = new OleDbCommand(sqlCommand, dbConn);

            //            cmd.Parameters.AddWithValue("Buyer_username", Session["Username"]);
            //            cmd.Parameters.AddWithValue("Item_img_dir", dataReader.GetString(0));
            //            cmd.Parameters.AddWithValue("Item_name", dataReader.GetString(1));
            //            cmd.Parameters.AddWithValue("item_price", dataReader.GetDouble(2));
            //            cmd.Parameters.AddWithValue("Seller_username", dataReader.GetString(3));

            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //    dbConn.Close();
            //}
        }
    }
}
