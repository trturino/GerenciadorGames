using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using trturino.GerenciadorGames.Services.Emprestimo.API.Infra;
using trturino.GerenciadorGames.Services.Emprestimo.API.Infra.Extensions;

namespace trturino.GerenciadorGames.Services.Emprestimo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).MigrateDbContext<EmprestimoContext>((context, services) =>
                {
                    new EmprestimoContextSeed()
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