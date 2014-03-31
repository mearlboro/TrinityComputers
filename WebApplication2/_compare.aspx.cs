using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebStore
{
    public partial class _compare : System.Web.UI.Page
    {
        Cart currentCart;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["cart"] == null)
                currentCart = new Cart();
            else
                currentCart = (Cart)Session["cart"];

            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            string[] item = new String[15];
            for (int i = 1; i <= currentCart.CartSize; i++)
            {
                item = currentCart.getObject(currentCart.Contents[i]);
                string tz;
                if (currentCart.Contents[i] / 10 == 1 || currentCart.Contents[i] / 10 == 3 || currentCart.Contents[i] / 10 == 6)
                    tz = item[0] + " " + item[1] + " " + item[6] + " " + item[2];
                else
                    tz = item[0] + " " + item[1] + " " + item[2];
                DropDownList1.Items.Add(tz);
                DropDownList2.Items.Add(tz);
                Label1.Visible = false;
            }

            if (Page.IsPostBack)
            {
                if (DropDownList1.SelectedValue.Length != 0)
                {
                    int tz = int.Parse(DropDownList1.SelectedValue.Substring(0, 2));
                    if (Session["compareTo1"] == null)
                        Session.Add("compareTo1", tz);
                    else
                        Session["compareTo1"] = tz;
                    tz = int.Parse(DropDownList2.SelectedValue.Substring(0, 2));
                    if (Session["compareTo2"] == null)
                        Session.Add("compareTo2", tz);
                    else
                        Session["compareTo2"] = tz;

                    Label1.Visible = false;
                    int x = int.Parse(Session["compareTo1"].ToString());
                    int y = int.Parse(Session["compareTo2"].ToString());

                    if (x / 10 == y / 10)
                    {
                        showObject(x, PlaceHolder1);
                        showObject(y, PlaceHolder2);
                    }
                    else
                    {
                        Label1.Visible = true;
                    }
                }
            }

        }

        private void showObject(int x, PlaceHolder place)
        {
            place.Controls.Clear();
            string[] item = new string[15];
            item = currentCart.getObject(x);
            place.Controls.Add(new LiteralControl("<center>"));
            string addImage = "<a href='Img/" + x + ".jpg' rel='lightbox'><img src='Img/" + x + ".jpg' height=150 width=150 rel='lightbox' /></a><br />";
            place.Controls.Add(new LiteralControl(addImage));

            Label l = new Label();
            switch (x / 10)
            {
                case 1: { Processor p = new Processor(item); p.show(l); break; }
                case 2: { Motherboard p = new Motherboard(item); p.show(l); break; }
                case 3: { SoundCard p = new SoundCard(item); p.show(l); break; }
                case 4: { PowerSupplyUnit p = new PowerSupplyUnit(item); p.show(l); break; }
                case 5: { RAM p = new RAM(item); p.show(l); break; }
                case 6: { GraphicsCard p = new GraphicsCard(item); p.show(l); break; }
                case 7: { Storage p = new Storage(item); p.show(l); break; }
            }
            place.Controls.Add(l);
            place.Controls.Add(new LiteralControl("</center>"));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int tz = int.Parse(DropDownList1.SelectedValue.Substring(0, 2));
            if (Session["compareTo1"] == null)
                Session.Add("compareTo1", tz);
            else
                Session["compareTo1"] = tz;
            tz = int.Parse(DropDownList2.SelectedValue.Substring(0, 2));
            if (Session["compareTo2"] == null)
                Session.Add("compareTo2", tz);
            else
                Session["compareTo2"] = tz;
        
            Label1.Visible = false;
            int x = int.Parse(Session["compareTo1"].ToString());
            int y = int.Parse(Session["compareTo2"].ToString());

            if (x / 10 == y / 10)
            {
                Label l = new Label();
                showObject(x, PlaceHolder1);
                showObject(y, PlaceHolder2);
                string[] item = currentCart.getObject(x);
                string[] item1 = currentCart.getObject(y);

                switch (x / 10)
                {
                    case 1:
                        {
                            Processor p = new Processor(item);
                            Processor p1 = new Processor(item1);
                            if (p.compareTo(p1) == 1)
                                l.Text = p.Manufacturer + " " + p.Series + " has more performance than " + p1.Manufacturer + " " + " " + p1.Series;
                            else if (p.compareTo(p1) == 2)
                                l.Text = p.Manufacturer + " " + p.Series + " has less performance than " + p1.Manufacturer + " " + p1.Series;
                            else if (p.compareTo(p1) == 0)
                                l.Text = "The two are aproximately equally performant.";
                            break;
                        }
                    case 2:
                        {
                            Motherboard p = new Motherboard(item);
                            Motherboard p1 = new Motherboard(item1);
                            if (p.compareTo(p1) == 1)
                                l.Text = p.Manufacturer + " " + p.Series + " has more performance than " + p1.Manufacturer + " " + p1.Series;
                            else if (p.compareTo(p1) == 2)
                                l.Text = p.Manufacturer + " " + p.Series + " has less performance than " + p1.Manufacturer + " " + p1.Series;
                            else if (p.compareTo(p1) == 0)
                                l.Text = "The two are aproximately equally performant.";
                            break;
                        }
                    case 3:
                        {
                            SoundCard p = new SoundCard(item);
                            SoundCard p1 = new SoundCard(item1);
                            if (p.compareTo(p1) == 1)
                                l.Text = p.Manufacturer + " " + p.Series + " has more performance than " + p1.Manufacturer + " " + p1.Series;
                            else if (p.compareTo(p1) == 2)
                                l.Text = p.Manufacturer + " " + p.Series + " has less performance than " + p1.Manufacturer + " " + p1.Series;
                            else if (p.compareTo(p1) == 0)
                                l.Text = "The two are aproximately equally performant.";
                            break;
                        }
                    case 4:
                        {
                            PowerSupplyUnit p = new PowerSupplyUnit(item);
                            PowerSupplyUnit p1 = new PowerSupplyUnit(item1);
                            if (p.compareTo(p1) == 1)
                                l.Text = p.Manufacturer + " " + p.Series + " has more performance than " + p1.Manufacturer + " " +  p1.Series;
                            else if (p.compareTo(p1) == 2)
                                l.Text = p.Manufacturer + " " + p.Series + " has less performance than " + p1.Manufacturer + " " + p1.Series;
                            else if (p.compareTo(p1) == 0)
                                l.Text = "The two are aproximately equally performant.";
                            break;
                        }
                    case 5:
                        {
                            RAM p = new RAM(item);
                            RAM p1 = new RAM(item1);
                            if (p.compareTo(p1) == 1)
                                l.Text = p.Manufacturer + " " + p.Series + " has more performance than " + p1.Manufacturer + " " + p1.Series;
                            else if (p.compareTo(p1) == 2)
                                l.Text = p.Manufacturer + " " + p.Series + " has less performance than " + p1.Manufacturer + " " + p1.Series;
                            else if (p.compareTo(p1) == 0)
                                l.Text = "The two are aproximately equally performant.";
                            break;
                        }
                    case 6:
                        {
                            GraphicsCard p = new GraphicsCard(item);
                            GraphicsCard p1 = new GraphicsCard(item1);
                            if (p.compareTo(p1) == 1)
                                l.Text = p.Manufacturer + " " + p.Series + " has more performance than " + p1.Manufacturer + " " + p1.Series;
                            else if (p.compareTo(p1) == 2)
                                l.Text = p.Manufacturer + " " + p.Series + " has less performance than " + p1.Manufacturer + " " + p1.Series;
                            else if (p.compareTo(p1) == 0)
                                l.Text = "The two are aproximately equally performant.";
                            break;
                        }
                    case 7:
                        {
                            Storage p = new Storage(item);
                            Storage p1 = new Storage(item1);
                            if (p.compareTo(p1) == 1)
                                l.Text = p.Manufacturer + " " + p.Series + " has more performance than " + p1.Manufacturer + " " + p1.Series;
                            else if (p.compareTo(p1) == 2)
                                l.Text = p.Manufacturer + " " + p.Series + " has less performance than " + p1.Manufacturer + " " + p1.Series;
                            else if (p.compareTo(p1) == 0)
                                l.Text = "The two are aproximately equally performant.";
                            break;
                        }
                }
                PlaceHolder1.Controls.Add(l);
            }
            else
            {
                Label1.Visible = true;
            }
        }

       
    }
}