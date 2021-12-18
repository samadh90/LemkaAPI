using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Mappers;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _serviceRepository;

    public ServiceService(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public ServiceEntity? Create(ServiceEntity entity)
    {
        int id = _serviceRepository.Create(entity.ToDal());
        if (id == 0) return null;
        return GetById(id);
    }

    public bool Delete(int key)
    {
        return _serviceRepository.Delete(key);
    }

    public IEnumerable<ServiceEntity> GetAll()
    {
        return _serviceRepository.GetAll().Select(x => x.ToBll());
    }

    public ServiceEntity? GetById(int key)
    {
        return _serviceRepository.GetById(key)?.ToBll();
    }

    public ServiceEntity? Update(int key, ServiceEntity entity)
    {
        bool success = _serviceRepository.Update(key, entity.ToDal());
        if (!success) return null;
        return GetById(key);
    }
}
