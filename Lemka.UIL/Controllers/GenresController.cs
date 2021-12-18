using Lemka.BLL.Interfaces;
using Lemka.UIL.Mappers;
using Lemka.UIL.Models;
using Lemka.UIL.Models.Forms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lemka.UIL.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "SuperAdmin,Admin,Staff")]
public class GenresController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenresController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Get()
    {
        try
        {
            List<GenreModel> genres = _genreService.GetAll().Select(x => x.ToUil()).ToList();
            return Ok(genres);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            GenreModel? genre = _genreService.GetById(id)?.ToUil();
            if (genre is null) return NotFound();

            return Ok(genre);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] GenreForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            GenreModel? genre = _genreService.Create(form.ToBll())?.ToUil();
            if (genre is null) return NotFound();
            return Ok(genre);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] GenreForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            GenreModel? genre = _genreService.Update(id, form.ToBll())?.ToUil();
            if (genre is null) return NotFound();
            return Ok(genre);
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
            bool success = _genreService.Delete(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
