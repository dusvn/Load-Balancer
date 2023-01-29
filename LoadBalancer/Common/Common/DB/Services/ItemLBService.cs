using Common.DB.DAO;
using Common.DB.DAO.Impl;
using Common.DB.Model;
using System.Diagnostics.CodeAnalysis;

namespace Common.DB.Services
{
    [ExcludeFromCodeCoverage]
    public class ItemLBService
    {
        private static readonly IItemLBDAO itemLBDao = new ItemLBDAOImpl();

        public int DeleteAll()
        {
            return itemLBDao.DeleteAll();
        }

        public ItemLB GetOne()
        {
            return itemLBDao.GetOne();
        }

        public int Remove(string code, int value)
        {
            return itemLBDao.Remove(code, value);
        }

        public int Save(ItemLB entity)
        {
            return itemLBDao.Save(entity);
        }
    }
}
