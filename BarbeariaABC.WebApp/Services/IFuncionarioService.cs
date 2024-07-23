using BarbeariaABC.Models;

namespace BarbeariaABC.WebApp.Services
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<Funcionario>> GetAllAsync();
        Task<Funcionario> GetByIdAsync(int id);
        Task<Funcionario> AddAsync(Funcionario obj);
        Task<Funcionario> UpdateAsync(Funcionario obj);
        Task DeleteAsync(int id);
        Task<Funcionario> DeserializaResponseAsync(HttpResponseMessage response);
    }
}
