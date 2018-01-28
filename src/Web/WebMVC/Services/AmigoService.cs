using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trturino.GerenciadorGames.WebApps.WebMVC.Models;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Services
{
    public class AmigoService : IAmigoService
    {
        private static List<AmigoViewModel> _amigos;

        public AmigoService()
        {
            _amigos = _amigos ?? GetList();
        }

        public Task<AmigoViewModel> Add(AmigoViewModel model)
        {
            return Task.FromResult(model);
        }

        public Task<bool> Delete(int id)
        {
            return Task.FromResult(true);
        }

        public Task<AmigoViewModel> Edit(AmigoViewModel model)
        {
            return Task.FromResult(model);
        }

        public Task<IEnumerable<AmigoViewModel>> GetAll()
        {
            return Task.FromResult((IEnumerable<AmigoViewModel>)_amigos);
        }

        public Task<AmigoViewModel> GetById(int id)
        {
            return Task.FromResult(_amigos.FirstOrDefault(x => x.Id == id));
        }

        private List<AmigoViewModel> GetList() => new List<AmigoViewModel>
        {
            new AmigoViewModel { Id = 1, Nome = "Amigo 1", Telefone = "111" },
            new AmigoViewModel { Id = 2, Nome = "Amigo 2", Telefone = "222" },
            new AmigoViewModel { Id = 3, Nome = "Amigo 3", Telefone = "333" },
            new AmigoViewModel { Id = 4, Nome = "Amigo 4", Telefone = "444" }
        };

    }
}
