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
public class ServicesController : ControllerBase
{
    private readonly IServiceService _serviceService;

    public ServicesController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Get()
    {
        try
        {
            IEnumerable<ServiceModel> services = _serviceService.GetAll().Select(x => x.ToUil());
            return Ok(services);
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
            ServiceModel? service = _serviceService.GetById(id)?.ToUil();
            if (service is null) return NotFound();
            return Ok(service);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] ServiceForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            ServiceModel? service = _serviceService.Create(form.ToBll())?.ToUil();
            if (service is null) return NotFound();
            return Ok(service);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ServiceForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            ServiceModel? service = _serviceService.Update(id, form.ToBll())?.ToUil();
            if (service is null) return NotFound();
            return Ok(service);
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
            bool success = _serviceService.Delete(id);
            if (!success) return BadRequest();
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
