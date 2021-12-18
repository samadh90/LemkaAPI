namespace Lemka.BLL.Interfaces;

public interface IServiceBase<TKey, TEntity> where TEntity : class
{
    IEnumerable<TEntity> GetAll();
    TEntity? Create(TEntity entity);
    TEntity? GetById(TKey key);
    TEntity? Update(TKey key, TEntity entity);
    bool Delete(TKey key);
}
