using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace trturino.GerenciadorGames.Services.Game.API.Infra.Repo
{
    public class GameRepository : IGameRepository
    {
        private readonly GameContext _gameContext;

        public GameRepository(GameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public async Task<Model.Game> AddAsync(Model.Game amigo)
        {
            _gameContext.Games.Add(amigo);

            await _gameContext.SaveChangesAsync();

            return await GetAsync(amigo.Id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var amigo = await _gameContext.Games.FirstOrDefaultAsync(x => x.Id == id);

            if (amigo == default(Model.Game))
                return false;

            _gameContext.Games.Remove(amigo);
            await _gameContext.SaveChangesAsync();

            return true;
        }

        public async Task<Model.Game> GetAsync(int id)
        {
            var amigo = await _gameContext.Games.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return amigo;
        }

        public async Task<IEnumerable<Model.Game>> GetTodosAsync()
        {
            var amigos = await _gameContext.Games.AsNoTracking().ToListAsync();

            return amigos;
        }

        public async Task<IEnumerable<Model.Game>> GetDisponiveisAsync()
        {
            var amigos = await _gameContext.Games.AsNoTracking().Where(x => x.Disponivel).ToListAsync();

            return amigos;
        }

        public async Task<Model.Game> UpdateAsync(Model.Game amigo)
        {
            var am = await _gameContext.Games.FirstOrDefaultAsync(x => x.Id == amigo.Id);

            if (am == default(Model.Game))
                return default(Model.Game);

            _gameContext.Entry(am).CurrentValues.SetValues(amigo);

            await _gameContext.SaveChangesAsync();

            return await GetAsync(amigo.Id);
        }
    }
}
