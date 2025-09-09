using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

/// <summary>
/// Representa um usuário do sistema.
/// </summary>
public class User : Entity
{
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
    /// IDs das empresas às quais o usuário pertence.
    /// </summary>
    public required List<int> CompanyId { get; set; }
}