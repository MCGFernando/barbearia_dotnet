
using BarbeariaABC.API.Data;
using BarbeariaABC.API.Repositories.Exceptions;
using BarbeariaABC.Models;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaABC.API.Repositories
{
    public class AgendaFuncionarioRepository : IAgendaFuncionarioRepository
    {
        private readonly DbSqlServerContext _context;
        private readonly ILogger<AgendaFuncionarioRepository> _logger;
        public AgendaFuncionarioRepository(DbSqlServerContext context, ILogger<AgendaFuncionarioRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddAsync(AgendaFuncionario agenda)
        {
            try
            {
                await _context.AgendaFuncionario.AddAsync(agenda);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a agenda do funcionário.");
                throw new RepositoryException("Ocorreu um erro ao inserir a agenda do funcionário.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var agenda = await _context.AgendaFuncionario.FirstOrDefaultAsync(x => x.Id == id);
                if (agenda == null)
                {
                    throw new KeyNotFoundException($"Agenda funcionário com ID = {id} não foi encontrado.");
                }
                _context.AgendaFuncionario.Remove(agenda);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocorreu um erro ao remover o agenda funcionário com o ID {id}.");
                throw new RepositoryException($"Ocorreu um erro ao remover o agenda funcionário com o ID {id}.", ex);
            }
        }

        public async Task<IEnumerable<AgendaFuncionario>> GetAllAsync()
        {
            try
            {
                return await _context.AgendaFuncionario.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao busca dos agenda funcionários.");
                throw new RepositoryException("Ocorreu um erro ao buscar dos agenda funcionários.", ex);
            }
        }

        public async Task<AgendaFuncionario> GetByIdAsync(int id)
        {
            try
            {
                var agenda = await _context.AgendaFuncionario.FirstOrDefaultAsync(x => x.Id == id);
                if (agenda == null)
                {
                    throw new KeyNotFoundException($"Agenda funcionário com ID = {id} não foi encontrado.");
                }
                return agenda;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocorreu um erro ao recuperar o agenda funcionário com o ID {id}.");
                throw new RepositoryException($"Ocorreu um erro ao recuperar o agenda funcionário com o ID {id}.", ex);
            }
        }

        public async Task UpdateAsync(AgendaFuncionario agenda)
        {
            try
            {
                var result = await _context.AgendaFuncionario.FirstOrDefaultAsync(x => x.Id == agenda.Id);
                if (result == null)
                {
                    throw new KeyNotFoundException($"Agenda funcionário com ID = {agenda.Id} não foi encontrado.");
                }
                _context.Entry(result).CurrentValues.SetValues(agenda);
                //_context.AgendaFuncionario.Update(agenda);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao actualizar o agenda funcionário.");
                throw new RepositoryException("Ocorreu um erro ao actualizar o agenda funcionário.", ex);
            }
        }
    }
}
