using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using trturino.GerenciadorGames.Services.Game.API.Infra;
using trturino.GerenciadorGames.Services.Game.API.Infra.Extensions;

namespace trturino.GerenciadorGames.Services.Game.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).MigrateDbContext<GameContext>((context, services) =>
                {
                    new GameContextSeed()
                        .SeedAsync(context)
                        .Wait();
                })
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}