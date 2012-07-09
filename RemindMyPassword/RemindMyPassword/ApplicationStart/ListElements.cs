using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;

namespace RemindMyPassword
{
    public class ListElements : BaseStartClass
    {
        RMPListElement list;

        public override void LoadValues()
        {
            var captions = list.GetObjects();
            HttpContext.Current.Application.Add(objectName, captions);
        }

        public ListElements()
        {
            list = new RMPListElement();
            objectName = list.Name;
        }
    }
}