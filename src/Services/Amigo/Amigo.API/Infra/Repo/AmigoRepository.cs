using System.Collections.Generic;
using System.Threading.Tasks;
using trturino.GerenciadorGames.Services.API.Model;
using Microsoft.EntityFrameworkCore;

namespace trturino.GerenciadorGames.Services.API.Infra.Repo
{
    public class AmigoRepository : IAmigoRespository
    {
        private readonly AmigoContext _amigoContext;

        public AmigoRepository(AmigoContext amigoContext)
        {
            _amigoContext = amigoContext;
        }

        public async Task<Amigo> AddAmigoAsync(Amigo amigo)
        {
            var id = await _amigoContext.Amigos.MaxAsync(x => x.Id);
            amigo.SetId(id);
            _amigoContext.Amigos.Add(amigo);

            await _amigoContext.SaveChangesAsync();

            return await GetAmigoAsync(amigo.Id);
        }

        public async Task<bool> DeleteAmigoAsync(int id)
        {
            var amigo = await _amigoContext.Amigos.FirstOrDefaultAsync(x => x.Id == id);

            if (amigo == default(Amigo))
                return false;

            _amigoContext.Amigos.Remove(amigo);
            await _amigoContext.SaveChangesAsync();

            return true;
        }

        public async Task<Amigo> GetAmigoAsync(int id)
        {
            var amigo = await _amigoContext.Amigos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return amigo;
        }

        public async Task<IEnumerable<Amigo>> GetTodosAmigosAsync()
        {
            var amigos = await _amigoContext.Amigos.AsNoTracking().ToListAsync();

            return amigos;
        }

        public async Task<Amigo> UpdateAmigoAsync(Amigo amigo)
        {
            var am = await _amigoContext.Amigos.FirstOrDefaultAsync(x => x.Id == amigo.Id);

            if (am == default(Amigo))
                return default(Amigo);

            _amigoContext.Entry<Amigo>(am).CurrentValues.SetValues(amigo);

            await _amigoContext.SaveChangesAsync();

            return await GetAmigoAsync(amigo.Id);
        }
    }
}
