using System;
using System.Web.UI.WebControls;

namespace RemindMyPassword
{
    public partial class CheckboxArea : UCBase
    {
        public event EventHandler checkedChanged;        

        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkedChanged != null)
            { checkedChanged(CheckBox.Checked, EventArgs.Empty); }
        }

        public override object GetValue()
        {
            return CheckBox.Checked;
        }
    }
}