using Application.DTOs.Customer;
using Application.DTOs.Result;
using Kernel.Utils.Pagination;

namespace Application.Service.Interfaces;

/// <summary>
/// Interface para serviços de clientes.
/// Define operações de negócio relacionadas à entidade <see cref="Customer"/>.
/// </summary>
public interface ICustomerService
{
    /// <summary>
    /// Cria um novo cliente.
    /// </summary>
    /// <param name="newCustomer">Objeto contendo os dados do cliente.</param>
    /// <returns>O cliente criado.</returns>
    Task<Result<CustomerViewDTO>> CreateAsync(CustomerCreateDTO newCustomer);

    /// <summary>
    /// Obtém um cliente pelo identificador.
    /// </summary>
    /// <param name="id">Identificador do cliente.</param>
    /// <returns>O cliente encontrado ou <c>null</c>.</returns>
    Task<Result<CustomerViewDTO>> GetByIdAsync(int id);

    /// <summary>
    /// Obtém uma lista paginada de clientes cadastrados.
    /// </summary>
    /// <param name="pagination">Parâmetros de paginação (número da página e tamanho da página).</param>
    /// <returns>Resultado contendo a página de clientes.</returns>
    Task<Result<PagedResult<CustomerViewDTO>>> GetAsync(PaginationParams pagination);

    /// <summary>
    /// Atualiza os dados de um cliente existente.
    /// </summary>
    /// <param name="newCustomer">Objeto contendo os novos dados do cliente.</param>
    /// <returns>O cliente atualizado.</returns>
    Task<Result<CustomerViewDTO>> UpdateAsync(CustomerCreateDTO newCustomer);

    /// <summary>
    /// Remove um cliente pelo identificador.
    /// </summary>
    /// <param name="id">Identificador do cliente.</param>
    /// <returns>O cliente removido.</returns>
    Task<Result<CustomerViewDTO>> DeleteAsync(int id);
}
