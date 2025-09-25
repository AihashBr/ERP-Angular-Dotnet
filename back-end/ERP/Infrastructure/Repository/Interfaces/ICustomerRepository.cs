using Domain.Entities;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Interfaces;

/// <summary>
/// Interface para o repositório de clientes.
/// Define as operações de acesso a dados relacionadas à entidade <see cref="Customer"/>.
/// </summary>
public interface ICustomerRepository
{
    /// <summary>
    /// Adiciona um novo cliente ao banco de dados.
    /// </summary>
    /// <param name="customer">Instância do cliente a ser adicionada.</param>
    /// <returns>O cliente adicionado.</returns>
    Task<Customer> AddAsync(Customer customer);

    /// <summary>
    /// Busca um cliente pelo identificador único (Id).
    /// </summary>
    /// <param name="id">Identificador do cliente.</param>
    /// <returns>O cliente encontrado ou <c>null</c> caso não exista.</returns>
    Task<Customer?> GetByIdAsync(int id);

    /// <summary>
    /// Busca clientes no banco de dados com possibilidade de filtro e ordenação.
    /// </summary>
    /// <param name="filter">Expressão opcional para filtrar os clientes.</param>
    /// <param name="orderBy">Função opcional para ordenar os resultados.</param>
    /// <returns>Lista de clientes encontrados.</returns>
    Task<List<Customer>> GetAsync(Expression<Func<Customer, bool>>? filter = null, Func<IQueryable<Customer>, IOrderedQueryable<Customer>>? orderBy = null);

    /// <summary>
    /// Atualiza um cliente existente no banco de dados.
    /// </summary>
    /// <param name="customer">Instância do cliente com os novos dados.</param>
    /// <returns>O cliente atualizado.</returns>
    Task<Customer> UpdateAsync(Customer customer);

    /// <summary>
    /// Remove um cliente do banco de dados.
    /// </summary>
    /// <param name="customer">Instância do cliente a ser removida.</param>
    /// <returns>O cliente removido.</returns>
    Task<Customer> DeleteAsync(Customer customer);
}
