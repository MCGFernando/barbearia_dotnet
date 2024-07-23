using BarbeariaABC.Models;


namespace BarbeariaABC.API.Repositories
{
    public interface IAtendimentoRepository
    {
        Task<IEnumerable<Atendimento>> GetAllAsync();
        Task<Atendimento> GetByIdAsync(int id);
        Task AddAsync(Atendimento atendimento);
        Task UpdateAsync(Atendimento atendimento);
        Task DeleteAsync(int id);
    }
}
