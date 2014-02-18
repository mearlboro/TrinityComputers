using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebStore
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        Cart currentCart;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] != null)
            {
                currentCart = (Cart)Session["cart"];
                LabelSum.Text = currentCart.calculatePrice() + "£";
            }

            if (Session["username"] != null)
            {
                LabelUsername.Text = Session["username"].ToString();
            }
            else
            {
                linkUserpage.HRef = "Z:\\info\\PROJECTS\\trinity_web\\WebApplication2\\Account\\Login.aspx";
                LabelUsername.Text = "guest";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string keyword = TextBox1.Text.ToLower().Trim();
            if (keyword.Length > 1)
            {
                Session.Add("keyword", keyword);
                Response.Redirect("search_results.aspx");
            }            
        }

        protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["password"] = null;
            //if (Request.Url.AbsolutePath.Equals("/_user.aspx"))
                Response.Redirect("Z:\\info\\PROJECTS\\trinity_web\\WebApplication2\\home.aspx");
        }
    }
}