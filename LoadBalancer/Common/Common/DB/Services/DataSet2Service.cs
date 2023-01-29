using LoadBalancer.DB.DAO;
using LoadBalancer.DB.DAO.Impl;
using LoadBalancer.DB.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LoadBalancer.DB.Services
{
    [ExcludeFromCodeCoverage]
    public class DataSet2Service
    {
        private static readonly IDataSet2DAO dataset2DAO = new DataSet2DAOimpl();

        public List<DataSet2> FindAll(int wid, string code, DateTime timefrom, DateTime timeto)
        {
            return dataset2DAO.FindAll(wid, code, timefrom, timeto).ToList();
        }

        public int SaveDataSet(DataSet2 entity)
        {
            return dataset2DAO.Save(entity);
        }

        public List<DataSet2> FindCodes(string code)
        {
            return dataset2DAO.FindCodes(code).ToList();
        }

        public int DeleteAll()
        {
            return dataset2DAO.DeleteAll();
        }
    }
}
