using BarbeariaABC.Models;

namespace BarbeariaABC.API.Repositories
{
    public interface IItemAtendimentoRepository
    {
        Task<IEnumerable<ItemAtendimento>> GetAllAsync();
        Task<ItemAtendimento> GetByIdAsync(int id);
        Task AddAsync(ItemAtendimento agenda);
        Task UpdateAsync(ItemAtendimento agenda);
        Task DeleteAsync(int id);
    }
}
