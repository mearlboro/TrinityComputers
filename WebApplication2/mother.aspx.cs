using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace WebStore
{
    public partial class mother : System.Web.UI.Page
    {
        Motherboard[] p = new Motherboard[10];
        Cart currentCart;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] == null)
                currentCart = new Cart();
            else
                currentCart = (Cart)Session["cart"];
    
            int i = 0;
            DataView dv = new DataView();
            dv = (DataView)AccessDataSource1.Select(DataSourceSelectArguments.Empty);

            DataTable dt = dv.ToTable();
            DataTableReader dr = dt.CreateDataReader();

            while (dr.Read())
            {
                try
                {
                    i++;
                    string[] item = new string[15];
                    for (int j = 0; j < dr.FieldCount; j++)
                        item[j] = dr[j].ToString();
                    p[i] = new Motherboard(item);

                    Label l = new Label();
                    l = new Label();
                    l.Height = 110;
                    l.Width = 230;
                    p[i].show(l);

                    Button b = new Button();
                    b.Text = "Buy";
                    b.ID = "b" + p[i].ID;
                    b.Click += new EventHandler(buyClick);

                    PlaceHolder place = new PlaceHolder();
                    place.Controls.Add(new LiteralControl(@"<td style='height: 300px; width: 270px'><a href='Img/" + item[0] + ".jpg' rel='lightbox'><img src='Img/" + item[0] + ".jpg' height=150 width=150 /></a><br />"));
                    place.Controls.Add(l);
                    place.Controls.Add(b);
                    place.Controls.Add(new LiteralControl("</td>"));

                    if (i % 3 == 1)
                        MainPlaceHolder.Controls.Add(new LiteralControl("<tr>"));
                    MainPlaceHolder.Controls.Add(place);
                    if (i % 3 == 0)
                        MainPlaceHolder.Controls.Add(new LiteralControl("</tr>"));
                }
                catch
                { }
            }

            if (i % 3 != 0)
                MainPlaceHolder.Controls.Add(new LiteralControl("</tr>"));
            
            MainPlaceHolder.Controls.Add(new LiteralControl("</table>"));
        }

        protected void buyClick(object sender, EventArgs e)
        {
            string senderBut = (((Button)sender).ID).ToString();
            string id = senderBut.Substring(1);
            currentCart.addObject(id);
            Session["cart"] = currentCart;
            Label LabelSum = (Label)Master.FindControl("LabelSum");
            LabelSum.Text = currentCart.calculatePrice() + "£";
        }
    }

}