using BarbeariaABC.Models;


namespace BarbeariaABC.API.Repositories
{
    public interface IMarcacaoRepository
    {
        Task<IEnumerable<Marcacao>> GetAllAsync();
        Task<Marcacao> GetByIdAsync(int id);
        Task AddAsync(Marcacao marcacao);
        Task UpdateAsync(Marcacao marcacao);
        Task DeleteAsync(int id);
    }
}
