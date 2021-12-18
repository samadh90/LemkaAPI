using Lemka.BLL.Entities;

namespace Lemka.BLL.Interfaces;

public interface IDevisService
{
    DevisEntity? GetDevisForDD(int ddId);
    DevisEntity? GetById(int id);
    bool CreateDevisForDD(int ddId, string? remarque);
    bool UpdateDevisForDD(int ddId, string? remarque);
    bool SubmitDevis(int ddId);
    bool DevisDecisionFromUser(int ddId, bool estAccepte);
    IEnumerable<DetailEntity> GetDetailsDuDevis(int devisId);
    bool AjouterDetailAuDevis(int devisId, DetailEntity data);
    bool ModifierDetailDuDevis(int detailId, DetailEntity data);
    bool SupprimerDetailDuDevis(int detailId);
}