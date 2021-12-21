using Lemka.BLL.Interfaces;
using Lemka.UIL.Infrastructure;
using Lemka.UIL.Mappers;
using Lemka.UIL.Models;
using Lemka.UIL.Models.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Lemka.UIL.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ITokenManager _tokenManager;

    public AuthController(IAuthService authService, ITokenManager tokenManager)
    {
        _authService = authService;
        _tokenManager = tokenManager;
    }

    [HttpPost(nameof(Login))]
    public IActionResult Login([FromBody] LoginForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            LoggedInUserModel? utilisateur = _authService.Login(form.Email, form.Password)?.ToUil();
            if (utilisateur is null) return NotFound();
            if (!utilisateur.Statut.Contains("Active")) return Forbid();
            TokenModel token = new() { Token = _tokenManager.GenerateJWT(utilisateur) };
            return Ok(token);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost(nameof(Register))]
    public IActionResult Register([FromBody] RegisterForm form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            _authService.Register(form.Email, form.Nom, form.Prenom, form.Password);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
