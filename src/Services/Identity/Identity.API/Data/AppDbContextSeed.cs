using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using trturino.GerenciadorGames.Services.Identity.API.Models;

namespace trturino.GerenciadorGames.Services.Identity.API.Data
{
    public class AppDbContextSeed
    {
        private readonly IPasswordHasher<Usuario> _passwordHasher = new PasswordHasher<Usuario>();

        public async Task SeedAsync(
            AppDbContext context, 
            IHostingEnvironment env,
            IOptions<AppSettings> settings
            )
        {
            try
            {
                if (!context.Users.Any())
                {
                    context.Users.Add(GetUsuario());

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private Usuario GetUsuario()
        {
            var usuario = new Usuario()
            {
                Email = "demo@demo.com",
                Id = Guid.NewGuid().ToString(),
                Nome = "Demo",
                UserName = "demo@demo.com",
                NormalizedEmail = "demo@demo.com",
                NormalizedUserName = "demo@demo.com",
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };

            usuario.PasswordHash = _passwordHasher.HashPassword(usuario, "12345");

            return usuario;
        }
    }
}
