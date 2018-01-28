using System.Collections.Generic;
using System.Threading.Tasks;
using trturino.GerenciadorGames.WebApps.WebMVC.Models;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Services
{
    public interface IEmprestimoService : IServiceBase<EmprestimoViewModel>
    {
        Task<IEnumerable<EmprestimoViewModel>> GetAllByAmigo(int idAmigo);

        Task<IEnumerable<EmprestimoViewModel>> GetAllByGame(int idGame);
    }
}
