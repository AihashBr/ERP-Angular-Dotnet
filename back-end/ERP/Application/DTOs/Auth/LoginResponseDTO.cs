namespace Application.DTOs.Auth;

/// <summary>
/// Representa a resposta retornada após login bem-sucedido.
/// </summary>
public class LoginResponseDTO
{
    /// <summary>
    /// Token JWT gerado para o usuário.
    /// </summary>
    public string Token { get; set; } = null!;

    /// <summary>
    /// Nome do usuário autenticado.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Indica se o usuário está ativo.
    /// </summary>
    public bool Active { get; set; }
}
