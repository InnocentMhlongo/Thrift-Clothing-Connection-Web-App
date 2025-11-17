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
    public partial class BestSellers_Admin : System.Web.UI.Page
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

            string CS = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
            OleDbConnection dbConn = new OleDbConnection(CS);

            // Define the SQL command for sorting
            string sqlcommand1 = "SELECT [Username] AS [Username], [Seller_rating] AS [Rating] , [Accumulated_amount] AS [Amount]" +
                                 "FROM [USERS] ";

            // Check the selected sort option from DropDownList
            if (DropDownList1.SelectedValue == "1")
            {
                // Newest sorting
                sqlcommand1 += "ORDER BY [Accumulated_amount] DESC";
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                // Oldest sorting
                sqlcommand1 += "ORDER BY [Accumulated_amount] ASC";
            }

            else if (DropDownList2.SelectedValue == "1")
            {
                // Ascending sorting by Rating
                sqlcommand1 += "ORDER BY [Seller_rating] DESC";
            }
            else if (DropDownList2.SelectedValue == "2")
            {
                // Descending sorting by Rating
                sqlcommand1 += "ORDER BY [Seller_rating] ASC";
            }

            OleDbCommand cmd = new OleDbCommand(sqlcommand1, dbConn);
            dbConn.Open();
            OleDbDataReader User = cmd.ExecuteReader();
            GridView1.DataSource = User;
            GridView1.DataBind();
            dbConn.Close();

        }
        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Get the index of the current row (0-based)
                int rowIndex = e.Row.RowIndex;

                // Find the Label control that displays the username
                Label lblUsername = (Label)e.Row.FindControl("lblUsername");

                // Set the text of the Label to display the row number and username
                lblUsername.Text = (rowIndex + 1).ToString() + ". " + lblUsername.Text;
            }
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Call the BindGridViewData method to rebind the GridView with the selected sorting option
            BindGridViewData();
            DropDownList2.SelectedIndex = 0;
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Call the BindGridViewData method to rebind the GridView with the selected sorting option
            BindGridViewData();
            DropDownList1.SelectedIndex = 0;
        }
    }
}