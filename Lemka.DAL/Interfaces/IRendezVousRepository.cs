using Lemka.DAL.Datas;

namespace Lemka.DAL.Interfaces;

public interface IRendezVousRepository : IRepositoryBase<int, RendezVousData>
{
    IEnumerable<RendezVousData> GetUserRendezVous(int userId);
    int Create(int userId, RendezVousData data);
}
