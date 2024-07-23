using BarbeariaABC.Models;


namespace BarbeariaABC.API.Repositories
{
    public interface IContaClienteRepository
    {
        Task<IEnumerable<ContaCliente>> GetAllAsync();
        Task<ContaCliente> GetByIdAsync(int id);
        Task<ContaCliente> AddAsync(ContaCliente obj);
        Task<ContaCliente> UpdateAsync(ContaCliente obj);
        Task<ContaCliente> DeleteAsync(int id);
    }
}
