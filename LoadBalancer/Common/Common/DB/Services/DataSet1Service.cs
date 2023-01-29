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
    public class DataSet1Service
    {
        private static readonly IDataSet1DAO dataset1DAO = new DataSet1DAOimpl();

        public List<DataSet1> FindAll(int wid, string code, DateTime timefrom, DateTime timeto)
        {
            return dataset1DAO.FindAll(wid, code, timefrom, timeto).ToList();
        }

        public int SaveDataSet(DataSet1 entity)
        {
            return dataset1DAO.Save(entity);
        }

        public List<DataSet1> FindCodes(string code)
        {
            return dataset1DAO.FindCodes(code).ToList();
        }

        public int DeleteAll()
        {
            return dataset1DAO.DeleteAll();
        }
    }
}
