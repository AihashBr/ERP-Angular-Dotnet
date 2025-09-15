using Application.DTOs.Result;
using Application.DTOs.UserDTO;
using Domain.Entities;

namespace Application.Service.Interfaces;

/// <summary>
/// Interface para serviços de usuários.
/// Define operações de negócio relacionadas ao usuário.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Cria um novo usuário.
    /// </summary>
    /// <param name="user">Objeto do tipo <see cref="User"/>.</param>
    /// <returns>O usuário criado.</returns>
    Task<Result<UserViewDTO>> CreateAsync(UserCreateDTO newUser);

    /// <summary>
    /// Obtém um usuário pelo identificador.
    /// </summary>
    /// <param name="id">Identificador do usuário.</param>
    /// <returns>O usuário encontrado ou <c>null</c>.</returns>
    Task<Result<UserViewDTO>> GetByIdAsync(int id);

    /// <summary>
    /// Obtém todos os usuários cadastrados.
    /// </summary>
    /// <returns>Lista de usuários.</returns>
    Task<Result<List<UserViewDTO>>> GetAsync();

    /// <summary>
    /// Atualiza os dados de um usuário.
    /// </summary>
    /// <param name="user">Objeto do tipo <see cref="User"/> atualizado.</param>
    /// <returns>O usuário atualizado.</returns>
    Task<Result<UserViewDTO>> UpdateAsync(UserCreateDTO newUser);

    /// <summary>
    /// Remove um usuário pelo identificador.
    /// </summary>
    /// <param name="id">Identificador do usuário.</param>
    /// <returns><c>true</c> se removido com sucesso.</returns>
    Task<Result<UserViewDTO>> DeleteAsync(int id);
}
