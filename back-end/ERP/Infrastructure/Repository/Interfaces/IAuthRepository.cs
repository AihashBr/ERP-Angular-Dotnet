using Domain.Entities;

namespace Infrastructure.Repository.Interfaces;

/// <summary>
/// Interface para autenticação.
/// </summary>
public interface IAuthRepository
{
    /// <summary>
    /// Autentica um usuário verificando se o nome e a senha correspondem a um usuário ativo no sistema.
    /// </summary>
    /// <param name="name">Nome do usuário para autenticação.</param>
    /// <param name="password">Senha em texto puro que será verificada com o hash armazenado.</param>
    /// <returns>
    /// Retorna o <see cref="User"/> autenticado se o nome e a senha estiverem corretos e o usuário estiver ativo;
    /// caso contrário, retorna <c>null</c>.
    /// </returns>
    Task<User?> AuthenticateUserAsync(string name, string password);
}
