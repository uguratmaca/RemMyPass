using System.Web;
using DataLayer;

namespace RemindMyPassword
{
    public class Titles : BaseStartClass
    {
        RMPTitle tit;

        public override void LoadValues()
        {
            var titles = tit.GetObjects();
            HttpContext.Current.Application.Add(objectName, titles);
        }

        public Titles()
        {
            tit = new RMPTitle();
            objectName = tit.Name;
        }
    }
}