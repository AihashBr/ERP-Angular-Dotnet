using Application.DTOs.Result;
using Application.DTOs.UserDTO;
using Domain.Entities;
using Kernel.Utils.Pagination;

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
    /// Obtém uma lista paginada de usuários cadastrados.
    /// </summary>
    /// <param name="pagination">Parâmetros de paginação (número da página e tamanho da página).</param>
    /// <returns>Resultado contendo a página de usuários.</returns>
    Task<Result<PagedResult<UserViewDTO>>> GetAsync(PaginationParams pagination);

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
