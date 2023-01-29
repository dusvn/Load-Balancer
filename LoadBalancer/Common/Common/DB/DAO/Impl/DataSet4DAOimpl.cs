using LoadBalancer.DB.Connection;
using LoadBalancer.DB.Model;
using LoadBalancer.DB.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace LoadBalancer.DB.DAO.Impl
{
    public class DataSet4DAOimpl : IDataSet4DAO
    {
        public IEnumerable<DataSet4> FindAll(int wid, string code, DateTime timefrom, DateTime timeto)
        {
            string query = "select wid, code, value, time from dataset4 " +
                "where time between :timefrom and :timeto " +
                "and code = :code " +
                "and wid = :wid";

            List<DataSet4> dataset4List = new List<DataSet4>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "timefrom", DbType.DateTime);
                    ParameterUtil.AddParameter(command, "timeto", DbType.DateTime);
                    ParameterUtil.AddParameter(command, "code", DbType.String);
                    ParameterUtil.AddParameter(command, "wid", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "timefrom", timefrom);
                    ParameterUtil.SetParameterValue(command, "timeto", timeto);
                    ParameterUtil.SetParameterValue(command, "code", code);
                    ParameterUtil.SetParameterValue(command, "wid", wid);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataSet4 ds = new DataSet4(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDateTime(3));
                            dataset4List.Add(ds);
                        }
                    }
                }
            }

            return dataset4List;
        }

        public IEnumerable<DataSet4> FindCodes(string code)
        {
            string query = "select wid, code, value, time from dataset4 " +
                "where code = :code";

            List<DataSet4> dataset4List = new List<DataSet4>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "code", DbType.String);
                    ParameterUtil.SetParameterValue(command, "code", code);
                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataSet4 ds = new DataSet4(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDateTime(3));
                            dataset4List.Add(ds);
                        }
                    }
                }
            }

            return dataset4List;
        }

        public int Save(DataSet4 entity)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                string insertSql = "insert into dataset4 (wid, code, value, time) " +
                "values (:wid, :code, :value, :time)";

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = insertSql;
                    ParameterUtil.AddParameter(command, "wid", DbType.Int32);
                    ParameterUtil.AddParameter(command, "code", DbType.String);
                    ParameterUtil.AddParameter(command, "value", DbType.Int32);
                    ParameterUtil.AddParameter(command, "time", DbType.DateTime);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "wid", entity.Wid);
                    ParameterUtil.SetParameterValue(command, "code", entity.Code);
                    ParameterUtil.SetParameterValue(command, "value", entity.Value);
                    ParameterUtil.SetParameterValue(command, "time", entity.Time);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteAll()
        {
            string query = "delete from dataset4";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();
                    return command.ExecuteNonQuery();
                }
            }

        }
    }
}
