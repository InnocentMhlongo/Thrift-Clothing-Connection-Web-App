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
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
            //    string username = Session["Username"] as string;

            //    if (username == "Risima" || username == "risima" || username == "RISIMA")
            //    {
            //        Response.Redirect("~/Admin_User/Index_Admin.aspx");
            //    }
            //    else if (username == "NkoT" || username == "NKOT" || username == "nkot")
            //    {
            //        Response.Redirect("~/Admin_User/Index_Admin.aspx");
            //    }
            //}
        }

        protected void btnLogInSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Session["Username"] = txtUsername.Text;
                string username = Session["Username"] as string;
                bool RememberMe = CheckBox1.Checked;

                string CS = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
                OleDbConnection dbConn = new OleDbConnection(CS);

                string sqlCommand = "SELECT * from [Users] WHERE [Username] = @name AND [Password] = @pass";

                OleDbCommand cmd = new OleDbCommand(sqlCommand, dbConn);

                cmd.Parameters.AddWithValue("@name", txtUsername.Text);
                FormsAuthentication.SetAuthCookie(username, RememberMe);
                string password = txtPassword.Text;
                cmd.Parameters.AddWithValue("@pass", password);

                OleDbDataAdapter valid = new OleDbDataAdapter();
                valid.SelectCommand = cmd;
                DataSet userSet = new DataSet();
                valid.Fill(userSet);

                if ((userSet).Tables[0].Rows.Count > 0)
                {
                    if (username == "Risima" || username == "risima" || username == "RISIMA")
                    {
                        Response.Redirect("~/Admin_User/Index_Admin.aspx");
                    }
                    else if (username == "NkoT" || username == "NKOT" || username == "nkot")
                    {
                        Response.Redirect("~/Admin_User/Index_Admin.aspx");
                    }
                    else
                    {
                        FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, true);
                    }
                }
                else
                    lblFeedback.Text = "Invalid username and/or password";
            }
            else
            {
                lblFeedback.Text = "There's a problem with the page";
            } 
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/SignUp.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Index.aspx");

        }

        
    }
}
    
