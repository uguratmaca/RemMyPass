using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemindMyPassword
{
    public partial class TextEntryArea : UCBase
    {
        public bool isNumeric = false;
        public TextBoxMode textMode = TextBoxMode.SingleLine;

        public override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            TextValueRequired.Enabled = required;
            NumericValidator.Enabled = isNumeric;
            TextboxValue.TextMode = textMode;
        }

        public override object GetValue()
        {
            return TextboxValue.Text;
        }

        public override void Clear()
        {
            TextboxValue.Text = string.Empty;
        }

        public void SetWidth(int textBoxWidth, int labelWidth)
        {
            TextboxValue.Width = textBoxWidth;
            LabelCaption.Width = labelWidth;
        }

    }
}