using System;
using System.Collections.Generic;

namespace LoadBalancer.DB.DAO
{
    public interface ICRUDDao<T, ID>
    {
        int DeleteAll();

        IEnumerable<T> FindAll(int wid, string code, DateTime timefrom, DateTime timeto);

        int Save(T entity);

        IEnumerable<T> FindCodes(string code);
    }
}
