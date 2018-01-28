using System;
using System.Threading.Tasks;

namespace trturino.GerenciadorGames.Services.API.Model
{
    public interface IAmigoRespository
    {
        Task<Amigo> GetAmigoAsync(int id);

        Task<Amigo> GetTodosAmigosAsync();

        Task<Amigo> AddAmigoAsync(Amigo amigo);

        Task<Amigo> UpdateAmigoAsync(Amigo amigo);

        Task<bool> DeleteAmigoAsync(string id);
    }
}