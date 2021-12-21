using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Mappers;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class DemandeDevisService : IDemandeDevisService
{
    private readonly IDemandeDevisRepository _demandeDevisRepository;
    private readonly IServiceRepository _serviceRepository;

    public DemandeDevisService(IDemandeDevisRepository demandeDevisRepository, IServiceRepository serviceRepository)
    {
        _demandeDevisRepository = demandeDevisRepository;
        _serviceRepository = serviceRepository;
    }

    public DemandeDevisEntity? Create(DemandeDevisEntity entity)
    {
        int id = _demandeDevisRepository.Create(entity.ToDal());
        if (id == 0) return null;
        return GetById(id);
    }

    public DemandeDevisEntity? CreateForUser(int userId, DemandeDevisEntity entity)
    {
        int id = _demandeDevisRepository.CreateForUser(userId, entity.ToDal());
        if (id == 0) return null;
        return GetById(id);
    }

    public bool Delete(int key)
    {
        return _demandeDevisRepository.Delete(key);
    }

    public bool DemandeDevisAjouterProduit(int ddId, int pId)
    {
        return _demandeDevisRepository.DemandeDevisAjouterProduit(ddId, pId);
    }

    public bool DemandeDevisDeleteProduit(int ddId, int pId)
    {
        return _demandeDevisRepository.DemandeDevisDeleteProduit(ddId, pId);
    }

    public IEnumerable<DemandeDevisEntity> GetAll()
    {
        List<DemandeDevisEntity> demandesDevis = _demandeDevisRepository.GetAll().Select(x => x.ToBll()).ToList();
        if (demandesDevis.Count() > 0)
        {
            foreach (DemandeDevisEntity demandeDevis in demandesDevis)
            {
                demandeDevis.Service = _serviceRepository.GetById(demandeDevis.ServiceId)?.ToBll();
            }
        }
        return demandesDevis;
    }

    public IEnumerable<DemandeDevisEntity> GetAllByUserId(int userId)
    {
        List<DemandeDevisEntity> demandesDevis = _demandeDevisRepository.GetAll().Select(x => x.ToBll()).ToList();
        if (demandesDevis.Count() > 0)
        {
            foreach (DemandeDevisEntity demandeDevis in demandesDevis)
            {
                demandeDevis.Service = _serviceRepository.GetById(demandeDevis.ServiceId)?.ToBll();
            }
        }
        return demandesDevis;
    }

    public DemandeDevisEntity? GetById(int key)
    {
        DemandeDevisEntity? demandeDevis = _demandeDevisRepository.GetById(key)?.ToBll();
        if (demandeDevis is null) return null;
        demandeDevis.Service = _serviceRepository.GetById(demandeDevis.ServiceId)?.ToBll();
        return demandeDevis;
    }

    public IEnumerable<ProduitEntity> GetDemandeDevisProduits(int ddId)
    {
        return _demandeDevisRepository.GetDemandeDevisProduits(ddId).Select(x => x.ToBll());
    }

    public DemandeDevisEntity? Submit(int id)
    {
        bool success = _demandeDevisRepository.Submit(id);
        if (!success) return null;
        return GetById(id);
    }

    public DemandeDevisEntity? Update(int key, DemandeDevisEntity entity)
    {
        bool success = _demandeDevisRepository.Update(key, entity.ToDal());
        if (!success) return null;
        return GetById(key);
    }
}
