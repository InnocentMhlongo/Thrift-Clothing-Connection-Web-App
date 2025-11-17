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
    public partial class Search : System.Web.UI.Page
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

                string sqlCommand = "SELECT * FROM [Clothing_item] WHERE (Item_name = @name OR Item_Brand = @brand OR Item_Type = @type OR Item_condition = @condition);";

                OleDbCommand cmd = new OleDbCommand(sqlCommand, dbConn);

                cmd.Parameters.AddWithValue("@name", Session["search"]);
                cmd.Parameters.AddWithValue("@brand", Session["search"]);
                cmd.Parameters.AddWithValue("@type", Session["search"]);
                cmd.Parameters.AddWithValue("@condition", Session["search"]);

                OleDbDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    ClothingItems.DataSource = dataReader;
                    ClothingItems.DataBind();
                }

                dbConn.Close();
            }
        }
        protected void ClothingItems_ItemCommand(object source, DataListCommandEventArgs e)
        {

            if (e.CommandName == "AddToCart")
            {
                string CS = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
                using (OleDbConnection dbConn = new OleDbConnection(CS))
                {
                    dbConn.Open();

                    string sqlCommand = "SELECT [Image_dir], [Item_name], [Item_price],[Seller_username] from [Clothing_item] WHERE Image_dir = ?";
                    OleDbCommand cmd = new OleDbCommand(sqlCommand, dbConn);
                    cmd.Parameters.AddWithValue("Image_dir", e.CommandArgument.ToString());

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
            }
            else if (e.CommandName == "GetItemDetails")
            {
                Session["selectedImageDir"] = e.CommandArgument.ToString();

                Response.Redirect("~/Admin/ViewItem.aspx");
            }
        }
    }
}
