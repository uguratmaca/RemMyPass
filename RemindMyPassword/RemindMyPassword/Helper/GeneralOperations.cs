using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using DataLayer;

namespace RemindMyPassword
{
    public class WebOperations
    {
        public string GetCaption(string Name)
        {
            var cap = HttpContext.Current.Application["Captions"] as IEnumerable<Caption>;
            return cap.Where(c => c.Name == Name).Select(c => c.Text).FirstOrDefault();
        }

        public string GetTitle(string Name)
        {
            try
            {
                var tit = HttpContext.Current.Application["Titles"] as IEnumerable<Title>;
                return tit.Where(t => t.Name == Name).Select(t => t.Text).FirstOrDefault();
            }
            catch
            {
                throw new Exception(Name + " not found");
            }
        }

        public string GetMessage(string Name)
        {
            var mes = HttpContext.Current.Application["Messages"] as IEnumerable<Message>;
            return mes.Where(t => t.Name == Name).Select(t => t.Text).FirstOrDefault();
        }

        public IEnumerable<object> GetChildListElements(string ParentName)
        {
            var cle = HttpContext.Current.Application["ListElements"] as IEnumerable<ListElement>;
            int pId = cle.Where(c => c.Name == ParentName).Select(c => c.Id).FirstOrDefault();

            var result = from c in cle
                         where c.ParentId == pId
                         select new
                         {
                             c.Id,
                             c.Name,
                             c.Text
                         };

            return result;
        }

        public int GetListElementIdByName(string Name)
        {
            var cle = HttpContext.Current.Application["ListElements"] as IEnumerable<ListElement>;
            return cle.Where(c => c.Name == Name).Select(c => c.Id).FirstOrDefault();
        }
    }
}