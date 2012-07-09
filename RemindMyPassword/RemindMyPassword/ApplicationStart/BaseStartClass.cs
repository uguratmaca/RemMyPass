using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemindMyPassword
{
    public abstract class BaseStartClass
    {
        public string objectName = string.Empty;
        
        public abstract void LoadValues();

        public virtual void ReloadValues()
        {
            HttpContext.Current.Application.Remove(objectName);
            LoadValues();
        }
    }
}
