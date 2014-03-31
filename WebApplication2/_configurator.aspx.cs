using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebStore
{
    public partial class configurator : System.Web.UI.Page
    {
        Cart currentCart;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] == null)
                currentCart = new Cart();
            else
                currentCart = (Cart)Session["cart"];

            DropDownList3.Items.Clear();
            string[] item = new String[15];
            for (int i = 1; i <= currentCart.CartSize; i++)
            {
                item = currentCart.getObject(currentCart.Contents[i]);
                string tz;
                if (currentCart.Contents[i] / 10 == 1 || currentCart.Contents[i] / 10 == 3 || currentCart.Contents[i] / 10 == 6)
                    tz = item[0] + " " + item[1] + " " + item[6] + " " + item[2];
                else
                    tz = item[0] + " " + item[1] + " " + item[2];
                int tip=int.Parse(item[0])/10;
                if (tip == 1 || tip == 2 || tip == 5 || tip == 6)
                    DropDownList3.Items.Add(tz);
            }

            if (Page.IsPostBack)
            {
                if (DropDownList3.SelectedValue.Length != 0)
                {
                    int tipPiesaCurenta = int.Parse(DropDownList3.SelectedValue.Substring(0, 2)) / 10;
                    int piesaCurenta = int.Parse(DropDownList3.SelectedValue.Substring(0, 2)) % 10;
                    if (Session["tipPiesa"] == null)
                        Session.Add("tipPiesa", tipPiesaCurenta);
                    else
                        Session["tipPiesa"] = tipPiesaCurenta;
                    if (Session["piesa"] == null)
                        Session.Add("piesa", piesaCurenta);
                    else
                        Session["piesa"] = piesaCurenta;
                    if (TextBox2.Text.Length != 0)
                    {
                        if (Session["pret"] == null)
                            Session.Add("pret", TextBox2.Text);
                        else
                            Session["pret"] = TextBox2.Text;
                    }
                    else
                    {
                        if (Session["pret"] == null)
                            Session.Add("pret", 0);
                        else
                            Session["pret"] = 0;
                    }
                   // backtracking(int.Parse(Session["tipPiesa"].ToString()), int.Parse(Session["piesa"].ToString()));
                }
            }
        }


        private void configBuyClick(object sender, EventArgs e)
        {
            string id=((Button)sender).ID;
            if (int.Parse(Session["tipPiesa"].ToString()) != 1)
                currentCart.addObject("1" + id.Substring(0, 1));
            if (int.Parse(Session["tipPiesa"].ToString()) != 2)
                currentCart.addObject("2" + id.Substring(1, 1));
            if (int.Parse(Session["tipPiesa"].ToString()) != 5)
                currentCart.addObject("5" + id.Substring(2, 1));
            if (int.Parse(Session["tipPiesa"].ToString()) != 6)
                currentCart.addObject("6" + id.Substring(3, 1));
            Response.Redirect("_cart.aspx");
        }

        void afisareConfig()
        {
            int pret = currentCart.getItemPrice("1" + v[1]) + currentCart.getItemPrice("2" + v[2]) + currentCart.getItemPrice("5" + v[5]) + currentCart.getItemPrice("6" + v[6]);
            if (int.Parse(Session["pret"].ToString()) > pret || int.Parse(Session["pret"].ToString())==0)
            {
                currentCart.displayItem(listPlaceHolder, 10 + v[1]);
                currentCart.displayItem(listPlaceHolder, 20 + v[2]);
                listPlaceHolder.Controls.Add(new LiteralControl("<br /><br />"));
                currentCart.displayItem(listPlaceHolder, 50 + v[5]);
                currentCart.displayItem(listPlaceHolder, 60 + v[6]);
                listPlaceHolder.Controls.Add(new LiteralControl("<br /><br />"));
                Label l = new Label();
                l.Text = "preţ: " + pret + " lei";
                Button b = new Button();
                b.ID = v[1].ToString() + v[2] + v[5] + v[6];
                b.Text = "Cumpără configuraţia";
                b.Click += new EventHandler(configBuyClick);
                listPlaceHolder.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;"));
                listPlaceHolder.Controls.Add(l);
                listPlaceHolder.Controls.Add(b);
                listPlaceHolder.Controls.Add(new LiteralControl("<br /><br />"));
            }
        }
        
        bool valid(int k, int tip, int id)
        {
            if (k >= tip && v[tip] != id)
                return false;

            string[] item = new string[15];
            if (k >= 2)
            {
                item = currentCart.getObject(10 + v[1]);
                Processor cpu = new Processor(item);
                item = currentCart.getObject(20 + v[2]);
                Motherboard mother = new Motherboard(item);
                if (!cpu.compatibility(mother))
                    return false;
            }
            if (k >= 5)
            {

                item = currentCart.getObject(50 + v[5]);
                RAM ram = new RAM(item);
                item = currentCart.getObject(20 + v[2]);
                Motherboard mother = new Motherboard(item);
                if (!ram.compatibility(mother))
                    return false;
            }
            if (k >= 6)
            {
                item = currentCart.getObject(60 + v[6]);
                GraphicsCard vid = new GraphicsCard(item);
                item = currentCart.getObject(20 + v[2]);
                Motherboard mother = new Motherboard(item);
                if (!vid.compatibility(mother))
                    return false;
            }
            return true;
        }

        int k = 1;
        int[] v=new int[10];

        
      /*  void backtracking(int tip, int id)
        {
            v[k]=0;
            while(k>0)
            {
                while (v[k] < Cart.Stock[k])
                {
                    v[k]++;
                    if (valid(k,tip,id))
                        if (k == 8)
                            afisareConfig();
                        else
                            v[++k] = 0;
                }
                k--;
            }
        }*/

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedValue.Length != 0)
            {
                int tipPiesaCurenta = int.Parse(DropDownList3.SelectedValue.Substring(0, 2)) / 10;
                int piesaCurenta = int.Parse(DropDownList3.SelectedValue.Substring(0, 2)) % 10;
                if (Session["tipPiesa"] == null)
                    Session.Add("tipPiesa", tipPiesaCurenta);
                else
                    Session["tipPiesa"] = tipPiesaCurenta;
                if (Session["piesa"] == null)
                    Session.Add("piesa", piesaCurenta);
                else
                    Session["piesa"] = piesaCurenta;
                if (Session["pret"] == null)
                    Session.Add("pret", TextBox2.Text);
                else
                    Session["pret"] = TextBox2.Text;

                // backtracking(int.Parse(Session["tipPiesa"].ToString()), int.Parse(Session["piesa"].ToString()));
            }
        }
    }
}