using Lemka.DAL.Datas;

namespace Lemka.DAL.Interfaces;

public interface IDevisRepository
{
    DevisData? GetDevisForDD(int ddId);
    DevisData? GetById(int id);
    bool CreateDevisForDD(int ddId, string? remarque);
    bool UpdateDevisForDD(int ddId, string? remarque);
    bool SubmitDevis(int ddId);
    bool DevisDecisionFromUser(int ddId, bool estAccepte);
    IEnumerable<DetailData> GetDetailsDuDevis(int devisId);
    bool AjouterDetailAuDevis(int devisId, DetailData data);
    bool ModifierDetailDuDevis(int detailId, DetailData data);
    bool SupprimerDetailDuDevis(int detailId);
}
