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
    public class DataSet4Service
    {
        private static readonly IDataSet4DAO dataset4DAO = new DataSet4DAOimpl();

        public List<DataSet4> FindAll(int wid, string code, DateTime timefrom, DateTime timeto)
        {
            return dataset4DAO.FindAll(wid, code, timefrom, timeto).ToList();
        }

        public int SaveDataSet(DataSet4 entity)
        {
            return dataset4DAO.Save(entity);
        }

        public List<DataSet4> FindCodes(string code)
        {
            return dataset4DAO.FindCodes(code).ToList();
        }

        public int DeleteAll()
        {
            return dataset4DAO.DeleteAll();
        }
    }
}
