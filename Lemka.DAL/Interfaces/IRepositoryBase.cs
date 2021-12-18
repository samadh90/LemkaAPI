namespace Lemka.DAL.Interfaces;

public interface IRepositoryBase<TKey, TData> where TData : class
{
    IEnumerable<TData> GetAll();
    int Create(TData data);
    TData? GetById(TKey key);
    bool Update(TKey key, TData data);
    bool Delete(TKey key);
}
