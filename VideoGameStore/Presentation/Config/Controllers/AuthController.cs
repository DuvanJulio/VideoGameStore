using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Application.Interfaces;

namespace VideoGameStore.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public AuthController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    
    //Prueba sin base de datos
    public IActionResult Login()
    {

        var token = _tokenService.GenerateToken(
            idUser: 1,
            email: "admin@videogamestore.com",
            role: "Admin",
            expiration: DateTime.UtcNow.AddHours(1));

        return Ok(new { Token = token });
    }
}