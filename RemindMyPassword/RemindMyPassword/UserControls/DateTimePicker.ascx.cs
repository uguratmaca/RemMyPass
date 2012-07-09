using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemindMyPassword
{
    public partial class DateTimePicker : UCBase
    {
        public override object GetValue()
        {
            return DateTime.SelectedDate;
        }
    }
}