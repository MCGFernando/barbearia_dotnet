
using BarbeariaABC.API.Data;
using BarbeariaABC.API.Repositories.Exceptions;
using BarbeariaABC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaABC.API.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly DbSqlServerContext _context;
        private readonly ILogger<FuncionarioRepository> _logger;
        public FuncionarioRepository(DbSqlServerContext context, ILogger<FuncionarioRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Funcionario> AddAsync(Funcionario funcionario)
        {
            try
            {
                var resutl = await _context.Funcionario.AddAsync(funcionario);
                await _context.SaveChangesAsync();
                return resutl.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir o funcionário.");
                throw new RepositoryException("Ocorreu um erro ao inserir o funcionário.", ex);
            }
        }

        public async Task<Funcionario> DeleteAsync(int id)
        {
            try
            {
                var funcionario = await _context.Funcionario.FirstOrDefaultAsync(x => x.Id == id);
                if (funcionario == null)
                {
                    throw new KeyNotFoundException($"Funcionário com ID = {id} não foi encontrado.");
                }
                var result = _context.Funcionario.Remove(funcionario);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocorreu um erro ao remover o funcionário com o ID {id}.");
                throw new RepositoryException($"Ocorreu um erro ao remover o funcionário com o ID {id}.", ex);
            }
        }

        public async Task<IEnumerable<Funcionario>> GetAllAsync()
        {
            try
            {
                return await _context.Funcionario.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao busca dos funcionários.");
                throw new RepositoryException("Ocorreu um erro ao buscar dos funcionários.", ex);
            }
        }

        public async Task<Funcionario> GetByIdAsync(int id)
        {
            try
            {
                var funcionario = await _context.Funcionario.FirstOrDefaultAsync(x => x.Id == id);
                if (funcionario == null)
                {
                    throw new KeyNotFoundException($"Funcionário com ID = {id} não foi encontrado.");
                }
                return funcionario;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocorreu um erro ao recuperar o funcionário com o ID {id}.");
                throw new RepositoryException($"Ocorreu um erro ao recuperar o funcionário com o ID {id}.", ex);
            }
        }

        public async Task<Funcionario> UpdateAsync(Funcionario funcionario)
        {
            try
            {
                var result = await _context.Funcionario.FirstOrDefaultAsync(x => x.Id == funcionario.Id);
                if (result == null)
                {
                    throw new KeyNotFoundException($"Funcionário com ID = {funcionario.Id} não foi encontrado.");
                }
                _context.Entry(result).CurrentValues.SetValues(funcionario);
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao actualizar o funcionário.");
                throw new RepositoryException("Ocorreu um erro ao actualizar o funcionário.", ex);
            }
        }
    }
}
