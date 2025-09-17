using Domain.Entities;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Interfaces;

/// <summary>
/// Interface para o repositório de empresas.
/// Define as operações de acesso a dados relacionadas à entidade <see cref="Company"/>.
/// </summary>
public interface ICompanyRepository
{
    /// <summary>
    /// Adiciona uma nova empresa ao banco de dados.
    /// </summary>
    /// <param name="company">Instância da empresa a ser adicionada.</param>
    /// <returns>A empresa adicionada.</returns>
    Task<Company> AddAsync(Company company);

    /// <summary>
    /// Busca uma empresa pelo identificador único (Id).
    /// </summary>
    /// <param name="id">Identificador da empresa.</param>
    /// <returns>A empresa encontrada ou <c>null</c> caso não exista.</returns>
    Task<Company?> GetByIdAsync(int id);

    /// <summary>
    /// Busca empresas no banco de dados com possibilidade de filtro e ordenação.
    /// </summary>
    /// <param name="filter">Expressão opcional para filtrar as empresas.</param>
    /// <param name="orderBy">Função opcional para ordenar os resultados.</param>
    /// <returns>Lista de empresas encontradas.</returns>
    Task<List<Company>> GetAsync(Expression<Func<Company, bool>>? filter = null, Func<IQueryable<Company>, IOrderedQueryable<Company>>? orderBy = null);

    /// <summary>
    /// Atualiza uma empresa existente no banco de dados.
    /// </summary>
    /// <param name="company">Instância da empresa com os novos dados.</param>
    /// <returns>A empresa atualizada.</returns>
    Task<Company> UpdateAsync(Company company);

    /// <summary>
    /// Remove uma empresa do banco de dados.
    /// </summary>
    /// <param name="company">Instância da empresa a ser removida.</param>
    /// <returns>A empresa removida.</returns>
    Task<Company> DeleteAsync(Company company);
}
