using System;
using System.Linq;
using System.Collections.Generic;

namespace DataLayer
{
    public class RMPUser : DataLayerBase
    {
        public User Entity;

        public override void Load_Object(string parameter1 = null, string parameter2 = null, int? parameter3 = null)
        {
            Entity = dbContext.Users.Where(user => user.LoginName == parameter1 &&
                                user.Password == parameter2).SingleOrDefault();
        }

        public RMPUser(string loginname, string loginpassword)
        {
            Load_Object(loginname, loginpassword);
        }

        public RMPUser()
        {
        }

        public override void Save()
        {
            dbContext.Users.AddObject(Entity);
            dbContext.SaveChanges();
        }

        public override IEnumerable<object> GetObjects()
        {
            return from u in dbContext.Users
                   select new
                   {
                       u.Id,
                       u.LoginName
                   };
        }

    }
}

