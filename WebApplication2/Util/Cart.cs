using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;

namespace WebStore
{
    public class Cart
    {

        private int[] contents = new int[100];
        private int cartSize = 0;
        
        public Cart() { }

        public Cart(string listOfContents)
        {
            int[] codes = new int[100];
            int l = 0;
            string[] products = listOfContents.Split(new char[] { '.', '#' });
            foreach (string p in products)
                codes[++l] = int.Parse(p);

            this.contents = codes;
            this.cartSize = l;
        }


        public int CartSize
        {
            get { return cartSize; }
            set { cartSize = value; }
        }

        public int[] Contents
        {
            get { return contents; }
            set { contents = value; }
        }


        public void addObject(string id)
        {
            contents[++cartSize] = int.Parse(id);
        }

        public void emptyCart()
        {
            for (int i = 1; i <= CartSize; i++)
                contents[i] = 0;
            CartSize = 0;
        }

        public float calculatePrice()
        {
            int price = 0;
            string[] item = new String[15];
            for (int i = 1; i <= cartSize; i++)
            {
                item = getObject(contents[i]);
                price += int.Parse(item[3]);
            }
            return price;
        }



        public string encode()
        {
           string encodedCart = "";
           foreach(int p in contents)
               encodedCart += "." + p;
           return encodedCart;
        }

       
        private void getInfo(int numberOfAttributes, string tableName, string[] objectData, int id)
        {
            AccessDataSource s;
            s = new AccessDataSource("baza.mdb", "SELECT * FROM [" + tableName + "] WHERE [ID]=" + id.ToString());
            DataView dv = new DataView();
            dv = (DataView)s.Select(DataSourceSelectArguments.Empty);
            DataTable dt = dv.ToTable();
            DataTableReader dr = dt.CreateDataReader();
            try
            {
                dr.Read();
                for (int i = 0; i <= numberOfAttributes; i++)
                    objectData[i] = dr[i].ToString();
            }
            catch
            { }
        }

        public string[] getObject(int id)
        {
            string[] objectData = new String[15];

            switch (id / 10)
            {
                case 1:
                    {
                        getInfo(9, "Procesor", objectData, id);
                        break;
                    }
                case 2:
                    {
                        getInfo(13, "PlacaDeBaza", objectData, id);
                        break;
                    }
                case 3:
                    {
                        getInfo(7, "PlacaSunet", objectData, id);
                        break;
                    }
                case 4:
                    {
                        getInfo(7, "Sursa", objectData, id);
                        break;
                    }
                case 5:
                    {
                        getInfo(7, "MemorieRAM", objectData, id);
                        break;
                    }
                case 6:
                    {
                        getInfo(10, "PlacaVideo", objectData, id);
                        break;
                    }
                case 7:
                    {
                        getInfo(7, "DVDPlayer", objectData, id);
                        break;
                    }
                case 8:
                    {
                        getInfo(8, "Stocare", objectData, id);
                        break;
                    }
            }
            return objectData;
        }

        
        public int getItemPrice(string id)
        {
            string[] item = getObject(int.Parse(id));
            return int.Parse(item[3]);
        }



        public void displayItem(PlaceHolder PlaceHolder1, int id)
        {
            string[] pages = new string[9] { "", "cpu.aspx", "mother.aspx", "audio.aspx", "ups.aspx", "ram.aspx", "graphics.aspx", "dvd.aspx", "hdd.aspx" };
            string[] item = new String[15];
 
            PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp&nbsp;&nbsp&nbsp;&nbsp"));
 
            item = getObject(id);
            System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
            img.Height = img.Width = 70;
            img.ImageUrl = "Img/" + id + ".jpg";
            HyperLink l = new HyperLink();
            l.NavigateUrl = pages[id / 10];
            PlaceHolder1.Controls.Add(img);
            PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp"));
            
            if (id / 10 == 1 || id / 10 == 3 || id / 10 == 6)
                l.Text = item[1] + " " + item[6] + " " + item[2];
            else
                l.Text = item[1] + " " + item[2];
            
            PlaceHolder1.Controls.Add(l);

        }

        public void displayCartContents(PlaceHolder PlaceHolder1)
        {
            if (cartSize == 0)
                PlaceHolder1.Controls.Add(new LiteralControl("There are currently no items in your cart. Start shopping!<br /><br />"));

            for (int i = 1; i <= cartSize; i++)
            {
                displayItem(PlaceHolder1, contents[i]);
                PlaceHolder1.Controls.Add(new LiteralControl("<br /><br />"));
            }
            PlaceHolder1.Controls.Add(new LiteralControl("<br />Total: " + calculatePrice() + "£"));
        }
    };



    public class OrderHistory 
    {
        private Cart[] history = new Cart[100];
        private int numberOfOrders = 0;

        public OrderHistory(string code)
        {
            string[] codes = code.Split('#');
            foreach (string c in codes)
                if (c != "")
                {
                    Cart cart = new Cart(c);
                    history[++numberOfOrders] = cart;
                }
        }

        public OrderHistory(Cart cart)
        {
            this.history = new Cart[1] { cart };
            this.numberOfOrders = 1;
        }

        public void displayOrderHistory(PlaceHolder p)
        {
            for (int i = 1; i <= numberOfOrders; i++)
            {
                p.Controls.Add(new LiteralControl("<br /><u>Order #" + i + "</u><br />"));
                history[i].displayCartContents(p);
            }
        }

        public string encodeOrderHistory()
        {
            string encoded = "";
            foreach (Cart c in history)
            {
                encoded += c.encode() + "#";
            }
            return encoded;
        }

    }

}