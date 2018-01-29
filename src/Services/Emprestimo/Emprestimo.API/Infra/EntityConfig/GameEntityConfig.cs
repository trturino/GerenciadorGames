using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace trturino.GerenciadorGames.Services.Emprestimo.API.Infra.EntityConfig
{
    public class GameEntityConfig
        : IEntityTypeConfiguration<Model.Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Model.Emprestimo> builder)
        {
            builder.ToTable("Emprestimos");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .ForSqlServerUseSequenceHiLo("emprestimo_id_hilo")
                .IsRequired();
        }
    }
}