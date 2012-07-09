using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;

namespace RemindMyPassword
{
    public partial class Login : BasePage
    {
        protected void Loginbtn_Click(object sender, EventArgs e)
        {
            RMPUser tryuser = new RMPUser(Convert.ToString(Loginname.GetValue()), Convert.ToString(Password.GetValue()));

            if (tryuser.Entity != null)
            {
                Session[Constants.S_User] = tryuser;
                user = tryuser;
                Warninglbl.Text = String.Empty;
                this.Response.Redirect("~/HomePage.aspx");
            }
            else
            {
                Warninglbl.Text = wo.GetMessage("LoginFailed");
            }
        }

        protected override void SetInitialValues()
        {
            Password.textMode = TextBoxMode.Password;
            PageTitle = "Welcome.aspx";
        }
    }
}