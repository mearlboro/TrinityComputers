using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;

namespace WebStore.Styles
{
    public class User
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private Cart[] orderHistory;
        public Cart[] OrderHistory
        {
            get { return orderHistory; }
            set { orderHistory = value; }
        }

        private Cart cart;
        public Cart Cart
        {
            get { return cart; }
            set { cart = value; }
        }
    };

}