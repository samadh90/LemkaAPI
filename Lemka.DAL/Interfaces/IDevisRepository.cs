using Lemka.DAL.Datas;

namespace Lemka.DAL.Interfaces;

public interface IDevisRepository
{
    DevisData? Get(int demandeDevisId);
    bool Create(int demandeDevisId, DevisData data);
    bool Update(int demandeDevisId, DevisData devisData);
    bool Update(int demandeDevisId, bool accepter);
    bool Delete(int demandeDevisId);
}
