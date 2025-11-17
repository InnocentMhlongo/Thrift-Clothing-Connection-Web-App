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
    public partial class UpdatePersonalDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridViewData();
                BindGridViewData2();
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
                string sqlcommand1 = "SELECT [Username] AS [Username], [Mobile_number] AS [MobileNumber], [Email_address] AS [EmailAddress], [First_name] AS [FirstName],[Last_name] AS [LastName] FROM [USERS] WHERE [Username] = @Username";
                OleDbCommand cmd = new OleDbCommand(sqlcommand1, dbConn);
                cmd.Parameters.AddWithValue("@Username", Session["Username"]);
                dbConn.Open();
                OleDbDataReader User = cmd.ExecuteReader();
                GridView1.DataSource = User;
                GridView1.DataBind();
                dbConn.Close();
            }
        }

        private void BindGridViewData2()
        {
            string loggedInUsername = Session["Username"] as string;
            if (string.IsNullOrEmpty(loggedInUsername))
            {
                Response.Redirect("~/Pages/LogIn.aspx");

            }
            else
            {
                string CS = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
                OleDbConnection dbConn2 = new OleDbConnection(CS);
                string sqlcommand2 = "SELECT [Username] AS [Username],[Password] AS [Password] FROM [USERS] WHERE [Username] = @Username";
                OleDbCommand cmd = new OleDbCommand(sqlcommand2, dbConn2);
                cmd.Parameters.AddWithValue("@Username", Session["Username"]);
                dbConn2.Open();
                OleDbDataReader User = cmd.ExecuteReader();
                GridView2.DataSource = User;
                GridView2.DataBind();
                dbConn2.Close();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridViewData();
        }
        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            BindGridViewData2();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];

              string updatedUsername = ((Label)row.FindControl("lblUsername")).Text; 
              string updatedMobileNumber = ((TextBox)row.FindControl("txtMobileNumber")).Text;
              string updatedEmailAddress = ((TextBox)row.FindControl("txtEmailAddress")).Text;
              string updatedFirstName = ((TextBox)row.FindControl("txtFirstName")).Text;
              string updatedLastName = ((TextBox)row.FindControl("txtLastName")).Text;

          
            string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {

                    connection.Open();

                    string selectEmailQuery = "SELECT COUNT(*) FROM [Users] WHERE Email_address = @Email AND Username <> @Username";
                    string selectMobileQuery = "SELECT COUNT(*) FROM [Users] WHERE Mobile_number = @Mobile AND Username <> @Username";


                    using (OleDbCommand cmdEmail = new OleDbCommand(selectEmailQuery, connection))
                    using (OleDbCommand cmdMobile = new OleDbCommand(selectMobileQuery, connection))
                    {

                        cmdEmail.Parameters.AddWithValue("@Email", updatedEmailAddress);
                        cmdEmail.Parameters.AddWithValue("@Username", updatedUsername);

                        cmdMobile.Parameters.AddWithValue("@Mobile", updatedMobileNumber);
                        cmdMobile.Parameters.AddWithValue("@Username", updatedUsername);


                        int emailCount = (int)cmdEmail.ExecuteScalar();
                        int mobileCount = (int)cmdMobile.ExecuteScalar();

                        if (emailCount > 0)
                        {
                            lblFeedback.Text = "Email is connected to an account";
                        }
                        else if (mobileCount > 0)
                        {
                            lblFeedback.Text = "Mobile number is already registered";
                        }
                        else
                        {
                            string updateQuery = "UPDATE USERS SET Mobile_number = @MobileNumber, Email_address = @EmailAddress, First_name = @FirstName, Last_name = @LastName WHERE Username = @Username ";

                            using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                            {

                                command.Parameters.AddWithValue("@MobileNumber", updatedMobileNumber);
                                command.Parameters.AddWithValue("@EmailAddress", updatedEmailAddress);
                                command.Parameters.AddWithValue("@FirstName", updatedFirstName);
                                command.Parameters.AddWithValue("@LastName", updatedLastName);
                                command.Parameters.AddWithValue("@Username", updatedUsername);

                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    string script = "showItemAddedAlert();";

                                    // Register the script for execution
                                    ClientScript.RegisterStartupScript(this.GetType(), "showItemAddedAlert", script, true);
                                    GridView1.EditIndex = -1;
                                    BindGridViewData();
                                }
                                else
                                {
                                    string script = "showItemAddedAlert2();";

                                    // Register the script for execution
                                    ClientScript.RegisterStartupScript(this.GetType(), "showItemAddedAlert", script, true);
                                    GridView1.EditIndex = -1;
                                    BindGridViewData();
                                }
                            }
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Response.Write("<script>alert('An error occurred: " + ex.Message + "')</script>");
            }
            
        }
        public string HashPasswordSHA1(string password)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] hashedBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                //foreach (byte b in hashedBytes)
                //{
                //    builder.Append(b.ToString("x2")); // Convert to hexadecimal representation
                //}
                return builder.ToString();
            }
        }
        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView2.Rows[e.RowIndex];

                string updatedUsername = ((Label)row.FindControl("lblUsername")).Text;
                string enteredOldPassword = ((TextBox)row.FindControl("txtOldPassword")).Text; // Get the entered old password

                string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Retrieve the old hashed password from the database
                    string selectOldPasswordQuery = "SELECT [Password] FROM [Users] WHERE [Username] = @Username";
                    using (OleDbCommand selectCommand = new OleDbCommand(selectOldPasswordQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@Username", updatedUsername);
                        string oldHashedPassword = selectCommand.ExecuteScalar() as string;

                        // Hash the entered old password for comparison
                        string hashedEnteredOldPassword = (enteredOldPassword);

                        // Compare the entered old password with the stored old hashed password
                        if (hashedEnteredOldPassword == oldHashedPassword)
                        {
                            // The old password is correct; proceed to update the password
                            string updatedPassword = ((TextBox)row.FindControl("txtPassword")).Text;
                            string hashedPassword = (updatedPassword);

                            string updateQuery = "UPDATE USERS SET [Password] = @Password WHERE Username = @Username";

                            using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                            {
                                command.Parameters.AddWithValue("@Password", hashedPassword);
                                command.Parameters.AddWithValue("@Username", updatedUsername);

                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    string script = "showItemAddedAlert3();";

                                    // Register the script for execution
                                    ClientScript.RegisterStartupScript(this.GetType(), "showItemAddedAlert", script, true);
                                    GridView2.EditIndex = -1;
                                    BindGridViewData();
                                }
                                else
                                {
                                    string script = "showItemAddedAlert4();";

                                    // Register the script for execution
                                    ClientScript.RegisterStartupScript(this.GetType(), "showItemAddedAlert", script, true);
                                    GridView2.EditIndex = -1;
                                    BindGridViewData();
                                }
                            }
                        }
                        else
                        {
                            // The entered old password is incorrect
                            lblFeedback.Text = "Incorrect password";
                            GridView2.EditIndex = -1;
                            BindGridViewData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Response.Write("<script>alert('An error occurred: " + ex.Message + "')</script>");
            }
        }




        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancel the edit mode
            GridView1.EditIndex = -1;
            BindGridViewData(); // Rebind the GridView to show the original data
        }
        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancel the edit mode
            GridView2.EditIndex = -1;
            BindGridViewData2(); // Rebind the GridView to show the original data
        }

    }

}