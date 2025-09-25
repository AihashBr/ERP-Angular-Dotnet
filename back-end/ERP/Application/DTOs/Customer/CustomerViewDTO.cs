using Domain.Entities;

namespace Application.DTOs.Customer;

/// <summary>
/// DTO para exibir informações do cliente.
/// </summary>
public class CustomerViewDTO : Entity
{
    /// <summary>
    /// Identificador do cliente.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nome do cliente.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Email do cliente.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Telefone do cliente.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Data de nascimento do cliente.
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// Rua do cliente.
    /// </summary>
    public string? Street { get; set; }

    /// <summary>
    /// Número do endereço.
    /// </summary>
    public string? Number { get; set; }

    /// <summary>
    /// Bairro do cliente.
    /// </summary>
    public string? District { get; set; }

    /// <summary>
    /// Complemento do endereço.
    /// </summary>
    public string? Complement { get; set; }

    /// <summary>
    /// Nome da cidade.
    /// </summary>
    public string? CityName { get; set; }

    /// <summary>
    /// ID da cidade.
    /// </summary>
    public int? CityId { get; set; }

    /// <summary>
    /// Indica se o cliente está ativo.
    /// </summary>
    public bool Active { get; set; }
}
