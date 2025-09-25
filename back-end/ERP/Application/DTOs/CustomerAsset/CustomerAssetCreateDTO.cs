using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.CustomerAsset;

/// <summary>
/// DTO para criar ou atualizar um bem do cliente.
/// </summary>
public class CustomerAssetCreateDTO : Entity
{
    public int Id { get; set; }

    /// <summary>
    /// Nome do bem.
    /// </summary>
    [Required(ErrorMessage = "O nome do bem é obrigatório.")]
    [MaxLength(200, ErrorMessage = "O nome do bem não pode ter mais de 200 caracteres.")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Descrição do bem.
    /// </summary>
    [MaxLength(500)]
    public string? Description { get; set; }

    /// <summary>
    /// Valor do bem.
    /// </summary>
    public decimal? Value { get; set; }

    /// <summary>
    /// ID do cliente proprietário do bem.
    /// </summary>
    [Required(ErrorMessage = "O cliente é obrigatório.")]
    public int CustomerId { get; set; }
}
