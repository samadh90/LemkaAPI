using Lemka.BLL.Entities;

namespace Lemka.BLL.Interfaces;

public interface IDemandeDevisService
{
    IEnumerable<DemandeDevisEntity> GetAll();
    IEnumerable<DemandeDevisEntity> GetAll(int userId);
    DemandeDevisEntity? GetById(int id);
    DemandeDevisEntity? Create(int userId, DemandeDevisEntity entity);
    DemandeDevisEntity? Update(int userId, DemandeDevisEntity entity);
    bool Delete(int id);
    bool Submit(int id);
    IEnumerable<ProduitEntity> GetProduits(int ddId);
    bool AddProduit(int ddId, int pId);
    bool DeleteProduit(int ddId, int pId);
}
