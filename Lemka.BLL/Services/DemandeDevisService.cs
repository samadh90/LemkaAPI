using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Mappers;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class DemandeDevisService : IDemandeDevisService
{
    private readonly IDemandeDevisRepository _demandeDevisRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IMensurationRepository _mensurationRepository;

    public DemandeDevisService(IDemandeDevisRepository demandeDevisRepository, IServiceRepository serviceRepository, IMensurationRepository mensurationRepository)
    {
        _demandeDevisRepository = demandeDevisRepository;
        _serviceRepository = serviceRepository;
        _mensurationRepository = mensurationRepository;
    }

    public IEnumerable<DemandeDevisEntity> GetAll()
    {
        IEnumerable<DemandeDevisEntity> demandesDevis = _demandeDevisRepository.GetAll().Select(x => x.ToBll());
        if (demandesDevis.Count() > 0)
        {
            demandesDevis = SetDemandesDevisService(demandesDevis);
        }
        return demandesDevis;
    }

    public IEnumerable<DemandeDevisEntity> GetAll(int userId)
    {
        IEnumerable<DemandeDevisEntity> demandesDevis = _demandeDevisRepository.GetAll(userId).Select(x => x.ToBll());
        if (demandesDevis.Count() > 0)
        {
            demandesDevis = SetDemandesDevisService(demandesDevis);
        }
        return demandesDevis;
    }

    public DemandeDevisEntity? GetById(int id)
    {
        DemandeDevisEntity? demandeDevis = _demandeDevisRepository.GetById(id)?.ToBll();
        if (demandeDevis == null) return null;
        demandeDevis.Service = _serviceRepository.GetById(demandeDevis.ServiceId)?.ToBll();
        return demandeDevis;
    }

    public DemandeDevisEntity? Create(int userId, DemandeDevisEntity entity)
    {
        int id = _demandeDevisRepository.Create(userId, entity.ToDal());
        if (id == 0) return null;
        return GetById(id);
    }

    public DemandeDevisEntity? Update(int userId, DemandeDevisEntity entity)
    {
        bool success = _demandeDevisRepository.Update(userId, entity.ToDal());
        if (!success) return null;
        return GetById(userId);
    }

    public bool Delete(int id)
    {
        return _demandeDevisRepository.Delete(id);
    }

    public bool Submit(int id)
    {
        return _demandeDevisRepository.Submit(id);
    }

    public IEnumerable<ProduitEntity> GetProduits(int ddId)
    {
        throw new NotImplementedException();
    }

    public bool AddProduit(int ddId, int pId)
    {
        throw new NotImplementedException();
    }

    public bool DeleteProduit(int ddId, int pId)
    {
        throw new NotImplementedException();
    }

    private IEnumerable<DemandeDevisEntity> SetDemandesDevisService(IEnumerable<DemandeDevisEntity> list)
    {
        foreach (DemandeDevisEntity item in list)
        {
            item.Service = _serviceRepository.GetById(item.ServiceId)?.ToBll();
            if (item.MensurationId is not null)
            {
                item.Mensuration = _mensurationRepository.GetMensuration((int)item.MensurationId)?.ToBll();
            }
            yield return item;
        }
    }
}
