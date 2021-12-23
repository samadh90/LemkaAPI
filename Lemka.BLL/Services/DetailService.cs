using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Mappers;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class DetailService : IDetailService
{
    private readonly IDetailRepository _detailRepository;

    public DetailService(IDetailRepository detailRepository)
    {
        _detailRepository = detailRepository;
    }

    public DetailEntity? Create(int devisId, DetailEntity entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        return _detailRepository.Delete(id);
    }

    public IEnumerable<DetailEntity> GetAll(int devisId)
    {
        return _detailRepository.GetAll(devisId).Select(x => x.ToBll());
    }

    public DetailEntity? GetById(int id)
    {
        return _detailRepository.GetById(id)?.ToBll();
    }

    public DetailEntity? Update(int id, DetailEntity entity)
    {
        bool success = _detailRepository.Update(id, entity.ToDal());
        if (!success) return null;
        return GetById(id);
    }
}
