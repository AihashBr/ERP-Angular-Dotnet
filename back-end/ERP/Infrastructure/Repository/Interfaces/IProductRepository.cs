using Domain.Entities;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Interfaces;

/// <summary>
/// Interface para o repositório de produtos.
/// Define as operações de acesso a dados relacionadas à entidade <see cref="Product"/>.
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Adiciona um novo produto ao banco de dados.
    /// </summary>
    /// <param name="product">Instância do produto a ser adicionada.</param>
    /// <returns>O produto adicionado.</returns>
    Task<Product> AddAsync(Product product);

    /// <summary>
    /// Busca um produto pelo identificador único (Id).
    /// </summary>
    /// <param name="id">Identificador do produto.</param>
    /// <returns>O produto encontrado ou <c>null</c> caso não exista.</returns>
    Task<Product?> GetByIdAsync(int id);

    /// <summary>
    /// Busca produtos no banco de dados com possibilidade de filtro e ordenação.
    /// </summary>
    /// <param name="filter">Expressão opcional para filtrar os produtos.</param>
    /// <param name="orderBy">Função opcional para ordenar os resultados.</param>
    /// <returns>Lista de produtos encontrados.</returns>
    Task<List<Product>> GetAsync(
        Expression<Func<Product, bool>>? filter = null,
        Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null);

    /// <summary>
    /// Atualiza um produto existente no banco de dados.
    /// </summary>
    /// <param name="product">Instância do produto com os novos dados.</param>
    /// <returns>O produto atualizado.</returns>
    Task<Product> UpdateAsync(Product product);

    /// <summary>
    /// Remove um produto do banco de dados.
    /// </summary>
    /// <param name="product">Instância do produto a ser removido.</param>
    /// <returns>O produto removido.</returns>
    Task<Product> DeleteAsync(Product product);
}
