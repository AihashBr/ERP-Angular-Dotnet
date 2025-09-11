using Domain.Entities;

namespace Infrastructure.Repository.Interfaces;

/// <summary>
/// Interface para repositório de usuários.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Obtém um usuário pelo email.
    /// </summary>
    /// <param name="email">Email do usuário.</param>
    /// <returns>Retorna o usuário ou null se não existir.</returns>
    Task<User?> GetByEmailAsync(string email);
}
