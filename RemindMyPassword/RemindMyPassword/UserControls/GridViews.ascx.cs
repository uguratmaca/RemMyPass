using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace RemindMyPassword
{
    public partial class GridViews : UCBase
    {
        public override void SetDataSource<T>(IEnumerable<T> varlist, BaseDataBoundControl webControl = null, string dataValueFieldName = "Id",string dataTextValueFieldName = "Text", int page = 0, int rowCount = 0)
        {
            base.SetDataSource<T>(varlist, DataGrid, dataValueFieldName,dataTextValueFieldName, page, rowCount);
        }
    }
}