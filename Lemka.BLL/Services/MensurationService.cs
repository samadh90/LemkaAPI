using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Mappers;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class MensurationService : IMensurationService
{
    private readonly IMensurationRepository _mensurationRepository;

    public MensurationService(IMensurationRepository mensurationRepository)
    {
        _mensurationRepository = mensurationRepository;
    }

    public MensurationEntity? CreateUserMensuration(int userId, MensurationEntity data)
    {
        int id = _mensurationRepository.CreateUserMensuration(userId, data.ToDal());
        if (id == 0) return null;
        return GetMensuration(id);
    }

    public bool DeleteMensuration(int id)
    {
        return _mensurationRepository.DeleteMensuration(id);
    }

    public MensurationEntity? GetMensuration(int id)
    {
        return _mensurationRepository.GetMensuration(id)?.ToBll();
    }

    public IEnumerable<MensurationMesureEntity> GetMensurationMesures(int id)
    {
        return _mensurationRepository.GetMensurationMesures(id).Select(x => x.ToBll());
    }

    public IEnumerable<MensurationEntity> GetUserMensurations(int userId)
    {
        return _mensurationRepository.GetUserMensurations(userId).Select(x => x.ToBll());
    }

    public MensurationEntity? UpdateMensuration(int id, MensurationEntity data)
    {
        bool success = _mensurationRepository.UpdateMensuration(id, data.ToDal());
        if (!success) return null;
        return GetMensuration(id);
    }

    public IEnumerable<MensurationMesureEntity> UpdateMesure(int mensurationId, int mesureId, decimal valeur)
    {
        bool success = _mensurationRepository.UpdateMesure(mensurationId, mesureId, valeur);
        if (!success) throw new ArgumentException();
        return GetMensurationMesures(mensurationId);
    }
}
