using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using trturino.GerenciadorGames.Services.Game.API.Infra.EntityConfig;

namespace trturino.GerenciadorGames.Services.Game.API.Infra
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }

        public DbSet<Model.Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GameEntityConfig());
        }
    }

    public class CatalogContextDesignFactory : IDesignTimeDbContextFactory<GameContext>
    {
        public GameContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GameContext>()
                .UseSqlServer("Server=.;Initial Catalog=trtutino.gamedb;Integrated Security=true");

            return new GameContext(optionsBuilder.Options);
        }
    }
}