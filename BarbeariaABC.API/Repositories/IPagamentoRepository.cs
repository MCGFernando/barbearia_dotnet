using BarbeariaABC.Models;


namespace BarbeariaABC.API.Repositories
{
    public interface IPagamentoRepository
    {
        Task<IEnumerable<Pagamento>> GetAllAsync();
        Task<Pagamento> GetByIdAsync(int id);
        Task<Pagamento> AddAsync(Pagamento obj);
        Task<Pagamento> UpdateAsync(Pagamento obj);
        Task<Pagamento> DeleteAsync(int id);
    }
}
