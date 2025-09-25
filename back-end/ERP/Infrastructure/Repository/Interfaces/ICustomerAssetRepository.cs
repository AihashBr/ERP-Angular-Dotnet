using Domain.Entities;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Interfaces;

/// <summary>
/// Interface para o repositório de bens do cliente.
/// Define as operações de acesso a dados relacionadas à entidade <see cref="CustomerAsset"/>.
/// </summary>
public interface ICustomerAssetRepository
{
    /// <summary>
    /// Adiciona um novo bem do cliente ao banco de dados.
    /// </summary>
    /// <param name="asset">Instância do bem a ser adicionada.</param>
    /// <returns>O bem adicionado.</returns>
    Task<CustomerAsset> AddAsync(CustomerAsset asset);

    /// <summary>
    /// Busca um bem pelo identificador único (Id).
    /// </summary>
    /// <param name="id">Identificador do bem.</param>
    /// <returns>O bem encontrado ou <c>null</c> caso não exista.</returns>
    Task<CustomerAsset?> GetByIdAsync(int id);

    /// <summary>
    /// Busca bens no banco de dados com possibilidade de filtro e ordenação.
    /// </summary>
    /// <param name="filter">Expressão opcional para filtrar os bens.</param>
    /// <param name="orderBy">Função opcional para ordenar os resultados.</param>
    /// <returns>Lista de bens encontrados.</returns>
    Task<List<CustomerAsset>> GetAsync(Expression<Func<CustomerAsset, bool>>? filter = null, Func<IQueryable<CustomerAsset>, IOrderedQueryable<CustomerAsset>>? orderBy = null);

    /// <summary>
    /// Atualiza um bem existente no banco de dados.
    /// </summary>
    /// <param name="asset">Instância do bem com os novos dados.</param>
    /// <returns>O bem atualizado.</returns>
    Task<CustomerAsset> UpdateAsync(CustomerAsset asset);

    /// <summary>
    /// Remove um bem do banco de dados.
    /// </summary>
    /// <param name="asset">Instância do bem a ser removido.</param>
    /// <returns>O bem removido.</returns>
    Task<CustomerAsset> DeleteAsync(CustomerAsset asset);
}
