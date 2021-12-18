using Lemka.DAL.Datas;
using Lemka.DAL.Interfaces;
using Lemka.DAL.Mappers;
using DevHopTools.Connection;

namespace Lemka.DAL.Repositories;

public class HoraireRepository : IHoraireRepository
{
    private readonly Connection _connection;

    public HoraireRepository(Connection connection)
    {
        _connection = connection;
    }

    public int Create(HoraireData data)
    {
        throw new NotImplementedException();
    }

    public bool Delete(string key)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<HoraireData> GetAll()
    {
        string query = "SELECT * FROM dbo.Horaires ORDER BY [JourSemaine] ASC";
        Command command = new(query);
        return _connection.ExecuteReader(command, r => r.ToHoraire());
    }

    public HoraireData? GetById(string key)
    {
        string query = "SELECT * FROM dbo.Horaires WHERE [Jour] = @Jour";
        Command command = new(query);
        command.AddParameter("Jour", key);
        return _connection.ExecuteReader(command, r => r.ToHoraire()).SingleOrDefault();
    }

    public bool Update(string key, HoraireData data)
    {
        string query = "UPDATE dbo.Horaires SET [HeureOuverture] = @HeureOuverture, [HeureFermeture] = @HeureFermeture, [SurRdv] = @SurRdv, [EstFerme] = @EstFerme WHERE [Jour] = @Jour";
        Command command = new(query);
        command.AddParameter("Jour", key);
        command.AddParameter("HeureOuverture", data.HeureOuverture);
        command.AddParameter("HeureFermeture", data.HeureFermeture);
        command.AddParameter("SurRdv", data.SurRdv);
        command.AddParameter("EstFerme", data.EstFerme);
        return _connection.ExecuteNonQuery(command) > 0;
    }
}
