using Lemka.BLL.Entities;

namespace Lemka.BLL.Interfaces;

public interface IDetailService
{
    IEnumerable<DetailEntity> GetAll(int devisId);
    DetailEntity? GetById(int id);
    DetailEntity? Create(int devisId, DetailEntity entity);
    DetailEntity? Update(int id, DetailEntity entity);
    bool Delete(int id);
}
