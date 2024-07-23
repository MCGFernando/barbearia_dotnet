using BarbeariaABC.Models;


namespace BarbeariaABC.API.Repositories
{
    public interface IFuncaoRepository
    {
        Task<IEnumerable<Funcao>> GetAllAsync();
        Task<Funcao> GetByIdAsync(int id);
        Task<Funcao> AddAsync(Funcao funcao);
        Task<Funcao> UpdateAsync(Funcao funcao);
        Task<Funcao> DeleteAsync(int id);
    }
}
