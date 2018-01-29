using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using trturino.GerenciadorGames.Services.API.Infra;
using trturino.GerenciadorGames.Services.API.Infra.Extensions;

namespace trturino.GerenciadorGames.Services.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .MigrateDbContext<AmigoContext>((context, services) =>
                {
                    new AmigoContextSeed()
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