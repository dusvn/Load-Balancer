namespace Common.DB.DAO
{
    public interface ICRUDDaoLB<T, ID>
    {
        int DeleteAll();

        int Save(T entity);

        T GetOne();

        int Remove(string code, int value);
    }
}
