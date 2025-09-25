using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

/// <summary>
/// Representa um bem (asset) de um cliente.
/// </summary>
public class CustomerAsset
{
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Cliente dono do bem.
    /// </summary>
    public Customer Customer { get; set; } = null!;
    /// <summary>
    /// ID do cliente dono do bem.
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Nome do bem.
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Descrição do bem.
    /// </summary>
    [MaxLength(500)]
    public string? Description { get; set; }

    /// <summary>
    /// Valor do bem.
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Value { get; set; }
}
