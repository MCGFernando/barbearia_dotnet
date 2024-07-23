using BarbeariaABC.Models;

namespace BarbeariaABC.WebApp.Services
{
    public interface IMarcacaoService
    {
        Task<IEnumerable<Marcacao>> GetAllAsync();
        Task<Marcacao> GetByIdAsync(int id);
        Task<Marcacao> AddAsync(Marcacao obj);
        Task<Marcacao> UpdateAsync(Marcacao obj);
        Task DeleteAsync(int id);
        Task<Marcacao> DeserializaResponseAsync(HttpResponseMessage response);
    }
}
