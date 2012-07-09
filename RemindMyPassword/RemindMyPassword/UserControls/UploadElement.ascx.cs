using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemindMyPassword
{
    public partial class UploadElement : UCBase
    {
        public override object GetValue()
        {
            return UploadItem.FileBytes;
        }

        public string GetFileName()
        {
            return UploadItem.FileName;
        }

        public bool HasFile()
        {
            return UploadItem.HasFile;
        }
    }
}