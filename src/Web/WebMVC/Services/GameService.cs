using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using trturino.GerenciadorGames.WebApps.WebMVC.Infrastructure;
using trturino.GerenciadorGames.WebApps.WebMVC.Models;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Services
{
    public class GameService : IGameService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly string _enderecoRemoto;
        private readonly IHttpClient _apiClient;
        private readonly IHttpContextAccessor _httpContextAccesor;

        public GameService(
            IOptionsSnapshot<AppSettings> settings,
            IHttpClient apiClient
        )
        {
            _settings = settings;
            _enderecoRemoto = $"{_settings.Value.GameUrl}/api/v1/game/";
            _apiClient = apiClient;
        }

        public async Task<GameViewModel> Add(GameViewModel model)
        {
            var amigoUrl = API.Game.PostGame(_enderecoRemoto);

            //var authorizationToken = await GetUserTokenAsync();
            var dados = await _apiClient.GetStringAsync(amigoUrl);

            var response = JsonConvert.DeserializeObject<GameViewModel>(dados);

            return response;
        }

        public Task<bool> Delete(int id)
        {
            return Task.FromResult(true);
        }

        public async Task<IEnumerable<GameViewModel>> GetGamesDisponiveis()
        {
            var amigoUrl = API.Game.GetDisponiveis(_enderecoRemoto);

            //var authorizationToken = await GetUserTokenAsync();
            var dataString = await _apiClient.GetStringAsync(amigoUrl);

            var response = JsonConvert.DeserializeObject<IEnumerable<GameViewModel>>(dataString);

            return response;
        }

        public async Task<GameViewModel> Edit(GameViewModel model)
        {
            var amigoUrl = API.Game.PostGame(_enderecoRemoto);

            //var authorizationToken = await GetUserTokenAsync();
            var dados = await _apiClient.GetStringAsync(amigoUrl);

            var response = JsonConvert.DeserializeObject<GameViewModel>(dados);

            return response;
        }

        public async Task<IEnumerable<GameViewModel>> GetAll()
        {
            var amigoUrl = API.Game.GetGame(_enderecoRemoto);

            //var authorizationToken = await GetUserTokenAsync();
            var dataString = await _apiClient.GetStringAsync(amigoUrl);

            var response = JsonConvert.DeserializeObject<IEnumerable<GameViewModel>>(dataString);

            return response;
        }

        public async Task<GameViewModel> GetById(int id)
        {
            var amigoUrl = API.Game.GetGameById(_enderecoRemoto, id);

            //var authorizationToken = await GetUserTokenAsync();
            var dataString = await _apiClient.GetStringAsync(amigoUrl);

            var response = JsonConvert.DeserializeObject<GameViewModel>(dataString);

            return response;
        }

        private async Task<string> GetUserTokenAsync()
        {
            var context = _httpContextAccesor.HttpContext;
            return await context.GetTokenAsync("access_token");
        }
    }
}
