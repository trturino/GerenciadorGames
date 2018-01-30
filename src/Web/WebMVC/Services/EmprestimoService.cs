using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using trturino.GerenciadorGames.WebApps.WebMVC.Infrastructure;
using trturino.GerenciadorGames.WebApps.WebMVC.Models;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly string _enderecoRemoto;
        private readonly IHttpClient _apiClient;
        private readonly IHttpContextAccessor _httpContextAccesor;

        public EmprestimoService(
            IOptionsSnapshot<AppSettings> settings,
            IHttpClient apiClient,
            IHttpContextAccessor httpContextAccesor
        )
        {
            _settings = settings;
            _enderecoRemoto = $"{_settings.Value.EmprestimoUrl}/api/v1/emprestimo";
            _apiClient = apiClient;
            _httpContextAccesor = httpContextAccesor ?? throw new ArgumentNullException(nameof(httpContextAccesor));
        }

        public async Task<EmprestimoViewModel> Add(EmprestimoViewModel model)
        {
            var url = API.Emprestimo.PostEmprestimo(_enderecoRemoto);

            var authorizationToken = await GetUserTokenAsync();
            var response = await _apiClient.PostAsync(url, model, authorizationToken);

            response.EnsureSuccessStatusCode();

            return model;
        }

        public async Task<bool> Delete(int id)
        {
            var url = API.Emprestimo.DeleteEmprestimo(_enderecoRemoto, id);

            var authorizationToken = await GetUserTokenAsync();
            var response = await _apiClient.DeleteAsync(url, authorizationToken);

            return response.IsSuccessStatusCode;
        }

        public async Task<EmprestimoViewModel> Edit(EmprestimoViewModel model)
        {
            var url = API.Emprestimo.PutEmprestimo(_enderecoRemoto);

            var authorizationToken = await GetUserTokenAsync();
            var response = await _apiClient.PutAsync(url, model, authorizationToken);

            response.EnsureSuccessStatusCode();

            return model;
        }

        public async Task<IEnumerable<EmprestimoViewModel>> GetAll()
        {
            var url = API.Emprestimo.GetEmprestimo(_enderecoRemoto);

            var authorizationToken = await GetUserTokenAsync();
            var dataString = await _apiClient.GetStringAsync(url, authorizationToken);

            var response = JsonConvert.DeserializeObject<IEnumerable<EmprestimoViewModel>>(dataString);

            return response;
        }

        public async Task<IEnumerable<EmprestimoViewModel>> GetAllByAmigo(int idAmigo)
        {
            var url = API.Emprestimo.GetEmprestimoByAmigoId(_enderecoRemoto, idAmigo);

            var authorizationToken = await GetUserTokenAsync();
            var dataString = await _apiClient.GetStringAsync(url, authorizationToken);

            var response = JsonConvert.DeserializeObject<IEnumerable<EmprestimoViewModel>>(dataString);

            return response;
        }

        public async Task<IEnumerable<EmprestimoViewModel>> GetAllByGame(int idGame)
        {
            var url = API.Emprestimo.GetEmprestimoByGameId(_enderecoRemoto, idGame);

            var authorizationToken = await GetUserTokenAsync();
            var dataString = await _apiClient.GetStringAsync(url, authorizationToken);

            var response = JsonConvert.DeserializeObject<IEnumerable<EmprestimoViewModel>>(dataString);

            return response;
        }

        public async Task<EmprestimoViewModel> GetById(int id)
        {
            var url = API.Emprestimo.GetEmprestimoById(_enderecoRemoto, id);

            var authorizationToken = await GetUserTokenAsync();
            var dataString = await _apiClient.GetStringAsync(url, authorizationToken);

            var response = JsonConvert.DeserializeObject<EmprestimoViewModel>(dataString);

            return response;
        }

        private async Task<string> GetUserTokenAsync()
        {
            var context = _httpContextAccesor.HttpContext;
            return await context.GetTokenAsync("access_token");
        }
    }
}