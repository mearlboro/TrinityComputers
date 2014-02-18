using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebStore
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (RadioButtonList1.SelectedIndex == 0)
            {
                prez.Font.Size = 12;
            }
            if (RadioButtonList1.SelectedIndex == 1)
            {
                prez.Font.Size = 18;
            }
            if (RadioButtonList1.SelectedIndex == 2)
            {
                prez.Font.Size = 26;
            }
        }
    }
}