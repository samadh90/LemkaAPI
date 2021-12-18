using Lemka.DAL.Datas;

namespace Lemka.DAL.Interfaces;

public interface ICategorieRepository : IRepositoryBase<int, CategorieData>
{
    IEnumerable<CategorieData> GetEnfants(int id);
}
