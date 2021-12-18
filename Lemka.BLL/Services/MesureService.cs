using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Mappers;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class MesureService : IMesureService
{
    private readonly IMesureRepository _mesureRepository;

    public MesureService(IMesureRepository mesureRepository)
    {
        _mesureRepository = mesureRepository;
    }

    public MesureEntity? Create(MesureEntity entity)
    {
        int id = _mesureRepository.Create(entity.ToDal());
        if (id == 0) return null;
        return GetById(id);
    }

    public bool Delete(int key)
    {
        return _mesureRepository.Delete(key);
    }

    public IEnumerable<MesureEntity> GetAll()
    {
        return _mesureRepository.GetAll().Select(x => x.ToBll());
    }

    public MesureEntity? GetById(int key)
    {
        return _mesureRepository.GetById(key)?.ToBll();
    }

    public MesureEntity? Update(int key, MesureEntity entity)
    {
        bool success = _mesureRepository.Update(key, entity.ToDal());
        if (!success) return null;
        return GetById(key);
    }
}

