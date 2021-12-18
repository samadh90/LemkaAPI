using Lemka.DAL.Datas;
using Lemka.DAL.Interfaces;
using DevHopTools.Connection;

namespace Lemka.DAL.Repositories;

// TODO - Implémenter Rendez Vous Repository

public class RendezVousRepository : IRendezVousRepository
{
    private readonly Connection _connection;

    public RendezVousRepository(Connection connection)
    {
        _connection = connection;
    }

    public int Create(RendezVousData data)
    {
        throw new NotImplementedException();
    }

    public int Create(int userId, RendezVousData data)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int key)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<RendezVousData> GetAll()
    {
        throw new NotImplementedException();
    }

    public RendezVousData? GetById(int key)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<RendezVousData> GetUserRendezVous(int userId)
    {
        throw new NotImplementedException();
    }

    public bool Update(int key, RendezVousData data)
    {
        throw new NotImplementedException();
    }
}
