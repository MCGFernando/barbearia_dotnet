using BarbeariaABC.Models;


namespace BarbeariaABC.API.Repositories
{
    public interface IMovimentoRepository
    {
        Task<IEnumerable<Movimento>> GetAllAsync();
        Task<Movimento> GetByIdAsync(int id);
        Task<Movimento> AddAsync(Movimento obj);
        Task<Movimento> UpdateAsync(Movimento obj);
        Task<Movimento> DeleteAsync(int id);
    }
}
