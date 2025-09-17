using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.UserDTO;

/// <summary>
/// Usado para criação e edição do usuário
/// </summary>
public class UserCreateDTO : Entity
{
    /// <summary>
    /// Usuário do sistema
    /// </summary>
    [MaxLength(200, ErrorMessage = "O nome de usuário não pode ter mais que 200 caracteres.")]
    public required string UserName { get; set; }

    /// <summary>
    /// Nome completo do usuário.
    /// </summary>
    [MaxLength(200, ErrorMessage = "O nome completo não pode ter mais que 200 caracteres.")]
    public required string Name { get; set; }

    /// <summary>
    /// Email do usuário (opcional).
    /// </summary>
    [MaxLength(200, ErrorMessage = "O email não pode ter mais que 200 caracteres.")]
    [EmailAddress(ErrorMessage = "O email informado não é válido.")]
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
