using System.Data;
using Lemka.DAL.Datas;

namespace Lemka.DAL.Mappers;

internal static class Mapper
{
    internal static LoggedInUserData ToLoggedInUser(this IDataRecord record)
    {
        return new() {
            Id = (int)record["Id"],
            Email = (string)record["Email"],
            Role = (string)record["Role"],
            Statut = (string)record["Statut"]
        };
    }

    internal static UtilisateurData ToUtilisateur(this IDataRecord record)
    {
        return new() {
            Id = (int)record["Id"],
            Email = (string)record["Email"],
            Tel = (record["Tel"] is DBNull) ? null : (string)record["Tel"],
            Image = (record["Image"] is DBNull) ? null : (string)record["Image"],
            Prenom = (record["Prenom"] is DBNull) ? null : (string)record["Prenom"],
            Nom = (record["Nom"] is DBNull) ? null : (string)record["Nom"],
            GenreId = (record["GenreId"] is DBNull) ? null : (int)record["GenreId"],
            Role = (string)record["Role"],
            Statut = (string)record["Statut"],
            LastLogin = (record["LastLogin"] is DBNull) ? null : (DateTime)record["LastLogin"],
            CreatedAt = (DateTime)record["CreatedAt"],
            UpdatedAt = (record["UpdatedAt"] is DBNull) ? null : (DateTime)record["UpdatedAt"]
        };
    }

    internal static RoleData ToRole(this IDataRecord record)
    {
        return new() {
            Id = (int)record["Id"],
            Nom = (string)record["Nom"]
        };
    }

    internal static GenreData ToGenre(this IDataRecord record)
    {
        return new() {
            Id = (int)record["Id"],
            Nom = (string)record["Nom"]
        };
    }

    internal static ServiceData ToService(this IDataRecord record)
    {
        return new() {
            Id = (int)record["Id"],
            Nom = (string)record["Nom"],
            DureeMinute = (int)record["DureeMinute"],
        };
    }

    internal static TagData ToTag(this IDataRecord record)
    {
        return new() {
            Id = (int)record["Id"],
            Nom = (string)record["Nom"]
        };
    }

    internal static TvaData ToTva(this IDataRecord record)
    {
        return new() {
            Id = (int)record["Id"],
            Taux = (float)record["Taux"],
            Applicable = (bool)record["Applicable"]
        };
    }

    internal static MesureData ToMesure(this IDataRecord record)
    {
        return new() {
            Id = (int)record["Id"],
            Nom = (string)record["Nom"],
            Description = (record["Description"] is DBNull) ? null : (string)record["Description"],
            Image = (record["Image"] is DBNull) ? null : (string)record["Image"]
        };
    }

    internal static AdresseData ToAdresse(this IDataRecord record)
    {
        return new() {
            Pays = (string)record["Pays"],
            Ville = (string)record["Ville"],
            CodePostal = (string)record["CodePostal"],
            Rue = (string)record["Rue"],
            Numero = (string)record["Numero"],
            Boite = (record["Boite"] is DBNull) ? null : (string)record["Boite"]
        };
    }

    internal static MensurationData ToMensuration(this IDataRecord record)
    {
        return new() {
            Id = (int)record["Id"],
            Titre = (string)record["Titre"],
            Description = (record["Description"] is DBNull) ? null : (string)record["Description"],
            IsMain = (bool)record["IsMain"]
        };
    }

    internal static HoraireData ToHoraire(this IDataRecord record)
    {
        return new() {
            Id = (int)record["Id"],
            Jour = (string)record["Jour"],
            JourSemaine = (int)record["JourSemaine"],
            HeureOuverture = (record["HeureOuverture"] is DBNull) ? null : (TimeSpan)record["HeureOuverture"],
            HeureFermeture = (record["HeureFermeture"] is DBNull) ? null : (TimeSpan)record["HeureFermeture"],
            SurRdv = (bool)record["SurRdv"],
            EstFerme = (bool)record["EstFerme"]
        };
    }

    internal static CategorieData ToCategorie(this IDataRecord record)
    {
        return new() {
            Id = (int)record["Id"],
            ParentId = (record["ParentId"] is DBNull) ? null : (int)record["ParentId"],
            Nom = (string)record["Nom"],
            NbEnfants = (int)record["NbEnfants"]
        };
    }

