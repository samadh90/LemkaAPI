using Lemka.BLL.Interfaces;
using Lemka.UIL.Mappers;
using Lemka.UIL.Models;
using Lemka.UIL.Models.Enums;
using Lemka.UIL.Models.Forms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;

namespace Lemka.UIL.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize("IsConnected")]
public class UtilisateursController : ControllerBase
{
    private readonly IUtilisateurService _utilisateurService;
    private readonly IAdresseService _adresseService;
    private readonly IMensurationService _mensurationService;
    private readonly IDemandeDevisService _demandeDevisService;
    private readonly IDevisService _devisService;
    private readonly IRendezVousService _rendezVousService;
    private readonly IHoraireService _horaireService;

    public UtilisateursController(
        IUtilisateurService utilisateurService,
        IAdresseService adresseService,
        IMensurationService mensurationService,
        IDemandeDevisService demandeDevisService,
        IDevisService devisService,
        IRendezVousService rendezVousService,
        IHoraireService horaireService)
    {
        _utilisateurService = utilisateurService;
        _adresseService = adresseService;
        _mensurationService = mensurationService;
        _demandeDevisService = demandeDevisService;
        _devisService = devisService;
        _rendezVousService = rendezVousService;
        _horaireService = horaireService;
    }

    #region UTILISATEURS

