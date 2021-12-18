using DevHopTools.Mappers;
using Lemka.BLL.Entities;
using Lemka.DAL.Datas;

namespace Lemka.BLL.Mappers;

internal static class Mapper
{
    // Logged User Info
    internal static LoggedInUserEntity ToBll(this LoggedInUserData data) => MapperExtension.Map<LoggedInUserEntity>(data);

    // Utilisateur
    internal static UtilisateurEntity ToBll(this UtilisateurData data) => MapperExtension.Map<UtilisateurEntity>(data);

    internal static UtilisateurData ToDal(this UtilisateurEntity entity) => MapperExtension.Map<UtilisateurData>(entity);

    // Genre
    internal static GenreEntity ToBll(this GenreData data) => MapperExtension.Map<GenreEntity>(data);

    internal static GenreData ToDal(this GenreEntity entity) => MapperExtension.Map<GenreData>(entity);

    // Role
    internal static RoleEntity ToBll(this RoleData data) => MapperExtension.Map<RoleEntity>(data);

    internal static RoleData ToDal(this RoleEntity entity) => MapperExtension.Map<RoleData>(entity);

    // Service
    internal static ServiceEntity ToBll(this ServiceData data) => MapperExtension.Map<ServiceEntity>(data);

    internal static ServiceData ToDal(this ServiceEntity entity) => MapperExtension.Map<ServiceData>(entity);

    // Tag
    internal static TagEntity ToBll(this TagData data) => MapperExtension.Map<TagEntity>(data);

    internal static TagData ToDal(this TagEntity entity) => MapperExtension.Map<TagData>(entity);

    // Tva
    internal static TvaEntity ToBll(this TvaData data) => MapperExtension.Map<TvaEntity>(data);

    internal static TvaData ToDal(this TvaEntity entity) => MapperExtension.Map<TvaData>(entity);

    // Mesure
    internal static MesureEntity ToBll(this MesureData data) => MapperExtension.Map<MesureEntity>(data);

    internal static MesureData ToDal(this MesureEntity entity) => MapperExtension.Map<MesureData>(entity);

    // Adresse
    internal static AdresseEntity ToBll(this AdresseData data) => MapperExtension.Map<AdresseEntity>(data);

    internal static AdresseData ToDal(this AdresseEntity entity) => MapperExtension.Map<AdresseData>(entity);

    // Horaire
    internal static HoraireEntity ToBll(this HoraireData data) => MapperExtension.Map<HoraireEntity>(data);

    internal static HoraireData ToDal(this HoraireEntity entity) => MapperExtension.Map<HoraireData>(entity);

    // Mensuration
    internal static MensurationEntity ToBll(this MensurationData data) => MapperExtension.Map<MensurationEntity>(data);

    internal static MensurationData ToDal(this MensurationEntity entity) => MapperExtension.Map<MensurationData>(entity);

    // Categorie
    internal static CategorieEntity ToBll(this CategorieData data) => MapperExtension.Map<CategorieEntity>(data);

    internal static CategorieData ToDal(this CategorieEntity entity) => MapperExtension.Map<CategorieData>(entity);

    // Mensuration mesure
    internal static MensurationMesureEntity ToBll(this MensurationMesureData data) => MapperExtension.Map<MensurationMesureEntity>(data);

    internal static MensurationMesureData ToDal(this MensurationMesureEntity entity) => MapperExtension.Map<MensurationMesureData>(entity);

    // Demande de devis
    internal static DemandeDevisEntity ToBll(this DemandeDevisData data) => MapperExtension.Map<DemandeDevisEntity>(data);

    internal static DemandeDevisData ToDal(this DemandeDevisEntity entity) => MapperExtension.Map<DemandeDevisData>(entity);

    // Devis
    internal static DevisEntity ToBll(this DevisData data) => MapperExtension.Map<DevisEntity>(data);

    internal static DevisData ToDal(this DevisEntity entity) => MapperExtension.Map<DevisData>(entity);

    // Detail
    internal static DetailEntity ToBll(this DetailData data) => MapperExtension.Map<DetailEntity>(data);

    internal static DetailData ToDal(this DetailEntity entity) => MapperExtension.Map<DetailData>(entity);

    // Rendez Vous
    internal static RendezVousEntity ToBll(this RendezVousData data) => MapperExtension.Map<RendezVousEntity>(data);

    internal static RendezVousData ToDal(this RendezVousEntity entity) => MapperExtension.Map<RendezVousData>(entity);

    // Produit
    internal static ProduitEntity ToBll(this ProduitData data) => MapperExtension.Map<ProduitEntity>(data);

    internal static ProduitData ToDal(this ProduitEntity entity) => MapperExtension.Map<ProduitData>(entity);
}
