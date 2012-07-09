using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemindMyPassword
{
    public class StarterFactory
    {
        List<BaseStartClass> classList;

        public List<BaseStartClass> GetClassList
        {
            get { return classList; }
        }

        public StarterFactory()
        {
            classList = new List<BaseStartClass>();
            CreateClassList();
        }

        private void CreateClassList()
        {
            classList.Add(new Captions());
            classList.Add(new Titles());
            classList.Add(new Messages());
            classList.Add(new ListElements());
        }
    }
}