using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Mappers;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class DevisService : IDevisService
{
    private readonly IDevisRepository _devisRepository;

    public DevisService(IDevisRepository devisRepository)
    {
        _devisRepository = devisRepository;
    }

    public bool AjouterDetailAuDevis(int devisId, DetailEntity data)
    {
        return _devisRepository.AjouterDetailAuDevis(devisId, data.ToDal());
    }

    public bool CreateDevisForDD(int ddId, string? remarque)
    {
        return _devisRepository.CreateDevisForDD(ddId, remarque);
    }

    public bool DevisDecisionFromUser(int ddId, bool estAccepte)
    {
        return _devisRepository.DevisDecisionFromUser(ddId, estAccepte);
    }

    public DevisEntity? GetById(int id)
    {
        return _devisRepository.GetById(id)?.ToBll();
    }

    public IEnumerable<DetailEntity> GetDetailsDuDevis(int devisId)
    {
        return _devisRepository.GetDetailsDuDevis(devisId).Select(x => x.ToBll());
    }

    public DevisEntity? GetDevisForDD(int ddId)
    {
        return _devisRepository.GetDevisForDD(ddId)?.ToBll();
    }

    public bool ModifierDetailDuDevis(int detailId, DetailEntity data)
    {
        return _devisRepository.ModifierDetailDuDevis(detailId, data.ToDal());
    }

    public bool SubmitDevis(int ddId)
    {
        return _devisRepository.SubmitDevis(ddId);
    }

    public bool SupprimerDetailDuDevis(int detailId)
    {
        return _devisRepository.SupprimerDetailDuDevis(detailId);
    }

    public bool UpdateDevisForDD(int ddId, string? remarque)
    {
        return _devisRepository.UpdateDevisForDD(ddId, remarque);
    }
}
