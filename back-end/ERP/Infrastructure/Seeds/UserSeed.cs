using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Seeds
{
    /// <summary>
    /// Classe responsável por criar o usuário admin inicial.
    /// </summary>
    public static class UserSeed
    {
        /// <summary>
        /// Garante que exista um usuário admin no banco.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public static void SeedAdminUser(AppDbContext context)
        {
            // Verifica se já existe algum usuário
            if (context.Users.Any())
                return;

            // Cria hash seguro da senha
            string passwordHash = BCrypt.Net.BCrypt.HashPassword("123");

            var adminUser = new User
            {
                UserName = "adm",
                Name = "Admin",
                Email = "admin@erp.com",
                Password = passwordHash,
                Active = true,
                CompanyId = [1],
                CreatedAt = new DateTime(2025, 01, 01, 20, 0, 0),
                CreatedBy = "system"
            };

            // Adiciona e salva no banco
            context.Users.Add(adminUser);
            context.SaveChanges();
        }
    }
}
