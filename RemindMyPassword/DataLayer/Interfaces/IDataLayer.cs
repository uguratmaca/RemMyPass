using System.Collections.Generic;

namespace DataLayer
{
    public interface IDataLayer
    {
        void Save();

        void Load_Object(string parameter1 = null, string parameter2 = null, int? parameter3 = null);
        IEnumerable<object> GetObjects();
    }
}
