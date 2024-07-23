using BarbeariaABC.Models;

namespace BarbeariaABC.WebApp.Services
{
    public interface IServicoService
    {
        Task<IEnumerable<Servico>> GetAllAsync();
        Task<Servico> GetByIdAsync(int id);
        Task<Servico> AddAsync(Servico obj);
        Task<Servico> UpdateAsync(Servico obj);
        Task DeleteAsync(int id);
        Task<Servico> DeserializaResponseAsync(HttpResponseMessage response);
    }
}
