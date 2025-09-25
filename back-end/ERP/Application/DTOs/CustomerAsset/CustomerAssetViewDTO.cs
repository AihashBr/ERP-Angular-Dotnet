using Domain.Entities;

namespace Application.DTOs.CustomerAsset;

/// <summary>
/// DTO para exibir informações de um bem do cliente.
/// </summary>
public class CustomerAssetViewDTO : Entity
{
    /// <summary>
    /// Identificador do bem.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nome do bem.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Descrição do bem.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Valor do bem.
    /// </summary>
    public decimal? Value { get; set; }

    /// <summary>
    /// ID do cliente proprietário do bem.
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Nome do cliente proprietário.
    /// </summary>
    public string? CustomerName { get; set; }
}
