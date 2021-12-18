using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Mappers;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class TvaService : ITvaService
{
    private readonly ITvaRepository _tvaRepository;

    public TvaService(ITvaRepository tvaRepository)
    {
        _tvaRepository = tvaRepository;
    }

    public TvaEntity? Create(TvaEntity entity)
    {
        int id = _tvaRepository.Create(entity.ToDal());
        if (id == 0) return null;
        return GetById(id);
    }

    public bool Delete(int key)
    {
        return _tvaRepository.Delete(key);
    }

    public IEnumerable<TvaEntity> GetAll()
    {
        return _tvaRepository.GetAll().Select(x => x.ToBll());
    }

    public TvaEntity? GetById(int key)
    {
        return _tvaRepository.GetById(key)?.ToBll();
    }

    public TvaEntity? Update(int key, TvaEntity entity)
    {
        bool success = _tvaRepository.Update(key, entity.ToDal());
        if (!success) return null;
        return GetById(key);
    }
}
