using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace trturino.GerenciadorGames.Services.Emprestimo.API.Infra.Repo
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly EmprestimoContext _emprestimoContext;

        public EmprestimoRepository(EmprestimoContext emprestimoContext)
        {
            _emprestimoContext = emprestimoContext;
        }

        public async Task<Model.Emprestimo> AddAsync(Model.Emprestimo amigo)
        {
            _emprestimoContext.Emprestimos.Add(amigo);

            await _emprestimoContext.SaveChangesAsync();

            return await GetAsync(amigo.Id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var amigo = await _emprestimoContext.Emprestimos.FirstOrDefaultAsync(x => x.Id == id);

            if (amigo == default(Model.Emprestimo))
                return false;

            _emprestimoContext.Emprestimos.Remove(amigo);
            await _emprestimoContext.SaveChangesAsync();

            return true;
        }

        public async Task<Model.Emprestimo> GetAsync(int id)
        {
            var amigo = await _emprestimoContext.Emprestimos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return amigo;
        }

        public async Task<IEnumerable<Model.Emprestimo>> GetTodosAsync()
        {
            var amigos = await _emprestimoContext.Emprestimos.AsNoTracking().ToListAsync();

            return amigos;
        }

        public async Task<Model.Emprestimo> UpdateAsync(Model.Emprestimo amigo)
        {
            var am = await _emprestimoContext.Emprestimos.FirstOrDefaultAsync(x => x.Id == amigo.Id);

            if (am == default(Model.Emprestimo))
                return default(Model.Emprestimo);

            _emprestimoContext.Entry(am).CurrentValues.SetValues(amigo);

            await _emprestimoContext.SaveChangesAsync();

            return await GetAsync(amigo.Id);
        }

        public async Task<IEnumerable<Model.Emprestimo>> GetByAmigoId(int id)
        {
            var amigos = await _emprestimoContext.Emprestimos.AsNoTracking().Where(x => x.AmigoId == id).ToListAsync();

            return amigos;
        }

        public async Task<IEnumerable<Model.Emprestimo>> GetByGameId(int id)
        {
            var amigos = await _emprestimoContext.Emprestimos.AsNoTracking().Where(x => x.GameId == id).ToListAsync();

            return amigos;
        }
    }
}
