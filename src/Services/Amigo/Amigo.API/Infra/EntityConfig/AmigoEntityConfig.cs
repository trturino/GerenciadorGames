using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using trturino.GerenciadorGames.Services.API.Model;

namespace trturino.GerenciadorGames.Services.API.Infra.EntityConfig
{
    public class AmigoEntityConfig
        : IEntityTypeConfiguration<Amigo>
    {
        public void Configure(EntityTypeBuilder<Amigo> builder)
        {
            builder.ToTable("Amigos");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .ForSqlServerUseSequenceHiLo("amigo_id_hilo")
                .IsRequired();

            builder.Property(cb => cb.Nome)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
