using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Mappers;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class DemandeDevisService : IDemandeDevisService
{
    private readonly IDemandeDevisRepository _demandeDevisRepository;

    public DemandeDevisService(IDemandeDevisRepository demandeDevisRepository)
    {
        _demandeDevisRepository = demandeDevisRepository;
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
        return _demandeDevisRepository.GetAll().Select(x => x.ToBll());
    }

    public IEnumerable<DemandeDevisEntity> GetAllByUserId(int userId)
    {
        return _demandeDevisRepository.GetAllByUserId(userId).Select(x => x.ToBll());
    }

    public DemandeDevisEntity? GetById(int key)
    {
        return _demandeDevisRepository.GetById(key)?.ToBll();
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
