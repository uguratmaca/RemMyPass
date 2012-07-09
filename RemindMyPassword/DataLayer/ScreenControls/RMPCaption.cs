using System;
using System.Linq;
using System.Collections.Generic;

namespace DataLayer
{
    public class RMPCaption : DataLayerBase
    {
        public override IEnumerable<object> GetObjects()
        {
            var captions = from c in dbContext.Captions
                           select c;

            return captions;
        }

        public override void Save()
        {
        }

        public RMPCaption()
        {
            Name = "Captions";
        }

        public override void Load_Object(string parameter1 = null, string parameter2 = null, int? parameter3 = null)
        {
            throw new NotImplementedException();
        }
    }
}
