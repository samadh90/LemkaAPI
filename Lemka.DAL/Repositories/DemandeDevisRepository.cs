using System.Text;
using Lemka.DAL.Datas;
using Lemka.DAL.Interfaces;
using Lemka.DAL.Mappers;
using DevHopTools.Connection;

namespace Lemka.DAL.Repositories;

public class DemandeDevisRepository : IDemandeDevisRepository
{
    private readonly Connection _connection;

    public DemandeDevisRepository(Connection connection)
    {
        _connection = connection;
    }

    public int Create(DemandeDevisData data)
    {
        throw new NotImplementedException();
    }

    public int CreateForUser(int userId, DemandeDevisData data)
    {
        Command command = new("spDemandesDevisInsert", true);
        command.AddParameter("", userId);
        command.AddParameter("Titre", data.Titre);
        command.AddParameter("Remarque", data.Remarque);
        command.AddParameter("MensurationId", data.MensurationId);
        command.AddParameter("ServiceId", data.ServiceId);
        command.AddParameter("EstUrgent", data.EstUrgent);
        return int.Parse(_connection.ExecuteScalar(command).ToString());
    }

    public bool Delete(int key)
    {
        string query = "DELETE FROM dbo.DemandeDevis WHERE [Id] = @Id AND [SubmittedAt] IS NULL";
        Command command = new(query);
        command.AddParameter("Id", key);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public bool DemandeDevisAjouterProduit(int ddId, int pId)
    {
        StringBuilder query = new StringBuilder();
        query.Append("IF NOT EXISTS (SELECT TOP 1 * FROM dbo.DemandeDevisProduits WHERE [DemandeDevisId] = @DemandeDevisId AND [ProduitId] = @ProduitId) BEGIN ");
        query.Append("INSERT INTO dbo.DemandeDevisProduits ([DemandeDevisId], [ProduitId]) VALUES (@DemandeDevisId, @ProduitId) END");
        Command command = new(query.ToString());
        command.AddParameter("DemandeDevisId", ddId);
        command.AddParameter("ProduitId", pId);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public bool DemandeDevisDeleteProduit(int ddId, int pId)
    {
        StringBuilder query = new StringBuilder();
        query.Append("IF EXISTS (SELECT TOP 1 * FROM dbo.DemandeDevisProduits WHERE [DemandeDevisId] = @DemandeDevisId AND [ProduitId] = @ProduitId) BEGIN ");
        query.Append("DELETE FROM dbo.DemandeDevisProduits WHERE [DemandeDevisId] = @DemandeDevisId AND [ProduitId] = @ProduitId END");
        Command command = new(query.ToString());
        command.AddParameter("DemandeDevisId", ddId);
        command.AddParameter("ProduitId", pId);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public IEnumerable<DemandeDevisData> GetAll()
    {
        string query = "SELECT * FROM dbo.vDemandeDevis";
        Command command = new(query);
        return _connection.ExecuteReader(command, r => r.ToDemandeDevis());
    }

    public IEnumerable<DemandeDevisData> GetAllByUserId(int userId)
    {
        string query = "SELECT * FROM dbo.vDemandeDevis WHERE [UtilisateurId] = @UtilisateurId";
        Command command = new(query);
        command.AddParameter("UtilisateurId", userId);
        return _connection.ExecuteReader(command, r => r.ToDemandeDevis());
    }

    public DemandeDevisData? GetById(int key)
    {
        string query = "SELECT * FROM dbo.vDemandeDevis WHERE [Id] = @Id";
        Command command = new(query);
        command.AddParameter("Id", key);
        return _connection.ExecuteReader(command, r => r.ToDemandeDevis()).SingleOrDefault();
    }

    public IEnumerable<ProduitData> GetDemandeDevisProduits(int ddId)
    {
        string query = "SELECT p.* FROM dbo.DemandeDevisProduits ddp INNER JOIN dbo.Produits p ON ddp.ProduitId = p.Id WHERE ddp.DemandeDevisId = @DemandeDevisId";
        Command command = new(query);
        command.AddParameter("DemandeDevisId", ddId);
        return _connection.ExecuteReader(command, r => r.ToProduit());
    }

    public bool Submit(int id)
    {
        Command command = new("spDemandesDevisSubmit", true);
        command.AddParameter("Id", id);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public bool Update(int key, DemandeDevisData data)
    {
        Command command = new("spDemandesDevisUpdate", true);
        command.AddParameter("Id", key);
        command.AddParameter("Titre", data.Titre);
        command.AddParameter("Remarque", data.Remarque);
        command.AddParameter("MensurationId", data.MensurationId);
        command.AddParameter("ServiceId", data.ServiceId);
        command.AddParameter("EstUrgent", data.EstUrgent);
        return _connection.ExecuteNonQuery(command) > 0;
    }
}