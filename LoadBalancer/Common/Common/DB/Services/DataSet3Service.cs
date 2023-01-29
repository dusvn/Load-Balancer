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
    public class DataSet3Service
    {
        private static readonly IDataSet3DAO dataset3DAO = new DataSet3DAOimpl();

        public List<DataSet3> FindAll(int wid, string code, DateTime timefrom, DateTime timeto)
        {
            return dataset3DAO.FindAll(wid, code, timefrom, timeto).ToList();
        }

        public int SaveDataSet(DataSet3 entity)
        {
            return dataset3DAO.Save(entity);
        }

        public List<DataSet3> FindCodes(string code)
        {
            return dataset3DAO.FindCodes(code).ToList();
        }

        public int DeleteAll()
        {
            return dataset3DAO.DeleteAll();
        }
    }
}
