using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thr_fty.Pages
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LogoImg_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/Index.aspx");
        }
        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            Session["search"] = txtSearch.Text;
            Response.Redirect("~/Admin/Search.aspx");
        }
    }
}