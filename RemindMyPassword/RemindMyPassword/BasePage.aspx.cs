using System;
using DataLayer;

namespace RemindMyPassword
{
    public abstract partial class BasePage : System.Web.UI.Page
    {
        public WebOperations wo = new WebOperations();
        public static RMPUser user;
        public string PageTitle;

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            SetReferrerUrl();
            if (!IsPostBack)
            {
                SetTitle();
                SetCaptions();
            }
        }

        protected virtual void Page_Init(object sender, EventArgs e)
        {
            user = Session[Constants.S_User] as RMPUser;
            
            SetInitialValues();            
        }

        protected virtual void SetCaptions()
        {

        }

        protected virtual void SetTitle()
        {
            int lastElement = this.Page.Request.Url.Segments.Length - 1;
            this.Title = wo.GetTitle(this.Page.Request.Url.Segments[lastElement]);
        }

        protected virtual void ClearSessions(string sessions)
        {
            string[] sessionNames = sessions.Split('~');
            foreach (string name in sessionNames)
            {
                Session.Contents.Remove(name);
            }
        }

        protected virtual void SetInitialValues()
        {

        }

        private void SetReferrerUrl()
        {
            Session[Constants.S_TwoBack] = Session[Constants.S_OneBack];
            Session[Constants.S_OneBack] = Request.Url.AbsoluteUri;
        }

        public void GoPreviousPage()
        {
            string redirectUrl = Convert.ToString(Session[Constants.S_TwoBack]);
            Response.Redirect(redirectUrl);
        }
    }
}