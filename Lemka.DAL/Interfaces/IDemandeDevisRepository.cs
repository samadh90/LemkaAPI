using Lemka.DAL.Datas;

namespace Lemka.DAL.Interfaces;

public interface IDemandeDevisRepository : IRepositoryBase<int, DemandeDevisData>
{
    IEnumerable<DemandeDevisData> GetAllByUserId(int userId);
    int CreateForUser(int userId, DemandeDevisData data);
    bool Submit(int id);
    IEnumerable<ProduitData> GetDemandeDevisProduits(int ddId);
    bool DemandeDevisAjouterProduit(int ddId, int pId);
    bool DemandeDevisDeleteProduit(int ddId, int pId);
}
