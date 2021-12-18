using Lemka.BLL.Entities;

namespace Lemka.BLL.Interfaces;

public interface IDemandeDevisService : IServiceBase<int, DemandeDevisEntity>
{
    IEnumerable<DemandeDevisEntity> GetAllByUserId(int userId);
    DemandeDevisEntity? CreateForUser(int userId, DemandeDevisEntity entity);
    DemandeDevisEntity? Submit(int id);
    IEnumerable<ProduitEntity> GetDemandeDevisProduits(int ddId);
    bool DemandeDevisAjouterProduit(int ddId, int pId);
    bool DemandeDevisDeleteProduit(int ddId, int pId);
}
