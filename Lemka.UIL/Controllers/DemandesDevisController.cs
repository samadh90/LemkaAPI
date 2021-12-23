using Lemka.BLL.Interfaces;
using Lemka.UIL.Mappers;
using Lemka.UIL.Models;
using Lemka.UIL.Models.Forms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lemka.UIL.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Webmaster,Admin,Staff")]
public class DemandesDevisController : ControllerBase
{
    private readonly IDemandeDevisService _demandeDevisService;
    private readonly IDevisService _devisService;
    private readonly IDetailService _detailService;

    public DemandesDevisController(IDemandeDevisService demandeDevisService, IDevisService devisService, IDetailService detailService)
    {
        _demandeDevisService = demandeDevisService;
        _devisService = devisService;
        _detailService = detailService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            IEnumerable<DemandeDevisModel> demandesDevis = _demandeDevisService.GetAll().Select(x => x.ToUil());
            return Ok(demandesDevis);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            DemandeDevisModel? demandeDevis = _demandeDevisService.GetById(id)?.ToUil();
            if (demandeDevis is null) return NotFound();
            return Ok(demandeDevis);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}/Produits")]
    public IActionResult GetProduits(int id)
    {
        try
        {
            IEnumerable<ProduitModel> produits = _demandeDevisService.GetProduits(id).Select(x => x.ToUil());
            return Ok(produits);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}/Devis")]
    public IActionResult GetDevis(int id)
    {
        try
        {
            DevisModel? devis = _devisService.Get(id)?.ToUil();
            if (devis is null) return NotFound();
            return Ok(devis);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("{id}/Devis")]
    public IActionResult Post(int id, [FromBody] DevisForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            DevisModel? devis = _devisService.Create(id, form.ToBll())?.ToUil();
            if (devis is null) return BadRequest();
            return Ok(devis);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}/Devis")]
    public IActionResult Put(int id, [FromBody] DevisForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            DevisModel? devis = _devisService.Update(id, form.ToBll())?.ToUil();
            if (devis is null) return BadRequest();
            return Ok(devis);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}/Devis/{dId}/Details")]
    public IActionResult GetDevisDetails(int id, int dId)
    {
        try
        {
            IEnumerable<DetailModel> details = _detailService.GetAll(dId).Select(x => x.ToUil());
            return Ok(details);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("{id}/Devis/{dId}/Details")]
    public IActionResult PostDevisDetails(int id, int dId, [FromBody] DetailForm form)
    {
        try
        {
            DetailModel? detail = _detailService.Create(dId, form.ToBll())?.ToUil();
            if (detail is null) return BadRequest();
            return Ok(detail);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}/Devis/{dId}/Details/dtId")]
    public IActionResult PutDevisDetails(int id, int dId, int dtId, [FromBody] DetailForm form)
    {
        try
        {
            DetailModel? detail = _detailService.Update(dId, form.ToBll())?.ToUil();
            if (detail is null) return BadRequest();
            return Ok(detail);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}/Devis/{dId}/Details/dtId")]
    public IActionResult DeleteDevisDetails(int id, int dId, int dtId)
    {
        try
        {
            bool success = _detailService.Delete(dId);
            if (!success) return BadRequest();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
