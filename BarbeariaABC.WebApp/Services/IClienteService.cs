using BarbeariaABC.Models;

namespace BarbeariaABC.WebApp.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task<Cliente> AddAsync(Cliente obj);
        Task<Cliente> UpdateAsync(Cliente obj);
        Task DeleteAsync(int id);
        Task<Cliente> DeserializaResponseAsync(HttpResponseMessage response);
    }
}
