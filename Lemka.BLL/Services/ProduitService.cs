using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Mappers;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class ProduitService : IProduitService
{
    private readonly IProduitRepository _produitRepository;

    public ProduitService(IProduitRepository produitRepository)
    {
        _produitRepository = produitRepository;
    }

    public ProduitEntity? Create(ProduitEntity entity)
    {
        int id = _produitRepository.Create(entity.ToDal());
        if (id == 0) return null;
        return GetById(id);
    }

    public bool Delete(int key)
    {
        return _produitRepository.Delete(key);
    }

    public IEnumerable<ProduitEntity> GetAll()
    {
        return _produitRepository.GetAll().Select(x => x.ToBll());
    }

    public IEnumerable<ProduitEntity> GetAll(string? search)
    {
        return _produitRepository.GetAll(search).Select(x => x.ToBll());
    }

    public ProduitEntity? GetById(int key)
    {
        return _produitRepository.GetById(key)?.ToBll();
    }

    public ProduitEntity? Update(int key, ProduitEntity entity)
    {
        bool success = _produitRepository.Update(key, entity.ToDal());
        if (!success) return null;
        return GetById(key);
    }
}
