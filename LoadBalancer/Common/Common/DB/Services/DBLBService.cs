using Common.DB.Model;
using System;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace Common.DB.Services
{
    [ExcludeFromCodeCoverage]
    public class DBLBService
    {
        private static readonly ItemLBService itemLBService = new ItemLBService();

        public int DeleteAll()
        {
            int ret = -1;
            try
            {
                ret = itemLBService.DeleteAll();
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
            return ret;
        }

        public ItemLB GetOne()
        {
            ItemLB ret = null;
            try
            {
                ret = itemLBService.GetOne();
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
            return ret;
        }

        public int Remove(string code, int value)
        {
            int ret = -1;
            try
            {
                ret = itemLBService.Remove(code, value);
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
            return ret;
        }

        public int Save(ItemLB entity)
        {
            int ret = -1;
            try
            {
                ret = itemLBService.Save(entity);
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
            return ret;
        }
    }
}
