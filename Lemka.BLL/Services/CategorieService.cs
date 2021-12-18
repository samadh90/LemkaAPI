using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Mappers;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class CategorieService : ICategorieService
{
    private readonly ICategorieRepository _categorieRepository;

    public CategorieService(ICategorieRepository categorieRepository)
    {
        _categorieRepository = categorieRepository;
    }

    public CategorieEntity? Create(CategorieEntity entity)
    {
        int id = _categorieRepository.Create(entity.ToDal());
        if (id == 0) return null;
        return GetById(id);
        throw new NotImplementedException();
    }

    public bool Delete(int key)
    {
        return _categorieRepository.Delete(key);
    }

    public IEnumerable<CategorieEntity> GetAll()
    {
        return _categorieRepository.GetAll().Select(x => x.ToBll());
    }

    public CategorieEntity? GetById(int key)
    {
        return _categorieRepository.GetById(key)?.ToBll();
    }

    public IEnumerable<CategorieEntity> GetEnfants(int id)
    {
        return _categorieRepository.GetEnfants(id).Select(x => x.ToBll());
    }

    public CategorieEntity? Update(int key, CategorieEntity entity)
    {
        bool success = _categorieRepository.Update(key, entity.ToDal());
        if (!success) return null;
        return GetById(key);
    }
}
