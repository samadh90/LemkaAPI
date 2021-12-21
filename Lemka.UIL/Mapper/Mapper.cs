using DevHopTools.Extensions;
using Lemka.BLL.Entities;
using Lemka.UIL.Models;
using Lemka.UIL.Models.Forms;

namespace Lemka.UIL.Mappers;

internal static class Mapper
{
    internal static LoggedInUserModel ToUil(this LoggedInUserEntity entity)
    {
        return MapperExtension.Map<LoggedInUserModel>(entity);
    }

    // Utilisateur
    internal static UtilisateurModel ToUil(this UtilisateurEntity entity)
    {
        UtilisateurModel utilisateur = MapperExtension.Map<UtilisateurModel>(entity);
        utilisateur.Genre = entity.Genre?.ToUil();
        utilisateur.Adresse = entity.Adresse?.ToUil();
        return utilisateur;
    }

    internal static UtilisateurEntity ToBll(this UtilisateurForm form) => MapperExtension.Map<UtilisateurEntity>(form);

    // Genre
    internal static GenreModel ToUil(this GenreEntity entity) => MapperExtension.Map<GenreModel>(entity);
    internal static GenreEntity ToBll(this GenreForm form) => MapperExtension.Map<GenreEntity>(form);

    // Role
    internal static RoleModel ToUil(this RoleEntity entity) => MapperExtension.Map<RoleModel>(entity);
    internal static RoleEntity ToBll(this RoleForm form) => MapperExtension.Map<RoleEntity>(form);

    // Service
    internal static ServiceModel ToUil(this ServiceEntity entity) => MapperExtension.Map<ServiceModel>(entity);
    internal static ServiceEntity ToBll(this ServiceForm form) => MapperExtension.Map<ServiceEntity>(form);

    // Tag
    internal static TagModel ToUil(this TagEntity entity) => MapperExtension.Map<TagModel>(entity);
    internal static TagEntity ToBll(this TagForm form) => MapperExtension.Map<TagEntity>(form);

    // Tva
    internal static TvaModel ToUil(this TvaEntity entity) => MapperExtension.Map<TvaModel>(entity);
    internal static TvaEntity ToBll(this TvaForm form) => MapperExtension.Map<TvaEntity>(form);

    // Mesure
    internal static MesureModel ToUil(this MesureEntity entity) => MapperExtension.Map<MesureModel>(entity);
    internal static MesureEntity ToBll(this MesureForm form) => MapperExtension.Map<MesureEntity>(form);

    // Adresse
    internal static AdresseModel ToUil(this AdresseEntity entity) => MapperExtension.Map<AdresseModel>(entity);
    internal static AdresseEntity ToBll(this AdresseForm form) => MapperExtension.Map<AdresseEntity>(form);

    // Horaire
    internal static HoraireModel ToUil(this HoraireEntity entity) => MapperExtension.Map<HoraireModel>(entity);
    internal static HoraireEntity ToBll(this HoraireForm form) => MapperExtension.Map<HoraireEntity>(form);

    // Mensuration
    internal static MensurationModel ToUil(this MensurationEntity entity) => MapperExtension.Map<MensurationModel>(entity);
    internal static MensurationEntity ToBll(this MensurationForm form) => MapperExtension.Map<MensurationEntity>(form);

    // Categorie
    internal static CategorieModel ToUil(this CategorieEntity entity) => MapperExtension.Map<CategorieModel>(entity);
    internal static CategorieEntity ToBll(this CategorieForm form) => MapperExtension.Map<CategorieEntity>(form);

    // Mensuration Mesure
    internal static MensurationMesureModel ToUil(this MensurationMesureEntity entity) => MapperExtension.Map<MensurationMesureModel>(entity);
    internal static MensurationMesureEntity ToBll(this MensurationMesureForm form) => MapperExtension.Map<MensurationMesureEntity>(form);

    // Demande de devis
    internal static DemandeDevisModel ToUil(this DemandeDevisEntity entity)
    {
        DemandeDevisModel  demandeDevis = MapperExtension.Map<DemandeDevisModel>(entity);
        demandeDevis.Service = entity.Service?.ToUil();
        return demandeDevis;
    }
    internal static DemandeDevisEntity ToBll(this DemandeDevisForm form) => MapperExtension.Map<DemandeDevisEntity>(form);

    // Produit
    internal static ProduitModel ToUil(this ProduitEntity entity) => MapperExtension.Map<ProduitModel>(entity);
    internal static ProduitEntity ToBll(this ProduitForm form) => MapperExtension.Map<ProduitEntity>(form);

    // Devis
    internal static DevisModel ToUil(this DevisEntity entity) => MapperExtension.Map<DevisModel>(entity);
    internal static DevisEntity ToBll(this DevisForm form) => MapperExtension.Map<DevisEntity>(form);

    // Detail
    internal static DetailModel ToUil(this DetailEntity entity) => MapperExtension.Map<DetailModel>(entity);
    internal static DetailEntity ToBll(this DetailForm form) => MapperExtension.Map<DetailEntity>(form);

    // Rendez vous
    internal static RendezVousModel ToUil(this RendezVousEntity entity)
    {
        RendezVousModel rendezVous = MapperExtension.Map<RendezVousModel>(entity);
        rendezVous.Service = entity.Service?.ToUil();
        rendezVous.Devis = entity.Devis?.ToUil();
        return rendezVous;
    }
    internal static RendezVousEntity ToBll(this RendezVousForm form) => MapperExtension.Map<RendezVousEntity>(form);
}
