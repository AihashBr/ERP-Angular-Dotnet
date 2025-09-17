using Application.DTOs.Company;
using Application.DTOs.Result;
using Kernel.Utils.Pagination;

namespace Application.Service.Interfaces;

/// <summary>
/// Interface para serviços de empresas.
/// Define operações de negócio relacionadas à entidade <see cref="Company"/>.
/// </summary>
public interface ICompanyService
{
    /// <summary>
    /// Cria uma nova empresa.
    /// </summary>
    /// <param name="newCompany">Objeto contendo os dados da empresa.</param>
    /// <returns>A empresa criada.</returns>
    Task<Result<CompanyViewDTO>> CreateAsync(CompanyCreateDTO newCompany);

    /// <summary>
    /// Obtém uma empresa pelo identificador.
    /// </summary>
    /// <param name="id">Identificador da empresa.</param>
    /// <returns>A empresa encontrada ou <c>null</c>.</returns>
    Task<Result<CompanyViewDTO>> GetByIdAsync(int id);

    /// <summary>
    /// Obtém uma lista paginada de empresas cadastradas.
    /// </summary>
    /// <param name="pagination">Parâmetros de paginação (número da página e tamanho da página).</param>
    /// <returns>Resultado contendo a página de empresas.</returns>
    Task<Result<PagedResult<CompanyViewDTO>>> GetAsync(PaginationParams pagination);

    /// <summary>
    /// Atualiza os dados de uma empresa existente.
    /// </summary>
    /// <param name="newCompany">Objeto contendo os novos dados da empresa.</param>
    /// <returns>A empresa atualizada.</returns>
    Task<Result<CompanyViewDTO>> UpdateAsync(CompanyCreateDTO newCompany);

    /// <summary>
    /// Remove uma empresa pelo identificador.
    /// </summary>
    /// <param name="id">Identificador da empresa.</param>
    /// <returns>A empresa removida.</returns>
    Task<Result<CompanyViewDTO>> DeleteAsync(int id);
}
