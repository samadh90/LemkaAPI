using Lemka.DAL.Datas;
using Lemka.DAL.Interfaces;
using Lemka.DAL.Mappers;
using DevHopTools.Connection;

namespace Lemka.DAL.Repositories;

// TODO - Implémenter Devis Repository
public class DevisRepository : IDevisRepository
{
    private readonly Connection _connection;

    public DevisRepository(Connection connection)
    {
        _connection = connection;
    }

    public bool AjouterDetailAuDevis(int devisId, DetailData data)
    {
        throw new NotImplementedException();
    }

    public bool CreateDevisForDD(int ddId, string? remarque)
    {
        throw new NotImplementedException();
    }

    public bool DevisDecisionFromUser(int ddId, bool estAccepte)
    {
        throw new NotImplementedException();
    }

    public DevisData? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<DetailData> GetDetailsDuDevis(int devisId)
    {
        string query = "SELECT [Desgination], [PrixUHt], [Quantite], [] FROM dbo.[Details] WHERE [DevisId] = @DevisId";
        throw new NotImplementedException();
    }

    public DevisData? GetDevisForDD(int ddId)
    {
        Command command = new("spDevisGetByDDId", true);
        command.AddParameter("@DemandeDevisId", ddId);
        return _connection.ExecuteReader(command, r => r.ToDevis()).SingleOrDefault();
    }

    public bool ModifierDetailDuDevis(int detailId, DetailData data)
    {
        throw new NotImplementedException();
    }

    public bool SubmitDevis(int ddId)
    {
        throw new NotImplementedException();
    }

    public bool SupprimerDetailDuDevis(int detailId)
    {
        throw new NotImplementedException();
    }

    public bool UpdateDevisForDD(int ddId, string? remarque)
    {
        throw new NotImplementedException();
    }
}
