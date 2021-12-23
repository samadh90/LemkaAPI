using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Mappers;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class RendezVousService : IRendezVousService
{
    private readonly IRendezVousRepository _rendezVousRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IDevisRepository _devisRepository;

    public RendezVousService(
        IRendezVousRepository rendezVousRepository, 
        IServiceRepository serviceRepository, 
        IDevisRepository devisRepository)
    {
        _rendezVousRepository = rendezVousRepository;
        _serviceRepository = serviceRepository;
        _devisRepository = devisRepository;
    }

    public RendezVousEntity? Create(RendezVousEntity entity)
    {
        int id = _rendezVousRepository.Create(entity.ToDal());
        if (id == 0) return null;
        return GetById(id);
    }

    public RendezVousEntity? Create(int userId, RendezVousEntity data)
    {
        int id = _rendezVousRepository.Create(userId, data.ToDal());
        if (id == 0) return null;
        return GetById(id);
    }

    public bool Delete(int key)
    {
        return _rendezVousRepository.Delete(key);
    }

    public IEnumerable<RendezVousEntity> GetAll()
    {
        return _rendezVousRepository.GetAll().Select(x => x.ToBll());
    }

    public RendezVousEntity? GetById(int key)
    {
        RendezVousEntity? rendezVous = _rendezVousRepository.GetById(key)?.ToBll();
        if (rendezVous is null) return null;
        rendezVous.Service = _serviceRepository.GetById(rendezVous.ServiceId)?.ToBll();
        if (rendezVous.DevisId is not null) rendezVous.Devis = _devisRepository.Get(key)?.ToBll();
        return rendezVous;
    }

    public IEnumerable<RendezVousEntity> GetUserRendezVous(int userId)
    {
        return _rendezVousRepository.GetUserRendezVous(userId).Select(x => x.ToBll());
    }

    public RendezVousEntity? Update(int key, RendezVousEntity entity)
    {
        bool success = _rendezVousRepository.Update(key, entity.ToDal());
        if (!success) return null;
        return GetById(key);
    }
}
