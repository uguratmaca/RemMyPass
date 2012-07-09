using System.Web;
using DataLayer;

namespace RemindMyPassword
{
    public class Captions : BaseStartClass
    {
        RMPCaption cap;

        public override void LoadValues()
        {
            var captions = cap.GetObjects();
            HttpContext.Current.Application.Add(objectName, captions);
        }

        public Captions()
        {
            cap = new RMPCaption();
            objectName = cap.Name;
        }
    }
}