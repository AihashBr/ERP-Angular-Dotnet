using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Customer;
/// <summary>
/// DTO para criar ou atualizar clientes.
/// </summary>
public class CustomerCreateDTO : Entity
{
    public int Id { get; set; }

    /// <summary>
    /// Nome do cliente.
    /// </summary>
    [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
    [MaxLength(200, ErrorMessage = "O nome do cliente não pode ter mais de 200 caracteres.")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Email do cliente.
    /// </summary>
    [EmailAddress(ErrorMessage = "O email informado não é válido.")]
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
    /// ID da cidade.
    /// </summary>
    public int? CityId { get; set; }
}
