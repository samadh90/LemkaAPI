using Lemka.BLL.Entities;
using Lemka.BLL.Interfaces;
using Lemka.BLL.Mappers;
using Lemka.DAL.Interfaces;

namespace Lemka.BLL.Services;

public class UtilisateurService : IUtilisateurService
{
    private readonly IUtilisateurRepository _utilisateurRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IAdresseRepository _adresseRepository;

    public UtilisateurService(IUtilisateurRepository utilisateurRepository, IGenreRepository genreRepository, IAdresseRepository adresseRepository)
    {
        _utilisateurRepository = utilisateurRepository;
        _genreRepository = genreRepository;
        _adresseRepository = adresseRepository;
    }

    public IEnumerable<UtilisateurEntity> GetAll()
    {
        List<UtilisateurEntity> utilisateurs = _utilisateurRepository.GetAll().Select(x => x.ToBll()).ToList();

        if (utilisateurs.Count() > 0)
        {
            foreach(UtilisateurEntity utilisateur in utilisateurs)
            {
                if (utilisateur.GenreId is not null)
                {
                    utilisateur.Genre = _genreRepository.GetById((int)utilisateur.GenreId)?.ToBll();
                }
            }
        }

        return utilisateurs.AsEnumerable();
    }

    public UtilisateurEntity? GetById(int id)
    {
        UtilisateurEntity? utilisateur = _utilisateurRepository.GetById(id)?.ToBll();
        if (utilisateur == null) return null;
        if (utilisateur.GenreId is not null) utilisateur.Genre = _genreRepository.GetById((int)utilisateur.GenreId)?.ToBll();
        utilisateur.Adresse = _adresseRepository.GetUserAdresse(id)?.ToBll();
        return utilisateur;
    }

    public UtilisateurEntity? Update(int id, UtilisateurEntity entity)
    {
        bool success = _utilisateurRepository.Update(id, entity.ToDal());
        if (!success) return null;
        return GetById(id);
    }

    public bool UpdatePassword(int id, string oldPassword, string newPassword)
    {
        return _utilisateurRepository.UpdatePassword(id, oldPassword, newPassword);
    }

    public bool UpdateUserRole(int userId, int roleId)
    {
        return _utilisateurRepository.UpdateUserRole(userId, roleId);
    }
}
