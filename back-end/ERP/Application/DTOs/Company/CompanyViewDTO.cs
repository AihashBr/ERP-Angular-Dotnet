using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Company;

/// <summary>
/// Usado para visualização da empresa
/// </summary>
public class CompanyViewDTO : Entity
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
    /// Endereço da empresa
    /// </summary>
    public int? AddressId { get; set; }
    public Address? Address { get; set; }
}
