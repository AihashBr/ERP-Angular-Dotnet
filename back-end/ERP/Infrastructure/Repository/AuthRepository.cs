using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

// Repositório responsável pela autenticação.
public class AuthRepository : IAuthRepository
{
    private readonly AppDbContext _context;

    public AuthRepository(AppDbContext context)
    {
        _context = context;
    }

    // Autentica um usuário verificando se o nome e a senha correspondem a um usuário ativo no sistema.
    public async Task<User?> AuthenticateUserAsync(string name, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == name);

        if (user == null || !user.Active || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            return null;

        return user;
    }
}
