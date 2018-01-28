using System.Collections.Generic;
using System.Threading.Tasks;

namespace trturino.GerenciadorGames.WebApps.WebMVC.Services
{
    public interface IServiceBase<T> where T: class
    {
        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetAll();

        Task<T> Add(T model);

        Task<T> Edit(T model);

        Task<bool> Delete(int id);
    }
}
