using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;

namespace RemindMyPassword
{
    public class Messages : BaseStartClass
    {
        RMPMessage mes;

        public override void LoadValues()
        {
            var titles = mes.GetObjects();
            HttpContext.Current.Application.Add(objectName, titles);
        }

        public Messages()
        {
            mes = new RMPMessage();
            objectName = mes.Name;
        }

    }
}