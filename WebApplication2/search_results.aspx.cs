using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebStore
{
    public partial class search_results : System.Web.UI.Page
    {
        Cart currentCart;

        string[] pages = new string[9] { "", "cpu.aspx", "mother.aspx", "video.aspx", "surse.aspx", "ram.aspx", "video.aspx", "dvd.aspx", "stocare.aspx" };

        AccessDataSource a;
        string select = "SELECT * FROM ";
        string[] item = new string[15];

        protected void buyClick(object sender, EventArgs e)
        {
            string tz = (((Button)sender).ID).ToString();
            string id = tz.Substring(1);
            currentCart.addObject(id);
            Session["cart"] = currentCart;
            Label LabelSum = (Label)Master.FindControl("LabelSum");
            LabelSum.Text = currentCart.calculatePrice() + "£";

        }

        bool find(string key)
        {
            string keyword = Session["keyword"].ToString().ToLower();
            if (key.CompareTo(keyword) == 0)
                return true;
            return false;
        }

        void searchInTables(string tableName)
        {
            a = new AccessDataSource("Z:\\info\\PROJECTS\\trinity_web\\WebApplication2\\baza.mdb", select + tableName);
            DataView dv = new DataView();
            dv = (DataView)a.Select(DataSourceSelectArguments.Empty);
            DataTable dt = dv.ToTable();
            DataTableReader dr = dt.CreateDataReader();
            while (dr.Read())
            {
                int found = 0;
                for (int i = 0; i <= 7; i++)
                {
                    item[i] = dr[i].ToString().ToLower();
                    if (find(item[i]))
                    {
                        found = 1;
                    }
                }
                if (found == 1)
                {
                    currentCart.displayItem(PlaceHolder1, int.Parse(item[0]));
                    PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp"));
                    Button b = new Button();
                    b.Text = "Buy it";
                    b.ID = "b" + item[0];
                    b.Click += new EventHandler(buyClick);
                    PlaceHolder1.Controls.Add(b);
                    PlaceHolder1.Controls.Add(new LiteralControl("<br /><br />"));
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] == null)
                currentCart = new Cart();
            else
                currentCart = (Cart)Session["cart"];

            if (Session["keyword"] != null)
            {
                searchInTables("[Procesor]");
                searchInTables("[PlacaDeBaza]");
                searchInTables("[PlacaSunet]");
                searchInTables("[Sursa]");
                searchInTables("[MemorieRAM]");
                searchInTables("[PlacaVideo]");
                searchInTables("[DVDPlayer]");
                searchInTables("[Stocare]");
            }
            else
            {
                Label1.Text = "No results to display";
            }

        }
    }
}