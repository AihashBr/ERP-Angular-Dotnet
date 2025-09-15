namespace Application.DTOs.Auth;

/// <summary>
/// Representa os dados enviados pelo usuário para autenticação.
/// </summary>
public class LoginRequestDTO
{
    /// <summary>
    /// Nome do usuário.
    /// </summary>
    public required string UserName { get; set; }

    /// <summary>
    /// Senha do usuário.
    /// </summary>
    public required string Password { get; set; }
}
