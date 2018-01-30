using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;
using trturino.GerenciadorGames.Services.Identity.API.Configuracoes;

namespace trturino.GerenciadorGames.Services.Identity.API.Data
{
    public class ConfigurationDbContextSeed
    {
        public async Task SeedAsync(ConfigurationDbContext context, IConfiguration configuration)
        {
            var clientUrls = new Dictionary<string, string>
            {
                {"Mvc", configuration.GetValue<string>("MvcClient")},
                {"AmigosApi", configuration.GetValue<string>("AmigosApiClient")},
                {"GamesApi", configuration.GetValue<string>("GamesApiClient")},
                {"EmprestimoApi", configuration.GetValue<string>("EmprestimoApiClient")},
            };

            if (!await context.Clients.AnyAsync())
            {
                context.Clients.AddRange(Config.GetClients(clientUrls).Select(client => client.ToEntity()));
            }

            if (!await context.IdentityResources.AnyAsync())
            {
                context.IdentityResources.AddRange(Config.GetResources().Select(resource => resource.ToEntity()));
            }

            if (!await context.ApiResources.AnyAsync())
            {
                context.ApiResources.AddRange(Config.GetApis().Select(api => api.ToEntity()));
            }

            await context.SaveChangesAsync();
        }
    }
}