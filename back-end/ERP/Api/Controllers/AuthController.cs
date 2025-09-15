using Application.DTOs.Auth;
using Application.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Controller responsável pelos endpoints de autenticação.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    // Realiza o login do usuário, gerando um token JWT se a autenticação for bem-sucedida.
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequest)
    {
        return Ok(await _authService.LoginAsync(loginRequest));
    }
}