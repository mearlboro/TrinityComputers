using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebStore
{
    public partial class thankyou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cart currentCart = (Cart)Session["cart"];
            string encoded;
            if (Session["history"] != null)
            {
                OrderHistory history = (OrderHistory)Session["history"];
                encoded = history.encodeOrderHistory() + currentCart.encode();
            }
            else
            {
                Session["history"] = new OrderHistory(currentCart);
                encoded = currentCart.encode();
            }
            
            Session["historyEncoded"] = encoded;
            Session["cartEncoded"] = "";

            AccessDataSource1.Update();

            currentCart.emptyCart();
            Session["cart"] = currentCart;

        }
    }
}