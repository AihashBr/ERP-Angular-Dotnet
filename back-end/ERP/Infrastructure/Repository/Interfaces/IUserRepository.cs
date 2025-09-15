using Domain.Entities;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Interfaces;

/// <summary>
/// Interface para repositório de usuários.
/// Define operações básicas de CRUD.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Adiciona um novo usuário ao repositório.
    /// </summary>
    /// <param name="user">Objeto do tipo <see cref="User"/> a ser adicionado.</param>
    /// <returns>O usuário criado.</returns>
    Task<User> AddAsync(User user);

    /// <summary>
    /// Busca um usuário pelo identificador único.
    /// </summary>
    /// <param name="id">Identificador do usuário.</param>
    /// <returns>O usuário encontrado ou <c>null</c> se não existir.</returns>
    Task<User?> GetByIdAsync(int id);

    /// <summary>
    /// Obtém usuários do repositório com suporte a filtro e ordenação.
    /// </summary>
    /// <param name="filter">
    /// Expressão lambda opcional para filtrar os resultados.  
    /// Exemplo: <c>u => u.IsActive</c>.
    /// </param>
    /// <param name="orderBy">
    /// Função opcional para ordenar os resultados.  
    /// Exemplo: <c>q => q.OrderBy(u => u.Name)</c>.
    /// </param>
    /// <returns>
    /// Uma coleção de usuários que atendem aos critérios especificados.
    /// </returns>
    Task<List<User>> GetAsync(Expression<Func<User, bool>>? filter = null, Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null);

    /// <summary>
    /// Atualiza os dados de um usuário existente.
    /// </summary>
    /// <param name="user">Objeto do tipo <see cref="User"/> com os dados atualizados.</param>
    /// <returns>O usuário atualizado.</returns>
    Task<User> UpdateAsync(User user);

    /// <summary>
    /// Remove um usuário pelo identificador único.
    /// </summary>
    /// <param name="id">Identificador do usuário.</param>
    /// <returns><c>true</c> se o usuário foi removido, caso contrário <c>false</c>.</returns>
    Task<User> DeleteAsync(User id);
}
