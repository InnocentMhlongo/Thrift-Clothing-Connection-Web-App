using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace Thr_fty.Pages
{
    public partial class Index : System.Web.UI.Page
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
            string LoggedInUsername = Session["Username"] as string;

            if (string.IsNullOrEmpty(LoggedInUsername))
            {
                Response.Redirect("~/Pages/LogIn.aspx");
            }

            string CS = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
                using (OleDbConnection dbConn = new OleDbConnection(CS))
                {
                    dbConn.Open();

                    string sqlCommand = "SELECT [Item_Type], [Item_Brand], [item_Description], [Item_Size], [Image_dir], [Seller_username], [Item_name], [Item_condition], [Item_Price] FROM [Clothing_item]";

                    OleDbCommand cmd = new OleDbCommand(sqlCommand, dbConn);

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

