﻿using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using trturino.GerenciadorGames.WebApps.WebMVC.Infrastructure;
using trturino.GerenciadorGames.WebApps.WebMVC.Models;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Services
{
    public class AmigoService : IAmigoService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly string _enderecoRemoto;
        private readonly IHttpClient _apiClient;
        private readonly IHttpContextAccessor _httpContextAccesor;

        public AmigoService(
            IOptionsSnapshot<AppSettings> settings,
            IHttpClient apiClient,
            IHttpContextAccessor httpContextAccesor
            )
        {
            _settings = settings;
            _enderecoRemoto = $"{_settings.Value.AmigoUrl}/api/v1/amigo";
            _apiClient = apiClient;
            _httpContextAccesor = httpContextAccesor;
        }

        public async Task<AmigoViewModel> Add(AmigoViewModel model)
        {
            var amigoUrl = API.Amigo.PostAmigo(_enderecoRemoto);

            var authorizationToken = await GetUserTokenAsync();
            var response = await _apiClient.PostAsync(amigoUrl, model, authorizationToken);

            response.EnsureSuccessStatusCode();

            return model;
        }

        public async Task<bool> Delete(int id)
        {
            var amigoUrl = API.Amigo.DeleteAmigo(_enderecoRemoto, id);

            var authorizationToken = await GetUserTokenAsync();
            var response = await _apiClient.DeleteAsync(amigoUrl, authorizationToken);

            return response.IsSuccessStatusCode;
        }

        public async Task<AmigoViewModel> Edit(AmigoViewModel model)
        {
            var amigoUrl = API.Amigo.PutAmigo(_enderecoRemoto);

            var authorizationToken = await GetUserTokenAsync();
            var response = await _apiClient.PutAsync(amigoUrl, model, authorizationToken);

            response.EnsureSuccessStatusCode();

            return model;
        }

        public async Task<IEnumerable<AmigoViewModel>> GetAll()
        {
            var amigoUrl = API.Amigo.GetAmigo(_enderecoRemoto);

            var authorizationToken = await GetUserTokenAsync();
            var dataString = await _apiClient.GetStringAsync(amigoUrl, authorizationToken);

            var response = JsonConvert.DeserializeObject<IEnumerable<AmigoViewModel>>(dataString);

            return response;
        }

        public async Task<AmigoViewModel> GetById(int id)
        {
            var amigoUrl = API.Amigo.GetAmigoById(_enderecoRemoto, id);

            var authorizationToken = await GetUserTokenAsync();
            var dataString = await _apiClient.GetStringAsync(amigoUrl, authorizationToken);

            var response = JsonConvert.DeserializeObject<AmigoViewModel>(dataString);

            return response;
        }

        private async Task<string> GetUserTokenAsync()
        {
            var context = _httpContextAccesor.HttpContext;
            return await context.GetTokenAsync("access_token");
        }
    }
}