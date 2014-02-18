using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebStore
{
    public partial class _cart : System.Web.UI.Page
    {
        Cart currentCart;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] == null)
                currentCart = new Cart();
            else
                currentCart = (Cart)Session["cart"];

         
            if (currentCart.CartSize != 0)
            {
                LabelTotal.Text = "Total: " + currentCart.calculatePrice() + " £";
                LabelTotal.Visible = true;
                LabelEmpty.Text = "";

                currentCart.displayCartContents(PlaceHolder1);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            currentCart.emptyCart();
            Response.Redirect(Request.RawUrl);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            if (currentCart.CartSize != 0)
                Response.Redirect("thankyou.aspx");
        }
    }
}