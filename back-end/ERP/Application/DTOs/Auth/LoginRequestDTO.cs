namespace Application.DTOs.Auth;

/// <summary>
/// Representa os dados enviados pelo usuário para autenticação.
/// </summary>
public class LoginRequestDTO
{
    /// <summary>
    /// Nome do usuário.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Senha do usuário.
    /// </summary>
    public string Password { get; set; } = null!;
}
