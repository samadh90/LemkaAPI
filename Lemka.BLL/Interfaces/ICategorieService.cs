using Lemka.BLL.Entities;

namespace Lemka.BLL.Interfaces;

public interface ICategorieService : IServiceBase<int, CategorieEntity>
{
    IEnumerable<CategorieEntity> GetEnfants(int id);

}
