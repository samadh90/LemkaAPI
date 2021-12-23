using Lemka.DAL.Datas;
using Lemka.DAL.Interfaces;
using Lemka.DAL.Mappers;
using DevHopTools.Connection;

namespace Lemka.DAL.Repositories;

// @DemandeDevisId INT, @Remarque TEXT, @ExpiresInDays INT

public class DevisRepository : IDevisRepository
{
    private readonly Connection _connection;

    public DevisRepository(Connection connection)
    {
        _connection = connection;
    }

    public DevisData? Get(int demandeDevisId)
    {
        Command command = new("spDevisGetOne", true);
        command.AddParameter("DemandeDevisId", demandeDevisId);
        return _connection.ExecuteReader(command, r => r.ToDevis()).SingleOrDefault();
    }

    public bool Create(int demandeDevisId, DevisData data)
    {
        Command command = new("spDevisInsert", true);
        command.AddParameter("DemandeDevisId", demandeDevisId);
        command.AddParameter("Remarque", data.Remarque);
        command.AddParameter("ExpiresInDays", data.ExpiresInDays);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public bool Update(int demandeDevisId, DevisData data)
    {
        Command command = new("spDevisUpdate", true);
        command.AddParameter("DemandeDevisId", demandeDevisId);
        command.AddParameter("Remarque", data.Remarque);
        command.AddParameter("ExpiresInDays", data.ExpiresInDays);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public bool Update(int demandeDevisId, bool accepter)
    {
        Command command = new("spDevisDecision", true);
        command.AddParameter("DemandeDevisId", demandeDevisId);
        command.AddParameter("Decision", accepter);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public bool Delete(int demandeDevisId)
    {
        string query = "DELETE FROM dbo.[Devis] WHERE [DemandeDevisId] = @DemandeDevisId";
        Command command = new(query);
        command.AddParameter("DemandeDevisId", demandeDevisId);
        return _connection.ExecuteNonQuery(command) > 0;
    }
}
