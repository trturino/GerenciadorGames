using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using trturino.GerenciadorGames.Services.Emprestimo.API.Infra.EntityConfig;

namespace trturino.GerenciadorGames.Services.Emprestimo.API.Infra
{
    public class EmprestimoContext : DbContext
    {
        public EmprestimoContext(DbContextOptions<EmprestimoContext> options) : base(options)
        {
        }

        public DbSet<API.Model.Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GameEntityConfig());
        }
    }

    public class CatalogContextDesignFactory : IDesignTimeDbContextFactory<EmprestimoContext>
    {
        public EmprestimoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmprestimoContext>()
                .UseSqlServer("Server=.;Initial Catalog=trtutino.gamedb;Integrated Security=true");

            return new EmprestimoContext(optionsBuilder.Options);
        }
    }
}