    internal static MensurationMesureData ToMensurationMesure(this IDataRecord record)
    {
        return new() {
            Id = (int)record["Id"],
            Nom = (string)record["Nom"],
            Description = (record["Description"] is DBNull) ? null : (string)record["Description"],
            Image = (record["Image"] is DBNull) ? null : (string)record["Image"],
            Valeur = (decimal)record["Valeur"]
        };
    }

    internal static RendezVousData ToRendezVous(this IDataRecord record)
    {
        return new() {
            Id = (int)record["Id"],
            Jour = (DateTime)record["Jour"],
            HeureDebut = (TimeSpan)record["HeureDebut"],
            HeureFin = (TimeSpan)record["HeureFin"],
            UtilisateurId = (int)record["ParentId"],
            ServiceId = (int)record["ServiceId"],
            DevisId = (record["DevisId"] is DBNull) ? null : (int)record["DevisId"],
            CreatedAt = (DateTime)record["CreatedAt"],
            CanceledAt = (record["CanceledAt"] is DBNull) ? null : (DateTime)record["CanceledAt"]
        };
    }

    internal static DemandeDevisData ToDemandeDevis(this IDataRecord record)
    {
        return new() {
            Id = (int)record["Id"],
            UtilisateurId = (int)record["UtilisateurId"],
            Reference = (string)record["Reference"],
            Titre = (string)record["Titre"],
            Remarque = (record["Remarque"] is DBNull) ? null : (string)record["Remarque"],
            MensurationId = (record["MensurationId"] is DBNull) ? null : (int)record["MensurationId"],
            ServiceId = (int)record["ServiceId"],
            EstUrgent = (bool)record["EstUrgent"],
            CreatedAt = (DateTime)record["CreatedAt"],
            SubmittedAt = (record["SubmittedAt"] is DBNull) ? null : (DateTime)record["SubmittedAt"],
            DevisStatut = (record["DevisStatut"] is DBNull) ? null : (bool)record["DevisStatut"],
            DevisDecision = (record["DevisDecision"] is DBNull) ? null : (bool)record["DevisDecision"],
            EstArchive = (bool)record["EstArchive"]
        };
    }

    internal static DevisData ToDevis(this IDataRecord record)
    {
        return new() {
            Id = (int)record["Id"],
            Reference = (string)record["Reference"],
            Remarque = (record["Remarque"] is DBNull) ? null : (string)record["Remarque"],
            TotalTva = (record["TotalTva"] is DBNull) ? null : (decimal)record["TotalTva"],
            TotalHT = (record["TotalHT"] is DBNull) ? null : (decimal)record["TotalHT"],
            TotalTTC = (record["TotalTTC"] is DBNull) ? null : (decimal)record["TotalTTC"],
            EstAccepte = (record["EstAccepte"] is DBNull) ? null : (bool)record["EstAccepte"],
            CreatedAt = (DateTime)record["CreatedAt"],
            SubmittedAt = (record["SubmittedAt"] is DBNull) ? null : (DateTime)record["SubmittedAt"],
            ExpiresAt = (record["SubmittedAt"] is DBNull) ? null : (DateTime)record["SubmittedAt"],
            ExpiresInDays = (int)record["ExpiresInDays"]
        };
    }

    internal static ProduitData ToProduit(this IDataRecord record)
    {
        return new() {
            Id = (int)record["Id"],
            Slug = (string)record["Slug"],
            Titre = (string)record["Titre"],
            Description = (record["Description"] is DBNull) ? null : (string)record["Description"],
            Prix = (decimal)record["Prix"],
            Tva = (decimal)record["Tva"],
            IsPromotion = (bool)record["IsPromotion"],
            Statut = (string)record["Statut"],
            Image = (record["Image"] is DBNull) ? null : (string)record["Image"],
            EnAffiche = (bool)record["EnAffiche"],
            CreatedAt = (DateTime)record["CreatedAt"],
            UpdatedAt = (record["UpdatedAt"] is DBNull) ? null : (DateTime)record["UpdatedAt"],
        };
    }

    internal static DetailData ToDetail(this IDataRecord record)
    {
        return new() {
            Id = (int)record["Id"],
            DevisId = (int)record["DevisId"],
            Designation = (string)record["Designation"],
            PrixUHt = (decimal)record["PrixUHt"],
            Quantite = (double)record["Quantite"],
            Tva = (double)record["Tva"],
        };
    }
}