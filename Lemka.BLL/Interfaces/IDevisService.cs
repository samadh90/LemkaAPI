using Lemka.BLL.Entities;

namespace Lemka.BLL.Interfaces;

public interface IDevisService
{
    DevisEntity? Get(int demandeDevisId);
    DevisEntity? Create(int demandeDevisId, DevisEntity data);
    DevisEntity? Update(int demandeDevisId, DevisEntity devisData);
    DevisEntity? Update(int demandeDevisId, bool accepter);
    bool Delete(int demandeDevisId);
}