    [HttpGet]
    [Authorize(Roles = "Webmaster,Admin,Staff")]
    public IActionResult Index()
    {
        try
        {
            List<UtilisateurModel> utilisateurs = _utilisateurService.GetAll().Select(x => x.ToUil()).ToList();
            return Ok(utilisateurs);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult Details(int id)
    {
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            UtilisateurModel? utilisateur = _utilisateurService.GetById(id)?.ToUil();
            if (utilisateur is null) return NotFound();

            return Ok(utilisateur);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UtilisateurForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            UtilisateurModel? utilisateur = _utilisateurService.Update(id, form.ToBll())?.ToUil();
            if (utilisateur is null) return BadRequest();

            return Ok(utilisateur);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    #endregion

    #region ADRESSES

    [HttpPost("{id}/Adresse")]
    public IActionResult PostAdresse(int id, [FromBody] AdresseForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            AdresseModel? adresse = _adresseService.CreateUserAdresse(id, form.ToBll())?.ToUil();
            if (adresse is null) return BadRequest();
            return Ok(adresse);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}/Adresse")]
    public IActionResult PutAdresse(int id, [FromBody] AdresseForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            AdresseModel? adresse = _adresseService.UpdateUserAdresse(id, form.ToBll())?.ToUil();
            if (adresse is null) return BadRequest();
            return Ok(adresse);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}/Adresse")]
    public IActionResult DeleteAdresse(int id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            bool success = _adresseService.DeleteUserAdresse(id);
            if (!success) return BadRequest();
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    #endregion

    #region MENSURATIONS

    [HttpGet("{id}/Mensurations")]
    public IActionResult GetMensurations(int id)
    {
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            IEnumerable<MensurationModel> mesnruations = _mensurationService.GetUserMensurations(id).Select(x => x.ToUil());
            return Ok(mesnruations);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}/Mensurations/{mId}")]
    public IActionResult GetMensuration(int id, int mId)
    {
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            MensurationModel? mensuration = _mensurationService.GetMensuration(mId)?.ToUil();
            if (mensuration is null) return NotFound();
            return Ok(mensuration);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("{id}/Mensurations")]
    public IActionResult PostMensuration(int id, [FromBody] MensurationForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            MensurationModel? mensuration = _mensurationService.CreateUserMensuration(id, form.ToBll())?.ToUil();
            if (mensuration is null) return BadRequest();
            return Ok(mensuration);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}/Mensurations/{mId}")]
    public IActionResult PutMensuration(int id, int mId, [FromBody] MensurationForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            MensurationModel? mensuration = _mensurationService.UpdateMensuration(mId, form.ToBll())?.ToUil();
            if (mensuration is null) return BadRequest();
            return Ok(mensuration);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}/Mensurations/{mId}")]
    public IActionResult DeleteMensuration(int id, int mId)
    {
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            bool success = _mensurationService.DeleteMensuration(mId);
            if (!success) return BadRequest();
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    #endregion

    #region MENSURATION-MESURES

    [HttpGet("{id}/Mensurations/{mId}/Mesures")]
    public IActionResult GetMensurationMesures(int id, int mId)
    {
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Forbid();
            IEnumerable<MensurationMesureModel> mesures = _mensurationService.GetMensurationMesures(mId).Select(x => x.ToUil());
            return Ok(mesures);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}/Mensurations/{mId}/Mesures/{mmId}")]
    public IActionResult PutMensurationMesures(int id, int mId, int mmId, [FromBody] MensurationMesureForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            IEnumerable<MensurationMesureModel> mesures = _mensurationService.UpdateMesure(mId, mmId, form.Valeur).Select(x => x.ToUil());
            if (mesures.Count() == 0) return BadRequest();
            return Ok(mesures);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    #endregion

    #region DEMANDES DE DEVIS

    [HttpGet("{id}/DemandesDevis")]
    public IActionResult GetDemandeDevis(int id)
    {
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            IEnumerable<DemandeDevisModel> demandesDevis = _demandeDevisService.GetAllByUserId(id).Select(x => x.ToUil());
            return Ok(demandesDevis);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("{id}/DemandesDevis")]
    public IActionResult PostDemandeDevis(int id, [FromBody] DemandeDevisForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            DemandeDevisModel? demandeDevis = _demandeDevisService.CreateForUser(id, form.ToBll())?.ToUil();
            if (demandeDevis is null) return BadRequest();
            return Ok(demandeDevis);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}/DemandesDevis/{ddId}")]
    public IActionResult GetDemandeDevis(int id, int ddId)
    {
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            DemandeDevisModel? demandeDevis = _demandeDevisService.GetById(ddId)?.ToUil();
            if (demandeDevis is null) return NotFound();
            return Ok(demandeDevis);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}/DemandesDevis/{ddId}")]
    public IActionResult PutDemandeDevis(int id, int ddId, [FromBody] DemandeDevisForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            DemandeDevisModel? demandeDevis = _demandeDevisService.GetById(ddId)?.ToUil();
            if (demandeDevis is null) return NotFound();
            if (demandeDevis.SubmittedAt is not null) return BadRequest("La demande a déjà été soumise.");
            demandeDevis = _demandeDevisService.Update(ddId, form.ToBll())?.ToUil();
            if (demandeDevis is null) return BadRequest();
            return Ok(demandeDevis);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}/DemandesDevis/{ddId}")]
    public IActionResult DeleteDemandeDevis(int id, int ddId)
    {
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            DemandeDevisModel? demandeDevis = _demandeDevisService.GetById(ddId)?.ToUil();
            if (demandeDevis is null) return NotFound();
            if (demandeDevis.DevisStatut is not null) return Forbid();
            bool success = _demandeDevisService.Delete(ddId);
            if (!success) return BadRequest();
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}/DemandesDevis/{ddId}/Soumettre")]
    public IActionResult SubmitDemandeDevis(int id, int ddId)
    {
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            DemandeDevisModel? demandeDevis = _demandeDevisService.GetById(ddId)?.ToUil();
            if (demandeDevis is null) return NotFound();
            if (demandeDevis.SubmittedAt is not null) return BadRequest("La demande a déjà été soumise.");
            demandeDevis = _demandeDevisService.Submit(ddId)?.ToUil();
            if (demandeDevis is null) return BadRequest();
            return Ok(demandeDevis);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    #endregion

    #region DEMANDE DE DEVIS PRODUITS

    [HttpGet("{id}/DemandesDevis/{ddId}/Produits")]
    public IActionResult GetDemandeDevisProduits(int id, int ddId)
    {
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            IEnumerable<ProduitModel> produits = _demandeDevisService.GetDemandeDevisProduits(ddId).Select(x => x.ToUil());
            return Ok(produits);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("{id}/DemandesDevis/{ddId}/Produits")]
    public IActionResult PostDemandeDevisProduits(int id, int ddId)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            bool success = _demandeDevisService.DemandeDevisAjouterProduit(ddId, id);
            if (!success) return BadRequest();
            IEnumerable<ProduitModel> produits = _demandeDevisService.GetDemandeDevisProduits(ddId).Select(x => x.ToUil());
            return Ok(produits);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}/DemandesDevis/{ddId}/Produits/{pId}")]
    public IActionResult DeleteDemandeDevisProduits(int id, int ddId, int pId)
    {
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            bool success = _demandeDevisService.DemandeDevisDeleteProduit(ddId, id);
            if (!success) return BadRequest();
            IEnumerable<ProduitModel> produits = _demandeDevisService.GetDemandeDevisProduits(ddId).Select(x => x.ToUil());
            return Ok(produits);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    #endregion

    #region DEVIS

    [HttpGet("{id}/DemandesDevis/{ddId}/Devis")]
    public IActionResult GetDevis(int id, int ddId)
    {
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            DevisModel? devis = _devisService.GetDevisForDD(ddId)?.ToUil();
            if (devis is null) return NotFound();
            return Ok(devis);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}/DemandesDevis/{ddId}/Devis")]
    public IActionResult PutDevis(int id, int ddId, [FromBody] DevisDecisionForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            DevisModel? devis = _devisService.GetDevisForDD(ddId)?.ToUil();
            if (devis is null) return NotFound();
            if (devis.EstAccepte is not null) return BadRequest("Vous avez déja donnée un décision à ce dévis.");
            bool success = _devisService.DevisDecisionFromUser(ddId, form.EstAccepte);
            if (!success) return BadRequest();
            devis = _devisService.GetDevisForDD(ddId)?.ToUil();
            return Ok(devis);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    #endregion

    #region DEVIS-DETAILS

    [HttpGet("{id}/DemandesDevis/{ddId}/Devis/{dId}/Details")]
    public IActionResult GetDetails(int id, int ddId, int dId)
    {
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();

            IEnumerable<DetailModel> details = _devisService.GetDetailsDuDevis(dId).Select(x => x.ToUil());
            return Ok(details);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    #endregion

    #region RENDEZ-VOUS

    [HttpGet("{id}/RendezVous")]
    public IActionResult GetRendezVous(int id)
    {
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            IEnumerable<RendezVousModel> rendezVous = _rendezVousService.GetUserRendezVous(id).Select(x => x.ToUil());
            return Ok(rendezVous);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("{id}/RendezVous")]
    public IActionResult PostRendezVous(int id, [FromBody] RendezVousForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            string jour = form.Jour.ToString("dddd", new CultureInfo("fr-BE"));
            HoraireModel? horaire = _horaireService.GetById(jour)?.ToUil();
            if (horaire is null) return BadRequest();
            if (horaire.EstFerme) return BadRequest($"Nous sommes fermés le {jour}. Essayez un autre jour!");
            if (horaire.EstFerme is false && horaire.SurRdv is false) return BadRequest($"Le {form.Jour.ToString("D", CultureInfo.CreateSpecificCulture("fr-FR"))} nous sommes ouvert sans rendez-vous de {horaire.HeureOuverture} à {horaire.HeureFermeture}");
            RendezVousModel? rendezVous = _rendezVousService.Create(id, form.ToBll())?.ToUil();
            if (rendezVous is null) return BadRequest();
            return Ok(rendezVous);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}/RendezVous/{rId}")]
    public IActionResult DeleteRendezVous(int id, int rId)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Unauthorized();
            bool success = _rendezVousService.Delete(rId);
            if (!success) return BadRequest();
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    #endregion

    #region AUTRES

    [HttpGet("{id}/Favoris")]
    public IActionResult GetFavoris(int id)
    {
        try
        {
            if (!ConnectedUserIsStaffOrOwner(id)) return Forbid();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}/Password")]
    public IActionResult UpdatePassword(int id, [FromBody] PasswordForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            if (id != GetConnectedUserId()) return Unauthorized();
            bool success = _utilisateurService.UpdatePassword(id, form.OldPassword, form.NewPassword);
            if (!success) return BadRequest();
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{Id}/Role")]
    [Authorize(Roles = "Webmaster,Admin")]
    public IActionResult UpdateRole(int id, [FromBody] UserRoleForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            if (id == GetConnectedUserId()) return Unauthorized();
            // TODO - Admin ne peut pas changer le role de Webmaster et de l'Admin
            bool success = _utilisateurService.UpdateUserRole(id, form.RoleId);
            if (!success) return BadRequest();
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    #endregion

    #region FONCTIONS

    private bool ConnectedUserIsStaffOrOwner(int id)
    {
        string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;
        if (userRole is null) return false;
        bool isAuthorized;
        switch (userRole)
        {
            case nameof(RoleEnum.Webmaster):
                isAuthorized = true;
                break;
            case nameof(RoleEnum.Admin):
                isAuthorized = true;
                break;
            case nameof(RoleEnum.Staff):
                isAuthorized = true;
                break;
            case nameof(RoleEnum.Membre):
                isAuthorized = false;
                break;
            default:
                isAuthorized = false;
                break;
        }
        if (!isAuthorized && id != GetConnectedUserId()) return false;
        return true;
    }

    private int GetConnectedUserId()
    {
        string? userId = User.FindFirst(ClaimTypes.Sid)?.Value;
        return userId == null ? 0 : int.Parse(userId);
    }

    #endregion
}
