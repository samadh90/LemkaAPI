using Lemka.BLL.Entities;

namespace Lemka.BLL.Interfaces;

public interface IRendezVousService : IServiceBase<int, RendezVousEntity> 
{
    IEnumerable<RendezVousEntity> GetUserRendezVous(int userId);
    RendezVousEntity? Create(int userId, RendezVousEntity data);
}
