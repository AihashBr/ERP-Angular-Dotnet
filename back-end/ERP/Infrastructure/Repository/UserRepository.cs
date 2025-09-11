using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

/// <summary>
/// Implementação do repositório de usuários usando Entity Framework Core.
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Construtor do repositório.
    /// </summary>
    /// <param name="context">Contexto do banco de dados.</param>
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Obtém um usuário pelo email.
    /// </summary>
    /// <param name="email">Email do usuário.</param>
    /// <returns>Usuário encontrado ou null.</returns>
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
