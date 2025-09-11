using Application.DTOs.Auth;
using Application.DTOs.Result;

namespace Application.Service.Interfaces;

/// <summary>
/// Interface para autenticação de usuários e geração de token JWT.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Realiza o login do usuário, gerando um token JWT se a autenticação for bem-sucedida.
    /// </summary>
    /// <param name="loginRequest">Objeto contendo os dados de login (nome e senha).</param>
    /// <returns>
    /// Retorna um <see cref="ResultDTO{LoginResponseDTO}"/> que contém os status e Token JWT se estiver tudo certo.
    /// </returns>
    Task<ResultDTO<LoginResponseDTO>> LoginAsync(LoginRequestDTO loginRequest);
}
