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
    public partial class ViewPurchases : System.Web.UI.Page
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
                string sqlcommand1 = "SELECT [Picture_data] AS [ImgDir], [Product_name] AS [ItemName], [Seller_username] AS [SellerUsername],[Price] AS [Price] FROM [PURCHASE] WHERE [Buyer_username] = @Username";

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
                    lblMessage2.Text = "You have no purchases";
                }


                dbConn.Close();


            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Call the BindGridViewData method to rebind the GridView with the selected sorting option
            BindGridViewData();
        }
        // Event handler for the "Rate" button click
        protected void btnRate_Click(object sender, EventArgs e)
        {
            // Get the data associated with the clicked row
            GridViewRow clickedRow = (GridViewRow)((Button)sender).NamingContainer;
            string productName = ((Label)clickedRow.FindControl("productName")).Text;
            string sellerUsername = ((Label)clickedRow.FindControl("productSeller")).Text;

            // Store the data in Session variables
            Session["ProductName"] = productName;
            Session["SellerUsername"] = sellerUsername;

            // Redirect to the "RateTheSeller.aspx" page
            Response.Redirect("~/Admin/RateTheSeller.aspx");
        }

    }
}