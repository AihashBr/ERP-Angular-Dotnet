using Application.DTOs.CustomerAsset;
using Application.DTOs.Result;
using Kernel.Utils.Pagination;

namespace Application.Service.Interfaces;
/// <summary>
/// Interface para serviços de bens do cliente.
/// Define operações de negócio relacionadas à entidade <see cref="CustomerAsset"/>.
/// </summary>
public interface ICustomerAssetService
{
    /// <summary>
    /// Cria um novo bem para o cliente.
    /// </summary>
    /// <param name="newAsset">Objeto contendo os dados do bem.</param>
    /// <returns>O bem criado.</returns>
    Task<Result<CustomerAssetViewDTO>> CreateAsync(CustomerAssetCreateDTO newAsset);

    /// <summary>
    /// Obtém um bem do cliente pelo identificador.
    /// </summary>
    /// <param name="id">Identificador do bem.</param>
    /// <returns>O bem encontrado ou <c>null</c>.</returns>
    Task<Result<CustomerAssetViewDTO>> GetByIdAsync(int id);

    /// <summary>
    /// Obtém uma lista paginada de bens do cliente.
    /// </summary>
    /// <param name="pagination">Parâmetros de paginação (número da página e tamanho da página).</param>
    /// <returns>Resultado contendo a página de bens.</returns>
    Task<Result<PagedResult<CustomerAssetViewDTO>>> GetAsync(PaginationParams pagination);

    /// <summary>
    /// Atualiza os dados de um bem existente do cliente.
    /// </summary>
    /// <param name="updatedAsset">Objeto contendo os novos dados do bem.</param>
    /// <returns>O bem atualizado.</returns>
    Task<Result<CustomerAssetViewDTO>> UpdateAsync(CustomerAssetCreateDTO updatedAsset);

    /// <summary>
    /// Remove um bem do cliente pelo identificador.
    /// </summary>
    /// <param name="id">Identificador do bem.</param>
    /// <returns>O bem removido.</returns>
    Task<Result<CustomerAssetViewDTO>> DeleteAsync(int id);
}
