using BarbeariaABC.Models;

namespace BarbeariaABC.WebApp.Services
{
    public interface IMovimentoService
    {
        Task<IEnumerable<Movimento>> GetAllAsync();
        Task<Movimento> GetByIdAsync(int id);
        Task<Movimento> AddAsync(Movimento obj);
        Task<Movimento> UpdateAsync(Movimento obj);
        Task DeleteAsync(int id);
        Task<Movimento> DeserializaResponseAsync(HttpResponseMessage response);
    }
}
