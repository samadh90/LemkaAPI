using Lemka.BLL.Entities;

namespace Lemka.BLL.Interfaces;

public interface IMensurationService
{
    IEnumerable<MensurationEntity> GetUserMensurations(int userId);
    MensurationEntity? GetMensuration(int id);
    MensurationEntity? CreateUserMensuration(int userId, MensurationEntity data);
    bool DeleteMensuration(int id);
    MensurationEntity? UpdateMensuration(int id, MensurationEntity data);
    IEnumerable<MensurationMesureEntity> GetMensurationMesures(int id);
    IEnumerable<MensurationMesureEntity> UpdateMesure(int mensurationId, int mesureId, decimal valeur);
}

