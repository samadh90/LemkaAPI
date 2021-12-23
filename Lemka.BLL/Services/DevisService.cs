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

    public DevisEntity? Get(int demandeDevisId)
    {
        return _devisRepository.Get(demandeDevisId)?.ToBll();
    }

    public DevisEntity? Create(int demandeDevisId, DevisEntity data)
    {
        bool success = _devisRepository.Create(demandeDevisId, data.ToDal());
        if (!success) return null;
        return Get(demandeDevisId);
    }

    public DevisEntity? Update(int demandeDevisId, DevisEntity devisData)
    {
        bool success = _devisRepository.Update(demandeDevisId, devisData.ToDal());
        if (!success) return null;
        return Get(demandeDevisId);
    }

    public DevisEntity? Update(int demandeDevisId, bool accepter)
    {
        bool succes = _devisRepository.Update(demandeDevisId, accepter);
        if (!succes) return null;
        return Get(demandeDevisId);
    }

    public bool Delete(int demandeDevisId)
    {
        return _devisRepository.Delete(demandeDevisId);
    }
}
