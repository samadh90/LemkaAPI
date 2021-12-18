using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Mappers;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class HoraireService : IHoraireService
{
    private readonly IHoraireRepository _horaireRepository;

    public HoraireService(IHoraireRepository horaireRepository)
    {
        _horaireRepository = horaireRepository;
    }

    public HoraireEntity? Create(HoraireEntity entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(string key)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<HoraireEntity> GetAll()
    {
        return _horaireRepository.GetAll().Select(x => x.ToBll());
    }

    public HoraireEntity? GetById(string key)
    {
        return _horaireRepository.GetById(key)?.ToBll();
    }

    public HoraireEntity? Update(string key, HoraireEntity entity)
    {
        if (entity.EstFerme is true)
        {
            entity.HeureOuverture = null;
            entity.HeureFermeture = null;
            entity.SurRdv = false;
        }
        bool success = _horaireRepository.Update(key, entity.ToDal());
        if (!success) return null;
        return GetById(key);
    }
}
