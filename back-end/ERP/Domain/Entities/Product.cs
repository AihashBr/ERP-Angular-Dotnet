using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

/// <summary>
/// Representa um produto no sistema
/// </summary>
public class Product : Entity
{
    /// <summary>
    /// Nome do produto
    /// </summary>
    [MaxLength(200)]
    public required string Name { get; set; }

    /// <summary>
    /// Descrição do produto
    /// </summary>
    [MaxLength(1000)]
    public string? Description { get; set; }

    /// <summary>
    /// Preço unitário
    /// </summary>
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    /// <summary>
    /// Quantidade em estoque
    /// </summary>
    [Range(0, int.MaxValue)]
    public int StockQuantity { get; set; }

    /// <summary>
    /// Empresa proprietária do produto
    /// </summary>
    public Company? Company { get; set; }
    public int CompanyId { get; set; }
}
