using BarbeariaABC.Models;

namespace BarbeariaABC.WebApp.Services
{
    public interface IPagamentoService
    {
        Task<IEnumerable<Pagamento>> GetAllAsync();
        Task<Pagamento> GetByIdAsync(int id);
        Task<Pagamento> AddAsync(Pagamento obj);
        Task<Pagamento> UpdateAsync(Pagamento obj);
        Task DeleteAsync(int id);
        Task<Pagamento> DeserializaResponseAsync(HttpResponseMessage response);
    }
}
