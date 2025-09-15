using Domain.Entities;

namespace Application.DTOs.UserDTO;

public class UserViewDTO : Entity
{

    /// <summary>
    /// Usuario do sistema
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// Nome completo do usuário.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Email do usuário (opcional).
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Indica se o usuário está ativo.
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// IDs das empresas às quais o usuário pertence.
    /// </summary>
    public List<int>? CompanyId { get; set; }
}