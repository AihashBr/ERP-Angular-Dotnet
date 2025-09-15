using Application.DTOs.Auth;
using Application.DTOs.Result;
using Application.Service.Interfaces;
using Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Service;

// Service responsável pela autenticação de usuários e geração de token JWT.
public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IAuthRepository _authRepository;

    public AuthService(IConfiguration configuration, IAuthRepository authRepository)
    {
        _configuration = configuration;
        _authRepository = authRepository;
    }

    public async Task<Result<LoginResponseDTO>> LoginAsync(LoginRequestDTO loginRequest)
    {
        var user = await _authRepository.AuthenticateUserAsync(loginRequest.UserName, loginRequest.Password);
        if (user == null) return new Result<LoginResponseDTO> { Success = false, Message = "Usuário ou senha inválidos." };

        var jwtKey = _configuration["Jwt:Key"];
        if (string.IsNullOrEmpty(jwtKey)) throw new InvalidOperationException("Erro interno LOG-001.");

        var keyBytes = Encoding.ASCII.GetBytes(jwtKey);
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Name)
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return new Result<LoginResponseDTO>
        {
            Success = true,
            Message = "Login realizado com sucesso.",
            Data = new LoginResponseDTO
            {
                Token = tokenHandler.WriteToken(token),
                User = user,
                Active = user.Active
            }
        };
    }
}
