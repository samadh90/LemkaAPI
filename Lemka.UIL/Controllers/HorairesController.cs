using Lemka.BLL.Interfaces;
using Lemka.UIL.Mappers;
using Lemka.UIL.Models;
using Lemka.UIL.Models.Forms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lemka.UIL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HorairesController : ControllerBase
{
    private readonly IHoraireService _horaireService;

    public HorairesController(IHoraireService horaireService)
    {
        _horaireService = horaireService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            IEnumerable<HoraireModel> horaires = _horaireService.GetAll().Select(x => x.ToUil());
            return Ok(horaires);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{jour}")]
    public IActionResult Get(string jour)
    {
        try
        {
            HoraireModel? horaire = _horaireService.GetById(jour)?.ToUil();
            if (horaire is null) return NotFound();
            return Ok(horaire);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{jour}")]
    [Authorize(Roles = "SuperAdmin,Admin,Staff")]
    public IActionResult Put(string jour, [FromBody] HoraireForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            HoraireModel? horaire = _horaireService.Update(jour, form.ToBll())?.ToUil();
            if (horaire is null) return BadRequest();
            return Ok(horaire);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
