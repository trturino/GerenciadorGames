using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using trturino.GerenciadorGames.Services.Identity.API.Models;

namespace trturino.GerenciadorGames.Services.Identity.API.Data
{
    public class AppDbContext : IdentityDbContext<Usuario>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public class CatalogContextDesignFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlServer("Server=.;Initial Catalog=trtutino.identitydb;Integrated Security=true");

                return new AppDbContext(optionsBuilder.Options);
            }
        }
    }
}