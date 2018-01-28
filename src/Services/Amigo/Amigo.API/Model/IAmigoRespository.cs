using System;
using System.Threading.Tasks;

namespace Amigo.API.Model
{
    public interface IAmigoRespository
    {
        Task<Amigo> GetAmigoAsync(Guid id);

        Task<Amigo> AddAmigoAsync(Amigo amigo);

        Task<Amigo> UpdateAmigoAsync(Amigo amigo);

        Task<bool> DeleteAmigoAsync(string id);
    }
}