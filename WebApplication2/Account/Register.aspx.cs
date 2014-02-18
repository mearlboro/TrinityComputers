using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace WebStore.Account
{
    public partial class Register : System.Web.UI.Page
    {
        string encodedCart;

        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];

            if (Session["cart"] != null)
            {
                encodedCart = ((Cart)Session["cart"]).encode();
                Session["encodedCart"] = encodedCart;
            }
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            try
            {
                Session["username"] = RegisterUser.UserName;
                Session["password"] = RegisterUser.Password;
                Session["email"] = RegisterUser.Email;

                AccessDataSource1.Insert();
                AccessDataSource1.DataBind();
            }
            catch
            {
                Session["username"] = null;
                Session["password"] = null;
                Session["email"] = null;

                Label mpLabel = (Label)Master.FindControl("labelUsername");
                mpLabel.Text = Session["username"].ToString();
            }

            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }

        protected void RegisterUser_CreatingUser(object sender, LoginCancelEventArgs e)
        {

        }

    }
}
