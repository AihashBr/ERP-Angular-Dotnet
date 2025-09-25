using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

/// <summary>
/// Representa um usuário do sistema.
/// </summary>
public class User : Entity
{
    /// <summary>
    /// Usuario do sistema
    /// </summary>
    [MaxLength(200)]
    public required string UserName { get; set; }

    /// <summary>
    /// Nome completo do usuário.
    /// </summary>
    [MaxLength(200)]
    public required string Name { get; set; }

    /// <summary>
    /// Email do usuário (opcional).
    /// </summary>
    [MaxLength(200)]
    [EmailAddress]
    public string? Email { get; set; }

    /// <summary>
    /// Senha do usuário (hash).
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Indica se o usuário está ativo.
    /// </summary>
    public bool Active { get; set; }

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
    /// <summary>
    /// Id da cidade.
    /// </summary>
    public int? CityId { get; set; }
}