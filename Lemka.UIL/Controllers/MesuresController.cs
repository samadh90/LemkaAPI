using Lemka.BLL.Interfaces;
using Lemka.UIL.Mappers;
using Lemka.UIL.Models;
using Lemka.UIL.Models.Forms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Lemka.UIL.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class MesuresController : ControllerBase
{
    private readonly IMesureService _mesureService;

    public MesuresController(IMesureService mesureService)
    {
        _mesureService = mesureService;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Get()
    {
        try
        {
            IEnumerable<MesureModel> mesures = _mesureService.GetAll().Select(x => x.ToUil());
            return Ok(mesures);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public IActionResult Get(int id)
    {
        try
        {
            MesureModel? mesure = _mesureService.GetById(id)?.ToUil();
            if (mesure is null) return NotFound();
            return Ok(mesure);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] MesureForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            MesureModel? mesure = _mesureService.Create(form.ToBll())?.ToUil();
            if (mesure is null) return BadRequest();
            return Ok(mesure);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] MesureForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            MesureModel? mesure = _mesureService.Update(id, form.ToBll())?.ToUil();
            if (mesure is null) return BadRequest();
            return Ok(mesure);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            bool success = _mesureService.Delete(id);
            if (!success) return BadRequest();
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
