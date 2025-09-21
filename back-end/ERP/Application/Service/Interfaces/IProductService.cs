using Application.DTOs.Product;
using Application.DTOs.Result;
using Kernel.Utils.Pagination;

namespace Application.Service.Interfaces;

/// <summary>
/// Interface para serviços de produtos.
/// Define operações de negócio relacionadas à entidade <see cref="Product"/>.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Cria um novo produto.
    /// </summary>
    /// <param name="newProduct">Objeto contendo os dados do produto.</param>
    /// <returns>O produto criado.</returns>
    Task<Result<ProductViewDTO>> CreateAsync(ProductCreateDTO newProduct);

    /// <summary>
    /// Obtém um produto pelo identificador.
    /// </summary>
    /// <param name="id">Identificador do produto.</param>
    /// <returns>O produto encontrado ou <c>null</c>.</returns>
    Task<Result<ProductViewDTO>> GetByIdAsync(int id);

    /// <summary>
    /// Obtém uma lista paginada de produtos cadastrados.
    /// </summary>
    /// <param name="pagination">Parâmetros de paginação (número da página e tamanho da página).</param>
    /// <returns>Resultado contendo a página de produtos.</returns>
    Task<Result<PagedResult<ProductViewDTO>>> GetAsync(PaginationParams pagination);

    /// <summary>
    /// Atualiza os dados de um produto existente.
    /// </summary>
    /// <param name="newProduct">Objeto contendo os novos dados do produto.</param>
    /// <returns>O produto atualizado.</returns>
    Task<Result<ProductViewDTO>> UpdateAsync(ProductCreateDTO newProduct);

    /// <summary>
    /// Remove um produto pelo identificador.
    /// </summary>
    /// <param name="id">Identificador do produto.</param>
    /// <returns>O produto removido.</returns>
    Task<Result<ProductViewDTO>> DeleteAsync(int id);
}
