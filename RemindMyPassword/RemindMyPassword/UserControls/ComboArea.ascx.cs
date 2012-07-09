using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using DataLayer;

namespace RemindMyPassword
{
    public partial class ComboArea : UCBase
    {
        public event EventHandler selectedItemChanged;
        public bool useEvent = false;
        string defaultValue = string.Empty;

        public override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            //defaultValue = wo.GetMessage("ComboSelectDefault");
            //AddChooseLabel();
            SetInitialValue();
        }

        public override void SetDataSource<T>(IEnumerable<T> varlist, BaseDataBoundControl webControl = null, string dataValueFieldName = "Id",string dataTextValueFieldName = "Text", int page = 0, int rowCount = 10 )
        {
            if (ComboBox.Items.Count == 0)
            {
                DataTable dt = GeneralOperations.LINQToDataTable(varlist);

                ComboBox.DataValueField = dataValueFieldName;
                ComboBox.DataTextField = dataTextValueFieldName;
                ComboBox.DataSource = dt;
                ComboBox.DataBind();
            }
        }

        protected void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedItemChanged != null)
            {
                selectedItemChanged(ComboBox.SelectedValue, EventArgs.Empty);
            }
        }

        public override void Clear()
        {
            ComboBox.Items.Clear();
        }

        private void AddChooseLabel()
        {
            if (ComboBox.Items.Count > 0)
            {
                if (ComboBox.Items[0].Value != defaultValue)
                {
                    ComboBox.Items.Insert(0, defaultValue);
                }
            }
        }

        public override object GetValue()
        {
            if (ComboBox.SelectedValue != defaultValue)
            {
                return ComboBox.SelectedValue;
            }
            return -1;
            //throw new Exception(Constants.RequireSelection);
        }

        public void SetInitialValue()
        {
            // ComboRequired.InitialValue = defaultValue;
            ComboRequired.Enabled = required;
            ComboBox.AutoPostBack = useEvent;
        }

        public void SelectNone()
        {
            ComboBox.SelectedIndex = 0;
        }
    }
}