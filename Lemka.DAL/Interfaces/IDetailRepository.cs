using Lemka.DAL.Datas;

namespace Lemka.DAL.Interfaces;

public interface IDetailRepository
{
    IEnumerable<DetailData> GetAll(int devisId);
    DetailData? GetById(int id);
    int Create(int devisId, DetailData data);
    bool Update(int id, DetailData data);
    bool Delete(int id);
}
