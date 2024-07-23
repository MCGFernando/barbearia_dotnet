using BarbeariaABC.Models;

namespace BarbeariaABC.WebApp.Services
{
    public interface IContaClienteService
    {
        Task<IEnumerable<ContaCliente>> GetAllAsync();
        Task<ContaCliente> GetByIdAsync(int id);
        Task<ContaCliente> AddAsync(ContaCliente obj);
        Task<ContaCliente> UpdateAsync(ContaCliente obj);
        Task DeleteAsync(int id);
        Task<ContaCliente> DeserializaResponseAsync(HttpResponseMessage response);
    }
}
