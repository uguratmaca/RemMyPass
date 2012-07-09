using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemindMyPassword
{
    public partial class ClearCache : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            ClearCacheData();
            GoPreviousPage();
        }

        public void ClearCacheData()
        {
            StarterFactory sf = new StarterFactory();

            foreach (BaseStartClass bc in sf.GetClassList)
            {
                bc.ReloadValues();
            }
        }
    }
}