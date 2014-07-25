using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopSmart.Web
{
    public partial class Home : PageBase
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetCulture();
        }

        private void SetCulture()
        {
            #region--Show/hide language link
            //if (!string.IsNullOrEmpty(Convert.ToString(Session["lang"])))
            //{
            //    if (Convert.ToString(Session["lang"]) == "en")
            //    {
            //        linkHebrewLang.Visible = true;
            //        linkEnglishLang.Visible = false;
            //    }
            //    else
            //    {
            //        linkEnglishLang.Visible = true;
            //        linkHebrewLang.Visible = false;
            //    }
            //}
            //else
            //{
            //    linkHebrewLang.Visible = false;
            //    linkEnglishLang.Visible = true;
            //}
            #endregion--
        }
    }
}