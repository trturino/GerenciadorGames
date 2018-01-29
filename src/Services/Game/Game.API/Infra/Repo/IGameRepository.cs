using System.Collections.Generic;
using System.Threading.Tasks;

namespace trturino.GerenciadorGames.Services.Game.API.Infra.Repo
{
    public interface IGameRepository
    {
        Task<Model.Game> AddAsync(Model.Game amigo);

        Task<bool> DeleteAsync(int id);

        Task<Model.Game> GetAsync(int id);

        Task<IEnumerable<Model.Game>> GetDisponiveisAsync();

        Task<IEnumerable<Model.Game>> GetTodosAsync();

        Task<Model.Game> UpdateAsync(Model.Game amigo);
    }
}