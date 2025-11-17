using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Web.Security;

namespace Thr_fty.Admin
{
    public partial class SetPrice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GetRecoPrice();
            CalculateAndDisplayRecommendedPrice();

        }
        protected void CalculateAndDisplayRecommendedPrice()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Create a SQL query to retrieve the average price for items with Item_name containing a specific keyword
                string sqlQuery = "SELECT AVG(Price) AS AveragePrice FROM Purchase WHERE Product_name LIKE '%' + @Keyword + '%'";

                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, connection))
                {


                    // Specify the keyword or phrase to search for
                    string keyword = Session["itemName"] as string;
                    cmd.Parameters.AddWithValue("@Keyword", keyword);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Check if there is data for the selected clothing type
                            if (reader["AveragePrice"] != DBNull.Value)
                            {
                                double averagePrice = Convert.ToDouble(reader["AveragePrice"]);
                                lblRecoPrice.Text = "The recommended price is R" + averagePrice.ToString("0.00");
                            }
                            else
                            {
                                lblRecoPrice.Text = "You are the first person to list this item";
                            }
                        }
                    }
                }
            }
        }


        protected void btnBackp3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/NewSubmit.aspx");
        }
       
        protected void btnSavep3_Click(object sender, EventArgs e)
        {
            Bind();
        }
        protected void Bind()
        {
            string CS = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
            using (OleDbConnection dbConn = new OleDbConnection(CS))
            {
                dbConn.Open();

                string insertQuery = "INSERT INTO [Clothing_item] (Seller_username, Item_name, Item_type, Item_brand, Item_Description, Item_size, Item_price, Image_dir, Item_condition) VALUES (@sellerID, @name, @type, @brand, @descr, @size, @price, @pic, @condition)";

                using (OleDbCommand cmd = new OleDbCommand(insertQuery, dbConn))
                {
                    cmd.Parameters.AddWithValue("@sellerID", Session["Username"]);
                    cmd.Parameters.AddWithValue("@name", Session["itemName"]);
                    cmd.Parameters.AddWithValue("@type", Session["itemType"]);
                    cmd.Parameters.AddWithValue("@brand", Session["itemBrand"]);
                    cmd.Parameters.AddWithValue("@descr", Session["itemDescription"]); 
                    cmd.Parameters.AddWithValue("@size", Session["itemSize"]);
                    cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@pic", Session["ImageDir"]);
                    cmd.Parameters.AddWithValue("@condition", Session["itemCondition"]);

                    cmd.ExecuteNonQuery();

                }
                dbConn.Close();

                Response.Write("<script>alert('Item listed successfully')</script>");
                Response.Redirect("~/Pages/Index.aspx");

            }
        }

       


        //protected void GetRecoPrice()
        //{
        //    string CS = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
        //    using (OleDbConnection dbConn = new OleDbConnection(CS))
        //    {
        //        dbConn.Open();

        //        string sqlCommand = "SELECT AVG(Item_price) AS 'RecoPrice' from [Clothing_item] WHERE Item_type = @type and Item_brand = @brand and Item_condition = @condi and Item_size = @size";

        //        OleDbCommand cmd = new OleDbCommand(sqlCommand, dbConn);

        //        cmd.Parameters.AddWithValue("@type", Session["itemType"]);
        //        cmd.Parameters.AddWithValue("@brand", Session["itemBrand"]);
        //        cmd.Parameters.AddWithValue("@condi", Session["itemCondition"]);
        //        cmd.Parameters.AddWithValue("@size", Session["itemSize"]);
        //        OleDbDataReader dataReader = cmd.ExecuteReader();

        //        if (dataReader.HasRows)
        //        {
        //            while (dataReader.Read())
        //            {
        //                lblRecoPrice.Text = "Coming soon";
        //            }
        //        }
        //        else
        //            lblRecoPrice.Text = "You are the first person to list this item on our platform";
        //        dbConn.Close();
        //    }
        //}
    }
}