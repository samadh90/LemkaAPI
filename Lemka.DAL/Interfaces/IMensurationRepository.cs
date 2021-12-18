using Lemka.DAL.Datas;

namespace Lemka.DAL.Interfaces;

public interface IMensurationRepository
{
    IEnumerable<MensurationData> GetUserMensurations(int userId);
    MensurationData? GetMensuration(int id);
    int CreateUserMensuration(int userId, MensurationData data);
    bool DeleteMensuration(int id);
    bool UpdateMensuration(int id, MensurationData data);
    IEnumerable<MensurationMesureData> GetMensurationMesures(int id);
    bool UpdateMesure(int mensurationId, int mesureId, decimal valeur);
}
