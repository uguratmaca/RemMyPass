using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class RMPListElement : DataLayerBase
    {
        public override void Load_Object(string parameter1 = null, string parameter2 = null, int? parameter3 = null)
        {
            throw new NotImplementedException();
        }

        public RMPListElement()
        {
            Name = "ListElements";
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<object> GetObjects()
        {
            return from le in dbContext.ListElements
                   select le;
        }
    }
}


