using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using trturino.GerenciadorGames.WebApps.WebMVC.Infrastructure;
using trturino.GerenciadorGames.WebApps.WebMVC.Models;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Services
{
    public class GameService : IGameService
    {
        private readonly string _enderecoRemoto;
        private readonly IHttpClient _apiClient;
        private readonly IHttpContextAccessor _httpContextAccesor;

        public GameService(
            IOptionsSnapshot<AppSettings> settings,
            IHttpClient apiClient,
            IHttpContextAccessor httpContextAccesor
        )
        {
            _enderecoRemoto = $"{settings.Value.GameUrl}/api/v1/game/";
            _apiClient = apiClient;
            _httpContextAccesor = httpContextAccesor;
        }

        public async Task<GameViewModel> Add(GameViewModel model)
        {
            var url = API.Game.PostGame(_enderecoRemoto);

            var authorizationToken = await GetUserTokenAsync();
            var response = await _apiClient.PostAsync(url, model, authorizationToken);

            response.EnsureSuccessStatusCode();

            return model;
        }

        public async Task<bool> Delete(int id)
        {
            var url = API.Game.DeleteGame(_enderecoRemoto, id);

            var authorizationToken = await GetUserTokenAsync();
            var response = await _apiClient.DeleteAsync(url, authorizationToken);

            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<GameViewModel>> GetGamesDisponiveis()
        {
            var url = API.Game.GetDisponiveis(_enderecoRemoto);

            var authorizationToken = await GetUserTokenAsync();
            var dataString = await _apiClient.GetStringAsync(url, authorizationToken);

            var response = JsonConvert.DeserializeObject<IEnumerable<GameViewModel>>(dataString);

            return response;
        }

        public async Task<GameViewModel> Edit(GameViewModel model)
        {
            var url = API.Game.PutGame(_enderecoRemoto);

            var authorizationToken = await GetUserTokenAsync();
            var response = await _apiClient.PutAsync(url, model, authorizationToken);

            response.EnsureSuccessStatusCode();

            return model;
        }

        public async Task<IEnumerable<GameViewModel>> GetAll()
        {
            var url = API.Game.GetGame(_enderecoRemoto);

            var authorizationToken = await GetUserTokenAsync();
            var dataString = await _apiClient.GetStringAsync(url, authorizationToken);

            var response = JsonConvert.DeserializeObject<IEnumerable<GameViewModel>>(dataString);

            return response;
        }

        public async Task<GameViewModel> GetById(int id)
        {
            var url = API.Game.GetGameById(_enderecoRemoto, id);

            var authorizationToken = await GetUserTokenAsync();
            var dataString = await _apiClient.GetStringAsync(url, authorizationToken);

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