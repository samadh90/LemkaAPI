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

    public IEnumerable<DemandeDevisData> GetAll()
    {
        string query = "SELECT * FROM dbo.vDemandeDevis";
        Command command = new(query);
        return _connection.ExecuteReader(command, r => r.ToDemandeDevis());
    }

    public IEnumerable<DemandeDevisData> GetAll(int userId)
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

    public int Create(int userId, DemandeDevisData data)
    {
        Command command = new("spDemandesDevisInsert", true);
        command.AddParameter("UtilisateurId", userId);
        command.AddParameter("Titre", data.Titre);
        command.AddParameter("Remarque", data.Remarque);
        command.AddParameter("MensurationId", data.MensurationId);
        command.AddParameter("ServiceId", data.ServiceId);
        command.AddParameter("EstUrgent", data.EstUrgent);
        return int.Parse(_connection.ExecuteScalar(command).ToString());
    }

    public bool Update(int key, DemandeDevisData data)
    {
        string query = "UPDATE dbo.DemandeDevis SET [Titre] = @Titre, [Remarque] = @Remarque, [MensurationId] = @MensurationId, [ServiceId] = @ServiceId, [EstUrgent] = @EstUrgent WHERE [Id] = @Id AND [SubmittedAt] IS NULL";
        Command command = new(query);
        command.AddParameter("Id", key);
        command.AddParameter("Titre", data.Titre);
        command.AddParameter("Remarque", data.Remarque);
        command.AddParameter("MensurationId", data.MensurationId);
        command.AddParameter("ServiceId", data.ServiceId);
        command.AddParameter("EstUrgent", data.EstUrgent);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public bool Delete(int key)
    {
        string query = "DELETE FROM dbo.DemandeDevis WHERE [Id] = @Id AND [SubmittedAt] IS NULL";
        Command command = new(query);
        command.AddParameter("Id", key);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public bool Submit(int id)
    {
        string query = "UPDATE dbo.[DemandeDevis] SET [SubmittedAt] = GETDATE() WHERE [Id] = @Id AND [SubmittedAt] IS NULL";
        Command command = new(query);
        command.AddParameter("Id", id);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public IEnumerable<ProduitData> GetProduits(int ddId)
    {
        string query = "SELECT p.* FROM dbo.[DemandeDevisProduits] ddp INNER JOIN dbo.[vProduits] p ON ddp.[ProduitId] = p.[Id] WHERE ddp.[DemandeDevisId] = @DemandeDevisId";
        Command command = new(query);
        command.AddParameter("DemandeDevisId", ddId);
        return _connection.ExecuteReader(command, r => r.ToProduit());
    }

    public bool AddProduit(int ddId, int pId)
    {
        Command command = new("spDemandesDevisAddProduit", true);
        command.AddParameter("DemandeDevisId", ddId);
        command.AddParameter("ProduitId", pId);
        return _connection.ExecuteNonQuery(command) > 0;
    }

    public bool DeleteProduit(int ddId, int pId)
    {
        string query = "DELETE FROM dbo.[DemandeDevisProduits] WHERE [DemandeDevisId] = DemandeDevisId AND [ProduitId] = @ProduitId";
        Command command = new(query);
        command.AddParameter("DemandeDevisId", ddId);
        command.AddParameter("ProduitId", pId);
        return _connection.ExecuteNonQuery(command) > 0;
    }
}