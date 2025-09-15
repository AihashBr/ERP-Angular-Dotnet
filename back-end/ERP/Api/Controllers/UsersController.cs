using Application.DTOs.UserDTO;
using Application.Service.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Tags("Usuários")]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // Retorna todos os usuários.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        return Ok(await _userService.GetAsync());
    }

    // Retorna um usuário pelo ID.
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetById(int id)
    {
        return Ok(await _userService.GetByIdAsync(id));
    }

    // Cria um novo usuário.
    [HttpPost]
    public async Task<ActionResult<User>> Create(UserCreateDTO user)
    {
        return Ok(await _userService.CreateAsync(user));
    }

    // Atualiza um usuário existente.
    [HttpPut]
    public async Task<ActionResult<User>> Update(UserCreateDTO user)
    {
        return Ok(await _userService.UpdateAsync(user));
    }

    // Remove um usuário pelo ID.
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _userService.DeleteAsync(id));
    }
}
