using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trturino.GerenciadorGames.Services.API.Model;

namespace trturino.GerenciadorGames.Services.API.Infra
{
    public class AmigoContextSeed
    {
        public async Task SeedAsync(AmigoContext context)
        {
            if (!context.Amigos.Any())
            {
                context.Amigos.AddRange(GetAmigos());
                await context.SaveChangesAsync();
            }
        }

        private IEnumerable<Amigo> GetAmigos()
        {
            return new[]
            {
                new Amigo(1, "Amigo 1", "1111"),
                new Amigo(2, "Amigo 2", "2222"),
                new Amigo(3, "Amigo 3", "3333"),
                new Amigo(4, "Amigo 4", "4444")
            };
        }
    }

}
