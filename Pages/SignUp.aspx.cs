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

namespace Thr_fty.Pages
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {


            if (Page.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;

                using (OleDbConnection dbConn = new OleDbConnection(connectionString))
                {
                    dbConn.Open();

                    string selectUsernameQuery = "SELECT COUNT(*) FROM [Users] WHERE Username = @Username";
                    string selectEmailQuery = "SELECT COUNT(*) FROM [Users] WHERE Email_address = @Email";
                    string selectMobileQuery = "SELECT COUNT(*) FROM [Users] WHERE Mobile_number = @Mobile";

                    using (OleDbCommand cmdUsername = new OleDbCommand(selectUsernameQuery, dbConn))
                    using (OleDbCommand cmdEmail = new OleDbCommand(selectEmailQuery, dbConn))
                    using (OleDbCommand cmdMobile = new OleDbCommand(selectMobileQuery, dbConn))
                    {
                        {
                            cmdUsername.Parameters.AddWithValue("@Username", txtUsername.Text);
                            cmdEmail.Parameters.AddWithValue("@Email", txtEmail.Text);
                            cmdMobile.Parameters.AddWithValue("@Mobile", txtMobile.Text);


                            int usernameCount = (int)cmdUsername.ExecuteScalar();
                            int emailCount = (int)cmdEmail.ExecuteScalar();
                            int mobileCount = (int)cmdMobile.ExecuteScalar();

                            if (usernameCount > 0)
                            {
                                lblFeedback.Text = "Username has been taken";
                            }
                            else if (emailCount > 0)
                            {
                                lblFeedback.Text = "Email is connected to an account";
                            }
                            else if (mobileCount > 0)
                            {
                                lblFeedback.Text = "Mobile number is already registered";
                            }
                            else
                            {
                                string insertQuery = "INSERT INTO [Users] ([Username], [Mobile_number], [Email_address], [First_name], [Last_name], [Password]) VALUES (@Username, @Mobile, @Email, @First, @Last, @Password)";

                                using (OleDbCommand cmdInsert = new OleDbCommand(insertQuery, dbConn))
                                {
                                    cmdInsert.Parameters.AddWithValue("@Username", txtUsername.Text);
                                    cmdInsert.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                                    cmdInsert.Parameters.AddWithValue("@Email", txtEmail.Text);
                                    cmdInsert.Parameters.AddWithValue("@First", txtFirstname.Text);
                                    cmdInsert.Parameters.AddWithValue("@Last", txtLastname.Text);

                                    string hashedPassword = txtPassword.Text;
                                    cmdInsert.Parameters.AddWithValue("@Password", hashedPassword);

                                    int rowsAffected = cmdInsert.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        lblFeedback.Text= "Registration successful. Click <a href='LogIn.aspx'>here</a> to log in.";
                                        txtFirstname.Text = "";
                                        txtEmail.Text = "";
                                        txtLastname.Text = "";
                                        txtMobile.Text = "";
                                        txtUsername.Text = "";

                                    }
                                    else
                                    {
                                        lblFeedback.Text = "Error occurred while creating the account.";
                                    }
                                    string script = "showItemAddedAlert();";

                                    // Register the script for execution
                                    ClientScript.RegisterStartupScript(this.GetType(), "showItemAddedAlert", script, true);
                                  
                                }

                               
                            }
                        }
                    }
                }
            }
        }

       
    }
}