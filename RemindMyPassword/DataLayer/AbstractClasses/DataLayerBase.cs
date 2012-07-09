using System.Data.Objects.DataClasses;
using System.Data;
using System.Collections.Generic;

namespace DataLayer
{
    public abstract class DataLayerBase : IDataLayer
    {
        protected static RMPEntities dbContext = new RMPEntities();
        
        //public EntityObject Entity;

        //public EntityKey entityKey = null;

        public string Name
        {
            get;
            set;
        }

        public virtual void Save()
        {
        }

        public virtual void BeforeSave()
        {

        }

        public DataLayerBase()
        { 
        
        }

        //public DataLayerBase(object Entity)
        //{
        //    baseEntity = Entity as EntityObject;
        //}

        public abstract void Load_Object(string parameter1 = null, string parameter2 = null, int? parameter3 = null);
        public abstract IEnumerable<object> GetObjects();
    }
}