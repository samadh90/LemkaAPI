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
public class CategoriesController : ControllerBase
{
    private readonly ICategorieService _categorieService;

    public CategoriesController(ICategorieService categorieService)
    {
        _categorieService = categorieService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            IEnumerable<CategorieModel> categories = _categorieService.GetAll().Select(x => x.ToUil());
            return Ok(categories);
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
            CategorieModel? categorie = _categorieService.GetById(id)?.ToUil();
            if (categorie is null) return NotFound();
            return Ok(categorie);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Authorize(Roles = "SuperAdmin,Admin,Staff")]
    public IActionResult Post([FromBody] CategorieForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            CategorieModel? categorie = _categorieService.Create(form.ToBll())?.ToUil();
            if (categorie is null) return BadRequest();
            return Ok(categorie);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "SuperAdmin,Admin,Staff")]
    public IActionResult Put(int id, [FromBody] CategorieForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            CategorieModel? categorie = _categorieService.Update(id, form.ToBll())?.ToUil();
            if (categorie is null) return BadRequest();
            return Ok(categorie);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "SuperAdmin,Admin,Staff")]
    public IActionResult Delete(int id)
    {
        try
        {
            bool success = _categorieService.Delete(id);
            if (!success) return BadRequest();
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet("{id}/Enfants")]
    public IActionResult GetEnfants(int id)
    {
        try
        {
            IEnumerable<CategorieModel> categories = _categorieService.GetEnfants(id).Select(x => x.ToUil());
            return Ok(categories);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
