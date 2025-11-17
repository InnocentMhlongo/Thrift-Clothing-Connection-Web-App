using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.OleDb;
using System.Web.Security;


namespace Thr_fty.Admin
{
    public partial class SubmitPicture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (FileUpload1.HasFiles)
                {
                   
                
                }
                else
                {
                    
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ListItemDescription.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFiles)
            {
                try
                {
                    
                    string username = Session["Username"].ToString();

                    string fname = Path.GetFileName(FileUpload1.FileName);

                    // Check if the file extension is one of the allowed picture formats
                    string fileExtension = Path.GetExtension(fname).ToLower();
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

                    if (Array.Exists(allowedExtensions, ext => ext == fileExtension))
                    {
                        // Get the current date and time
                        string currentDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");

                        // Create a filename using the username and formatted date and time
                        string newFileName = $"{username}{currentDateTime}{fileExtension}";

                        // Define the directory where you want to save the pictures
                        string saveDirectory = Server.MapPath("~/Images/");

                        // Combine the directory and new filename to get the full path
                        string filePath = Path.Combine(saveDirectory, newFileName);

                        FileUpload1.SaveAs(filePath);

                        Session["ImageDir"] = newFileName;
                        Response.Redirect("~/Admin/SetPrice.aspx");
                    }
                    else
                    {
                        lblFeedback.Text = "Invalid file format. Please upload a picture (jpg, jpeg, png, gif, or bmp).";
                    }
                }
                catch (Exception ex)
                {
                    lblFeedback.Text = "The file could not be uploaded. The following error occurred: " + ex.Message;
                }
            }
            else
            {
                lblFeedback.Text = "Upload picture";
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            // Check if a file has been uploaded
            if (FileUpload1.HasFile)
            {
                try
                {

                    // Delete the uploaded file from the server
                    string filePath = Path.GetFileName(FileUpload1.FileName);
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    // Clear the FileUpload control
                    FileUpload1.FileContent.Dispose();
                    FileUpload1.FileContent.Close();
                    FileUpload1.PostedFile.InputStream.Close();
                    FileUpload1.PostedFile.InputStream.Dispose();
                    FileUpload1.Dispose();
                    FileUpload1.Attributes.Clear();
                    FileUpload1.PostedFile.InputStream.Flush();

                    // Clear the session variable
                    Session.Remove("ImageDir");

                    // Redirect to the same page or another page as needed
                    Response.Redirect(Request.Url.AbsoluteUri);
                    lblFeedback.Text = "Picture removed successfully";
                }
                catch (Exception Ex)
                {
                    lblFeedback.Text = "An error occurred while removing the uploaded file: " + Ex.Message;
                }
            }
            else
            {
                lblFeedback.Text = "No file has been uploaded.";
            }
        }

    }
}