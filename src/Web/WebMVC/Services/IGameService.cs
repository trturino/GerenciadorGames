using System.Collections.Generic;
using System.Threading.Tasks;
using trturino.GerenciadorGames.WebApps.WebMVC.Models;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Services
{
    public interface IGameService : IServiceBase<GameViewModel>
    {
        Task<IEnumerable<GameViewModel>> GetGamesDisponiveis();
    }
}
