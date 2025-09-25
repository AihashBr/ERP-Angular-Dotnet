using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
/// <summary>
/// Representa um cliente do sistema.
/// </summary>
public class Customer : Entity
{
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Nome do cliente.
    /// </summary>
    public required string Name { get; set; } = null!;

    /// <summary>
    /// Email do cliente.
    /// </summary>
    [MaxLength(200)]
    public string? Email { get; set; }

    /// <summary>
    /// Telefone do cliente.
    /// </summary>
    [MaxLength(20)]
    public string? Phone { get; set; }

    /// <summary>
    /// Data de nascimento do cliente.
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// Rua do cliente.
    /// </summary>
    [MaxLength(200)]
    public string? Street { get; set; }

    /// <summary>
    /// Número do endereço.
    /// </summary>
    [MaxLength(100)]
    public string? Number { get; set; }

    /// <summary>
    /// Bairro do cliente.
    /// </summary>
    [MaxLength(150)]
    public string? District { get; set; }

    /// <summary>
    /// Complemento do endereço.
    /// </summary>
    [MaxLength(250)]
    public string? Complement { get; set; }

    /// <summary>
    /// Cidade do cliente.
    /// </summary>
    public City? City { get; set; }
    /// <summary>
    /// Id da cidade.
    /// </summary>
    public int CityId { get; set; }

    /// <summary>
    /// Indica se o cliente está ativo.
    /// </summary>
    public bool Active { get; set; } = true;
}