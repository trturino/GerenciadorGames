using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trturino.GerenciadorGames.Services.Game.API.Infra
{
    public class GameContextSeed
    {
        public async Task SeedAsync(GameContext context)
        {
            if (!context.Games.Any())
            {
                context.Games.AddRange(GetGames());
                await context.SaveChangesAsync();
            }
        }

        private IEnumerable<Model.Game> GetGames()
        {
            return new[]
            {
                new Model.Game(1, "Game 1", false),
                new Model.Game(2, "Game 2", true),
                new Model.Game(3, "Game 3", true),
                new Model.Game(4, "Game 4", false)
            };
        }
    }
}