using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using trturino.GerenciadorGames.Services.API.Infra.EntityConfig;

namespace trturino.GerenciadorGames.Services.API.Infra
{
    public class AmigoContext : DbContext
    {
        public AmigoContext(DbContextOptions<AmigoContext> options) : base(options)
        {
        }

        public DbSet<Model.Amigo> Amigos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AmigoEntityConfig());
        }
    }

    public class CatalogContextDesignFactory : IDesignTimeDbContextFactory<AmigoContext>
    {
        public AmigoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AmigoContext>()
                .UseSqlServer("Server=.;Initial Catalog=trtutino.amigodb;Integrated Security=true");

            return new AmigoContext(optionsBuilder.Options);
        }
    }
}