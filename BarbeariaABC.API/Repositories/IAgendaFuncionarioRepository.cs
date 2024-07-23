using BarbeariaABC.Models;


namespace BarbeariaABC.API.Repositories
{
    public interface IAgendaFuncionarioRepository
    {
        Task<IEnumerable<AgendaFuncionario>> GetAllAsync();
        Task<AgendaFuncionario> GetByIdAsync(int id);
        Task AddAsync(AgendaFuncionario agenda);
        Task UpdateAsync(AgendaFuncionario agenda);
        Task DeleteAsync(int id);
    }
}
