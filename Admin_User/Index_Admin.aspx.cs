using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;

namespace Thr_fty.Admin_User
{
    public partial class Index_Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridViewData();
            }

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Call the BindGridViewData method to rebind the GridView with the selected sorting option
            BindGridViewData();
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
                string sqlcommand1 = "SELECT [Picture_data] AS [ImgDir], [Product_name] AS [ItemName], [Buyer_username] AS [BuyerUsername], [Seller_username] AS [SellerUsername], [Price] AS [Price] FROM [PURCHASE]";

                // Check the selected sort option from DropDownList
                if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "Sort")
                {
                    // Newest sorting
                    sqlcommand1 += " ORDER BY [Date] DESC";
                }
                else if (DropDownList1.SelectedValue == "2")
                {
                    // Oldest sorting
                    sqlcommand1 += " ORDER BY [Date] ASC";
                }

                OleDbCommand cmd = new OleDbCommand(sqlcommand1, dbConn);
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
                    lblMessage2.Text = "There are no sales";
                }

                dbConn.Close();
                
            }
        }
    }
}