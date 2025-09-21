using Domain.Entities;

namespace Application.DTOs.Product;
/// <summary>
/// Usado para visualização do produto
/// </summary>
public class ProductViewDTO : Entity
{
    /// <summary>
    /// Nome do produto
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Descrição do produto
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Preço unitário do produto
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Quantidade em estoque
    /// </summary>
    public int StockQuantity { get; set; }

    /// <summary>
    /// Empresa proprietária do produto
    /// </summary>
    public int CompanyId { get; set; }
}
