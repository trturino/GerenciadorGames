using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trturino.GerenciadorGames.WebApps.WebMVC.Models;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Services
{
    public class GameService : IGameService
    {
        private static List<GameViewModel> _games;

        public GameService()
        {
            _games = _games ?? GetList();
        }

        public Task<GameViewModel> Add(GameViewModel model)
        {
            return Task.FromResult(model);
        }

        public Task<bool> Delete(int id)
        {
            return Task.FromResult(true);
        }

        public Task<IEnumerable<GameViewModel>> GetGamesDisponiveis()
        {
            return Task.FromResult(_games.Where(x => x.Disponivel));
        }

        public Task<GameViewModel> Edit(GameViewModel model)
        {
            return Task.FromResult(model);
        }

        public Task<IEnumerable<GameViewModel>> GetAll()
        {
            return Task.FromResult((IEnumerable<GameViewModel>)_games);
        }

        public Task<GameViewModel> GetById(int id)
        {
            return Task.FromResult(_games.FirstOrDefault(x => x.Id == id));
        }

        private List<GameViewModel> GetList() => new List<GameViewModel>
        {
            new GameViewModel { Id = 1, Nome = "Game 1", Disponivel = true },
            new GameViewModel { Id = 2, Nome = "Game 2", Disponivel = false },
            new GameViewModel { Id = 3, Nome = "Game 3", Disponivel = true },
            new GameViewModel { Id = 4, Nome = "Game 4", Disponivel = false }
        };
    }
}
