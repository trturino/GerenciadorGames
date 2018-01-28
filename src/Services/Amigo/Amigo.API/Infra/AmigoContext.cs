using Microsoft.EntityFrameworkCore;
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
}