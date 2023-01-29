using Common.DB.Model;
using LoadBalancer.DB.Connection;
using LoadBalancer.DB.Utils;
using System.Data;

namespace Common.DB.DAO.Impl
{
    public class ItemLBDAOImpl : IItemLBDAO
    {

        public int DeleteAll()
        {
            string query = "delete from items";
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

        public ItemLB GetOne()
        {
            string query = "select * from items where rownum = 1";
            ItemLB ret = null;
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ret = new ItemLB(reader.GetString(0), reader.GetInt32(1));
                        }
                    }
                }
            }
            return ret;
        }

        public int Remove(string code, int value)
        {
            string query = "delete from items where code = :code and value = :value";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "code", DbType.String);
                    ParameterUtil.AddParameter(command, "value", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "code", code);
                    ParameterUtil.SetParameterValue(command, "value", value);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int Save(ItemLB entity)
        {
            string query = "insert into items (code, value) values (:code, :value)";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "code", DbType.String);
                    ParameterUtil.AddParameter(command, "value", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "code", entity.Code);
                    ParameterUtil.SetParameterValue(command, "value", entity.Value);
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
