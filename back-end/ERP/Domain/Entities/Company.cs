using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

/// <summary>
/// Representa uma empresa no sistema
/// </summary>
public class Company : Entity
{
    /// <summary>
    /// Razão social da empresa
    /// </summary>
    [MaxLength(200)]
    public required string Name { get; set; }

    /// <summary>
    /// CNPJ
    /// </summary>
    [MaxLength(18)]
    public required string Cnpj { get; set; }

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
    /// Bairro
    /// </summary>
    [MaxLength(150)]
    public string? District { get; set; }

    /// <summary>
    /// Complemento
    /// </summary>
    [MaxLength(250)]
    public string? Complement { get; set; }

    /// <summary>
    /// Cidade Id
    /// </summary>
    public City? City { get; set; }
    public int? CityId { get; set; }

}