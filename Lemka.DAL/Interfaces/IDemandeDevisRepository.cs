using Lemka.DAL.Datas;

namespace Lemka.DAL.Interfaces;

public interface IDemandeDevisRepository
{
    IEnumerable<DemandeDevisData> GetAll();
    IEnumerable<DemandeDevisData> GetAll(int userId);
    DemandeDevisData? GetById(int id);
    int Create(int userId, DemandeDevisData data);
    bool Update(int userId, DemandeDevisData data);
    bool Delete(int id);
    bool Submit(int id);
    IEnumerable<ProduitData> GetProduits(int ddId);
    bool AddProduit(int ddId, int pId);
    bool DeleteProduit(int ddId, int pId);
}
