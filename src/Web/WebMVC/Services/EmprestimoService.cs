using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trturino.GerenciadorGames.WebApps.WebMVC.Models;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private static List<EmprestimoViewModel> _emprestimos;

        public EmprestimoService()
        {
            _emprestimos = _emprestimos ?? GetList();
        }

        public Task<EmprestimoViewModel> Add(EmprestimoViewModel model)
        {
            return Task.FromResult(model);
        }

        public Task<bool> Delete(int id)
        {
            return Task.FromResult(true);
        }

        public Task<EmprestimoViewModel> Edit(EmprestimoViewModel model)
        {
            return Task.FromResult(model);
        }

        public Task<IEnumerable<EmprestimoViewModel>> GetAll()
        {
            return Task.FromResult((IEnumerable<EmprestimoViewModel>)_emprestimos);
        }

        public Task<IEnumerable<EmprestimoViewModel>> GetAllByAmigo(int idAmigo)
        {
            return Task.FromResult(_emprestimos.Where(x => x.AmigoId == idAmigo));
        }

        public Task<IEnumerable<EmprestimoViewModel>> GetAllByGame(int idGame)
        {
            return Task.FromResult(_emprestimos.Where(x => x.GameId == idGame));
        }

        public Task<EmprestimoViewModel> GetById(int id)
        {
            return Task.FromResult(_emprestimos.FirstOrDefault(x => x.Id == id));
        }

        private List<EmprestimoViewModel> GetList() => new List<EmprestimoViewModel>
        {
            new EmprestimoViewModel { Id = 1, AmigoId = 1, AmigoNome = "Amigo 1", GameId=1, GameNome = "Game 1" },
            new EmprestimoViewModel { Id = 2, AmigoId = 2, AmigoNome = "Amigo 2", GameId=2, GameNome = "Game 2" },
            new EmprestimoViewModel { Id = 3, AmigoId = 3, AmigoNome = "Amigo 3", GameId=3, GameNome = "Game 3" },
            new EmprestimoViewModel { Id = 4, AmigoId = 4, AmigoNome = "Amigo 4", GameId=4, GameNome = "Game 4" }
        };
    }
}
