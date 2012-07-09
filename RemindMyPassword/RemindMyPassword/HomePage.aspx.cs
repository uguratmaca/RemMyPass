using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using System.Data;

namespace RemindMyPassword
{
    public partial class HomePage : BasePage
    {
        [System.Web.Services.WebMethod]
        public static string GetPassword(string username, string websitename, string charcount, string algorithmhardness)
        {
            long userId = 0;

            if (user != null)
            {
                userId = user.Entity.Id;
            }

            string result = GeneralOperations.GeneratePassword(username, websitename, Convert.ToInt32(charcount), algorithmhardness, userId);

            return result;
        }

        protected override void Page_Init(object sender, EventArgs e)
        {
            base.Page_Init(sender, e);

            if (user == null)
            {
                Signuphl.Visible = true;
                Loginuphl.Visible = true;
            }
            else
            {
                SearchSavedOnes.Visible = true;
                SearchSavedQueries.Visible = true;
            }
        }

        protected override void SetInitialValues()
        {
            AlgorithmHardness.SetDataSource(wo.GetChildListElements("AlgorithmHardness"), null, "Name");
            Charcount.SetDataSource(wo.GetChildListElements("CharacterCount"), null, "Name");

            Username.required = false;
            Websitename.required = false;
            SearchSavedOnes.required = false;
            Generatedpassword.required = false;
        }

        protected void Savequerybtn_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                GeneralOperations.SavePassQuery(Convert.ToString(Websitename.GetValue()), user.Entity.Id, String.Empty, Convert.ToString(Username.GetValue()), String.Empty,
                    Convert.ToInt32(Charcount.GetValue()), Convert.ToString(AlgorithmHardness.GetValue()));
            }
            else
            {
                //warning
            }
        }

        protected void FillDatum(object sender, EventArgs e)
        {
            if (user != null)
            {
                DataTable dt = GeneralOperations.GetUserQueries2(user.Entity.Id, Convert.ToString(SearchSavedOnes.GetValue()));

                System.Web.UI.HtmlControls.HtmlGenericControl table = new System.Web.UI.HtmlControls.HtmlGenericControl("Table");

                foreach (DataRow dr in dt.Rows)
                {
                    string callFunction = "Fill(" + dr.ItemArray[0] + ");";
                    System.Web.UI.HtmlControls.HtmlGenericControl tr = new System.Web.UI.HtmlControls.HtmlGenericControl("Tr");
                    table.Controls.Add(tr);

                    System.Web.UI.HtmlControls.HtmlGenericControl td = new System.Web.UI.HtmlControls.HtmlGenericControl("Td");
                    tr.Controls.Add(td);

                    System.Web.UI.HtmlControls.HtmlGenericControl spanus = new System.Web.UI.HtmlControls.HtmlGenericControl("a");
                    spanus.InnerText = Convert.ToString(dr.ItemArray[2]);
                    spanus.Attributes.CssStyle.Add("Cursor", "Pointer");
                    spanus.Attributes.Add("onclick", callFunction);
                    spanus.Attributes.Add("href", "javascript:void(0)");
                    td.Controls.Add(spanus);

                    System.Web.UI.HtmlControls.HtmlGenericControl td2 = new System.Web.UI.HtmlControls.HtmlGenericControl("Td");
                    tr.Controls.Add(td2);

                    System.Web.UI.HtmlControls.HtmlGenericControl spanws = new System.Web.UI.HtmlControls.HtmlGenericControl("a");
                    spanws.InnerText = Convert.ToString(dr.ItemArray[3]);
                    spanws.Attributes.CssStyle.Add("Cursor", "Pointer");
                    spanws.Attributes.Add("onclick", callFunction);
                    spanws.Attributes.Add("href", "javascript:void(0)");
                    td2.Controls.Add(spanws);

                    System.Web.UI.HtmlControls.HtmlGenericControl td3 = new System.Web.UI.HtmlControls.HtmlGenericControl("Td");
                    tr.Controls.Add(td3);

                    System.Web.UI.HtmlControls.HtmlGenericControl spandsc = new System.Web.UI.HtmlControls.HtmlGenericControl("a");
                    spandsc.InnerText = Convert.ToString(dr.ItemArray[4]);
                    spandsc.Attributes.CssStyle.Add("Cursor", "Pointer");
                    spandsc.Attributes.Add("onclick", callFunction);
                    spandsc.Attributes.Add("href", "javascript:void(0)");
                    td3.Controls.Add(spandsc);
                }

                SavedOnesPnl.Controls.Add(table);
            }
            else
            {
                //warning
            }
        }

        [System.Web.Services.WebMethod]
        public static string FillForm(string Id)
        {
            long id = long.Parse(Id);

            string result = GeneralOperations.GetUserQueryById(id, user.Entity.Id);
            return result;
        }
    }
}