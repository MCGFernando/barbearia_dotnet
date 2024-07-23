using BarbeariaABC.Models;

namespace BarbeariaABC.WebApp.Services
{
    public interface IAtendimentoService
    {
        Task<IEnumerable<Atendimento>> GetAllAsync();
        Task<Atendimento> GetByIdAsync(int id);
        Task<Atendimento> AddAsync(Atendimento obj);
        Task<Atendimento> UpdateAsync(Atendimento obj);
        Task DeleteAsync(int id);
        Task<Atendimento> DeserializaResponseAsync(HttpResponseMessage response);
    }
}
