using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class RMPMessage :DataLayerBase
    {
        public override IEnumerable<object> GetObjects()
        {
            var messages = from m in dbContext.Messages
                           select m;

            return messages;
        }

        public override void Save()
        {
        }

        public RMPMessage()
        {
            Name = "Messages";
        }

        public override void Load_Object(string parameter1 = null, string parameter2 = null, int? parameter3 = null)
        {
            throw new NotImplementedException();
        }
    }
}
