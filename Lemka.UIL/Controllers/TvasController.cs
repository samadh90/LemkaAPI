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
[Authorize(Roles = "Admin")]
public class TvasController : ControllerBase
{
    private readonly ITvaService _tvaService;

    public TvasController(ITvaService tvaService)
    {
        _tvaService = tvaService;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Get()
    {
        try
        {
            IEnumerable<TvaModel> tvas = _tvaService.GetAll().Select(x => x.ToUil());
            return Ok(tvas);
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
            TvaModel? tva = _tvaService.GetById(id)?.ToUil();
            if (tva is null) return NotFound();
            return Ok(tva);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] TvaForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            TvaModel? tva = _tvaService.Create(form.ToBll())?.ToUil();
            if (tva is null) return BadRequest();
            return Ok(tva);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TvaForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            TvaModel? tva = _tvaService.Update(id, form.ToBll())?.ToUil();
            if (tva is null) return BadRequest();
            return Ok(tva);
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
            bool success = _tvaService.Delete(id);
            if (!success) return BadRequest();
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}

