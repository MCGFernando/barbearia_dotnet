using BarbeariaABC.Models;

namespace BarbeariaABC.WebApp.Services
{
    public interface IFuncaoService
    {
        Task<IEnumerable<Funcao>> GetAllAsync();
        Task<Funcao> GetByIdAsync(int id);
        Task<Funcao> AddAsync(Funcao obj);
        Task<Funcao> UpdateAsync(Funcao obj);
        Task DeleteAsync(int id);
        Task<Funcao> DeserializaResponseAsync(HttpResponseMessage response);
    }
}
