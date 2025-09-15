using Domain.Entities;

namespace Application.DTOs.Auth;

/// <summary>
/// Representa a resposta retornada após login bem-sucedido.
/// </summary>
public class LoginResponseDTO
{
    /// <summary>
    /// Token JWT gerado para o usuário.
    /// </summary>
    public required string Token { get; set; }

    /// <summary>
    /// Nome do usuário autenticado.
    /// </summary>
    public required User User { get; set; }

    /// <summary>
    /// Indica se o usuário está ativo.
    /// </summary>
    public bool Active { get; set; }
}
