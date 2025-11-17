using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thr_fty.Admin
{
    public partial class ListItemDescription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string loggedInUsername = Session["Username"] as string;
            if (string.IsNullOrEmpty(loggedInUsername))
            {
                Response.Redirect("~/Pages/LogIn.aspx");

            }
            else
            {
                PopulateDropDownLists();
            }
            
        }
        protected void PopulateDropDownLists()
        {
            dropDownSize.Items.Clear();

            string[] clothing_types = { "T-shirt", "Jeans", "Dress", "Sweater", "Skirt", "Jacket", "Shorts", "Hoodie", "Blouse", "Pants", "Sneaker" };
            if (dropDownType.Items.Count == 0)
            {
                for (int x = 0; x < clothing_types.Length; x++)
                {
                    dropDownType.Items.Add(clothing_types[x]);
                }
            }
            string[] legwear = { "Jeans", "Skirt", "Shorts", "Pants" };
            string[] topwear = { "T-shirt", "Dress", "Sweater", "Jacket", "Hoodie", "Blouse" };

            if (legwear.Contains(dropDownType.SelectedItem.Text))
            {
                string[] lowersizing = { "28", "30", "32", "34", "36", "38", "40", "42", "44", "46" };

                for (int x = 0; x < lowersizing.Length; x++)
                {
                    dropDownSize.Items.Add(lowersizing[x]);
                }
            }
            else if (topwear.Contains(dropDownType.SelectedItem.Text))
            {
                string[] uppersizing = { "XS", "S", "M", "L", "XL", "XXL", "XXXL" };
                for (int x = 0; x < uppersizing.Length; x++)
                {
                    dropDownSize.Items.Add(uppersizing[x]);
                }
            }
            else
            {
                string[] shoewearsizing = { "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
                for (int x = 0; x < shoewearsizing.Length; x++)
                {
                    dropDownSize.Items.Add(shoewearsizing[x]);
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Index.aspx");
        }

        protected void btnSavep1_Click(object sender, EventArgs e)
        {
            Session["itemName"] = txtDescription.Text;
            Session["itemBrand"] = txtBrand.Text;
            Session["itemType"] = dropDownType.SelectedItem.Text;
            Session["itemColour"] = txtColour.Text;
            Session["itemSize"] = dropDownSize.SelectedItem.Text;
            Session["itemDescription"] = txtAreaCondition.Text;
            Session["itemCondition"] = DropDownList1.SelectedValue;

            Response.Redirect("~/Admin/NewSubmit.aspx");
        }
    }
}