using BarbeariaABC.Models;


namespace BarbeariaABC.API.Repositories
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>> GetAllAsync();
        Task<Funcionario> GetByIdAsync(int id);
        Task<Funcionario> AddAsync(Funcionario funcionario);
        Task<Funcionario> UpdateAsync(Funcionario funcionario);
        Task<Funcionario> DeleteAsync(int id);
    }
}
