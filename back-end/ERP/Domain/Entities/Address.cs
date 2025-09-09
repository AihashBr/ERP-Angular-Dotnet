using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

/// <summary>
/// Representa um endereço no sistema
/// </summary>
public class Address : Entity
{
    /// <summary>
    /// Nome ou rótulo do endereço (ex.: Casa, Trabalho)
    /// </summary>
    [MaxLength(200)]
    public required string Name { get; set; }

    /// <summary>
    /// Rua
    /// </summary>
    [MaxLength(200)]
    public string? Street { get; set; }

    /// <summary>
    /// Número
    /// </summary>
    [MaxLength(100)]
    public string? Number { get; set; }

    /// <summary>
    /// Cidade
    /// </summary>
    public int? CityId { get; set; }
    public City? City { get; set; }
}
