using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using DataLayer;

namespace RemindMyPassword
{
    public partial class UCBase : System.Web.UI.UserControl
    {
        public bool required = true;
        public WebOperations wo = new WebOperations();

        public virtual void Page_Load(object sender, EventArgs e)
        {
            SetLabelText(wo.GetCaption(this.ID));
        }

        public virtual void SetDataSource<T>(IEnumerable<T> varlist, BaseDataBoundControl webControl, string dataValueFieldName = "Id", string dataTextFieldName = "Text", int page = 0, int rowCount = 0)
        {
            DataTable dt = GeneralOperations.LINQToDataTable(varlist, page, rowCount);

            if (dt.Rows.Count > 0)
            {
                //webControl.DataSourceID 
                webControl.DataSource = dt;
                webControl.DataBind();
            }
        }

        public virtual void Clear()
        {

        }

        public virtual void SetLabelText(string labelText, string secondaryLabelText = null)
        {
            LabelCaption.Text = labelText;
            if (SecondaryLabelCaption != null)
            {
                SecondaryLabelCaption.Text = secondaryLabelText;
                SecondaryLabelCaption.Visible = true;
            }
        }

        public virtual object GetValue()
        {
            return null;
        }
    }
}