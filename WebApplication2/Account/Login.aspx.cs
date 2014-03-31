using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using System.Data;

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

            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=baza.mdb");

            OleDbCommand select = new OleDbCommand("SELECT * FROM [User] WHERE [Username] = @Username AND [Password] = @Password", conn);
            select.Parameters.AddWithValue("@Username", user);
            select.Parameters.AddWithValue("@Password", pass);

            try
            {
                conn.Open();
            }
            catch
            {
                return false;
            }

            OleDbDataAdapter da = new OleDbDataAdapter(select);

            DataSet ds = new DataSet();

            da.Fill(ds);
            if (ds.Tables[0].Rows[0] == null)
                return false;

            Session["username"] = LoginUser.UserName;
            Session["password"] = LoginUser.Password;
            Session["email"] = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            
            string address = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            if (address.Length != 0)
                Session["address"] = address;
            
            string cart = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            if (cart.Length != 0)
                Session["cart"] = new Cart(cart);
            
            string history = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            if (history.Length != 0)
                Session["history"] = new OrderHistory(history);

            return true;
        }
       
        protected void LoginUser_LoggedIn(object sender, EventArgs e)
        {
            Label mpLabel = (Label)Master.FindControl("labelUsername");
            mpLabel.Text = Session["username"].ToString();

            Response.Redirect("..//_user.aspx");
        
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

        }

    }
}
