using System;
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
            _enderecoRemoto = $"{_settings.Value.EmprestimoUrl}/api/v1/emprestimo/";
            _apiClient = apiClient;
            _httpContextAccesor = httpContextAccesor ?? throw new ArgumentNullException(nameof(httpContextAccesor));
        }

        public async Task<EmprestimoViewModel> Add(EmprestimoViewModel model)
        {
            var amigoUrl = API.Emprestimo.PostEmprestimo(_enderecoRemoto);

            //var authorizationToken = await GetUserTokenAsync();
            var dados = await _apiClient.GetStringAsync(amigoUrl);

            var response = JsonConvert.DeserializeObject<EmprestimoViewModel>(dados);

            return response;
        }

        public Task<bool> Delete(int id)
        {
            return Task.FromResult(true);
        }

        public async Task<EmprestimoViewModel> Edit(EmprestimoViewModel model)
        {
            var amigoUrl = API.Emprestimo.PutEmprestimo(_enderecoRemoto);

            //var authorizationToken = await GetUserTokenAsync();
            var dados = await _apiClient.GetStringAsync(amigoUrl);

            var response = JsonConvert.DeserializeObject<EmprestimoViewModel>(dados);

            return response;
        }

        public async Task<IEnumerable<EmprestimoViewModel>> GetAll()
        {
            var amigoUrl = API.Emprestimo.GetEmprestimo(_enderecoRemoto);

            //var authorizationToken = await GetUserTokenAsync();
            var dataString = await _apiClient.GetStringAsync(amigoUrl);

            var response = JsonConvert.DeserializeObject<IEnumerable<EmprestimoViewModel>>(dataString);

            return response;
        }

        public async Task<IEnumerable<EmprestimoViewModel>> GetAllByAmigo(int idAmigo)
        {
            var amigoUrl = API.Emprestimo.GetEmprestimoByAmigoId(_enderecoRemoto, idAmigo);

            //var authorizationToken = await GetUserTokenAsync();
            var dataString = await _apiClient.GetStringAsync(amigoUrl);

            var response = JsonConvert.DeserializeObject<IEnumerable<EmprestimoViewModel>>(dataString);

            return response;
        }

        public async Task<IEnumerable<EmprestimoViewModel>> GetAllByGame(int idGame)
        {
            var amigoUrl = API.Emprestimo.GetEmprestimoByGameId(_enderecoRemoto, idGame);

            //var authorizationToken = await GetUserTokenAsync();
            var dataString = await _apiClient.GetStringAsync(amigoUrl);

            var response = JsonConvert.DeserializeObject<IEnumerable<EmprestimoViewModel>>(dataString);

            return response;
        }

        public Task Devolver(int idEmprestimo)
        {
            return Task.CompletedTask;
        }

        public async Task<EmprestimoViewModel> GetById(int id)
        {
            var amigoUrl = API.Emprestimo.GetEmprestimoById(_enderecoRemoto, id);

            //var authorizationToken = await GetUserTokenAsync();
            var dataString = await _apiClient.GetStringAsync(amigoUrl);

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
