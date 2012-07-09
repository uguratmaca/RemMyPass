using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;

namespace RemindMyPassword
{
    public partial class SelectArea : UCBase
    {
        public override void Page_Load(object sender, EventArgs e)
        {
            Panel1.GroupingText = wo.GetCaption(this.ID + "Legend");
            SetLabelText(wo.GetCaption(this.ID + "First"), wo.GetCaption(this.ID + "Second"));
        }

        protected void Add_click(object sender, EventArgs e)
        {
            if (AllItems.SelectedIndex > -1)
            {
                SelectedItems.Items.Add(AllItems.SelectedItem);
                AllItems.Items.RemoveAt(AllItems.SelectedIndex);
                SelectedItems.SelectedIndex = -1;
            }
        }

        protected void Remove_click(object sender, ImageClickEventArgs e)
        {
            if (SelectedItems.SelectedIndex > -1)
            {
                AllItems.Items.Add(SelectedItems.SelectedItem);
                SelectedItems.Items.RemoveAt(SelectedItems.SelectedIndex);
                AllItems.SelectedIndex = -1;
            }
        }

        public override void SetDataSource<T>(IEnumerable<T> varlist, BaseDataBoundControl webControl = null, string dataValueFieldName = "Id", string dataTextValueFieldName = "Text", int page = 0, int rowCount = 10)
        {
            DataTable dt = GeneralOperations.LINQToDataTable(varlist);

            AllItems.DataValueField = dataValueFieldName;
            AllItems.DataTextField = Convert.ToString(dt.Columns[1]);
            AllItems.DataSource = dt;
            AllItems.DataBind();
        }

        public List<int> GetSelectedItems()
        {
            List<int> returnValue = new List<int>();
            for (int i = 0; i < SelectedItems.Items.Count; i++)
            {
                returnValue.Add(Convert.ToInt32(SelectedItems.Items[i].Value));
            }
            return returnValue;
        }

        public override void Clear()
        {
            AllItems.Items.Clear();
            SelectedItems.Items.Clear();
        }

        public void SetEnabled(bool value)
        {
            Panel1.Enabled = value;
        }

        protected void ValidateSelectedItems(object sender, ServerValidateEventArgs e)
        {
            if (SelectedItems.Items.Count > 0)
            {
                e.IsValid = true;
            }
            else
            {
                e.IsValid = false;
            }
        }
    }
}