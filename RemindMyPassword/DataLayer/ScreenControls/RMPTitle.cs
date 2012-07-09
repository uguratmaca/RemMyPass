using System;
using System.Linq;
using System.Collections.Generic;

namespace DataLayer
{
    public class RMPTitle : DataLayerBase
    {
        public override IEnumerable<object> GetObjects()
        {
            var titles = from t in dbContext.Titles
                           select t;

            return titles;
        }

        public RMPTitle()
        {
            Name = "Titles";
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void Load_Object(string parameter1 = null, string parameter2 = null, int? parameter3 = null)
        {
            throw new NotImplementedException();
        }
    }
}
