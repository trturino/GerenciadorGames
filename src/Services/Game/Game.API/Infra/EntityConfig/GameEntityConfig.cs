using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace trturino.GerenciadorGames.Services.Game.API.Infra.EntityConfig
{
    public class GameEntityConfig
        : IEntityTypeConfiguration<Model.Game>
    {
        public void Configure(EntityTypeBuilder<Model.Game> builder)
        {
            builder.ToTable("Games");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .ForSqlServerUseSequenceHiLo("game_id_hilo")
                .IsRequired();

            builder.Property(cb => cb.Nome)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}