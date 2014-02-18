using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebStore
{
    public partial class _user : System.Web.UI.Page
    {

        Cart currentCart;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                string user = Session["username"].ToString();
                string email = Session["email"].ToString();

                PlaceHolderInfo.Controls.Add(new LiteralControl("Welcome, <b>" + user + "</b>! (<i>" + email + "</i>)<br /><br />"));

                if (Session["cart"] == null)
                    currentCart = new Cart();
                else
                    currentCart = (Cart)Session["cart"];
                PlaceHolderCart.Controls.Add(new LiteralControl("MY CART:<br />"));
                currentCart.displayCartContents(PlaceHolderCart);

                if (Session["history"] == null)
                    PlaceHolderHistory.Controls.Add(new LiteralControl("No order history to display"));
                else
                {
                    PlaceHolderCart.Controls.Add(new LiteralControl("MY ORDER HISTORY:<br />"));
                    ((OrderHistory)Session["history"]).displayOrderHistory(PlaceHolderHistory);
                }
            }
        }
    }

}