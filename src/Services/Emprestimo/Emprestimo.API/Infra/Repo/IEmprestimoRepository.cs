using System.Collections.Generic;
using System.Threading.Tasks;

namespace trturino.GerenciadorGames.Services.Emprestimo.API.Infra.Repo
{
    public interface IEmprestimoRepository
    {
        Task<Model.Emprestimo> AddAsync(Model.Emprestimo amigo);

        Task<bool> DeleteAsync(int id);

        Task<Model.Emprestimo> GetAsync(int id);

        Task<IEnumerable<Model.Emprestimo>> GetTodosAsync();

        Task<Model.Emprestimo> UpdateAsync(Model.Emprestimo amigo);

        Task<IEnumerable<Model.Emprestimo>> GetByAmigoId(int id);

        Task<IEnumerable<Model.Emprestimo>> GetByGameId(int id);
    }
}