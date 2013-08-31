using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopSmart.Web
{
    public partial class Default : System.Web.UI.Page
    {
        //this is a dummy!!
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Home.aspx");
        }
    }
}