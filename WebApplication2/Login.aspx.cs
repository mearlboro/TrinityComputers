using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.OleDb;
using System.Web.UI.WebControls;

namespace WebStore.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginUser_Authenticate(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
        {
            string user = LoginUser.UserName.ToLower();
            string pass = LoginUser.Password;

            e.Authenticated = UserLogin(user, pass);
        }

        private bool UserLogin(string user, string pass)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Z:\\info\\PROJECTS\\trinity_web\\WebApplication2\\baza.mdb");

            OleDbCommand select = new OleDbCommand("SELECT [Username], [Password] FROM [User] WHERE [Username] = @Username AND [Password] = @Password", conn);
            select.Parameters.AddWithValue("@Username", user);
            select.Parameters.AddWithValue("@Password", pass);
            conn.Open();

            string result = Convert.ToString(select.ExecuteScalar());
            return (!string.IsNullOrEmpty(result));
        }

       
        protected void LoginUser_LoggedIn(object sender, EventArgs e)
        {
            Session["userName"] = LoginUser.UserName;
            Session["password"] = LoginUser.Password;

            Label mpLabel = (Label)Master.FindControl("labelUsername");
            mpLabel.Text = Session["userName"].ToString();

            Response.Redirect("_user.aspx");
        
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

        }

    }
}
