using BarbeariaABC.Models;
using BarbeariaABC.Models.DTO;

namespace BarbeariaABC.API.Repositories
{
    public interface IServicoRepository
    {
        Task<IEnumerable<Servico>> GetAllAsync();
        Task<Servico> GetByIdAsync(int id);
        Task<Servico> AddAsync(ServicoCreateDTO servico);
        Task<Servico> UpdateAsync(Servico servico);
        Task<Servico> DeleteAsync(int id);
        Servico FromDTO(ServicoCreateDTO servico);
    }
}
