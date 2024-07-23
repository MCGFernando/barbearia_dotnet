
using BarbeariaABC.API.Data;
using BarbeariaABC.API.Repositories.Exceptions;
using BarbeariaABC.Models;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaABC.API.Repositories
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly DbSqlServerContext _context;
        private readonly ILogger<AtendimentoRepository> _logger;
        public AtendimentoRepository(DbSqlServerContext context, ILogger<AtendimentoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddAsync(Atendimento atendimento)
        {
            try
            {
                await _context.Atendimento.AddAsync(atendimento);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir o atendimento.");
                throw new RepositoryException("Ocorreu um erro ao inserir o atendimento.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var atendimento = await _context.Atendimento.FirstOrDefaultAsync(x => x.Id == id);
                if (atendimento == null)
                {
                    throw new KeyNotFoundException($"Atendimento com ID = {id} não foi encontrado.");
                }
                _context.Atendimento.Remove(atendimento);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocorreu um erro ao remover o atendimento com o ID {id}.");
                throw new RepositoryException($"Ocorreu um erro ao remover o atendimento com o ID {id}.", ex);
            }
        }

        public async Task<IEnumerable<Atendimento>> GetAllAsync()
        {
            try
            {
                return await _context.Atendimento
                    .Include(x => x.ItemAtendimentos)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao busca dos atendimentos.");
                throw new RepositoryException("Ocorreu um erro ao buscar dos atendimentos.", ex);
            }
        }

        public async Task<Atendimento> GetByIdAsync(int id)
        {
            try
            {
                var atendimento = await _context.Atendimento
                    .Include(x => x.ItemAtendimentos)
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (atendimento == null)
                {
                    throw new KeyNotFoundException($"Atendimento com ID = {id} não foi encontrado.");
                }
                return atendimento;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocorreu um erro ao recuperar o atendimento com o ID {id}.");
                throw new RepositoryException($"Ocorreu um erro ao recuperar o atendimento com o ID {id}.", ex);
            }
        }

        public async Task UpdateAsync(Atendimento atendimento)
        {
            try
            {
                var result = await _context.Atendimento.FirstOrDefaultAsync(x => x.Id == atendimento.Id);
                if (result == null)
                {
                    throw new KeyNotFoundException($"Atendimento com ID = {atendimento.Id} não foi encontrado.");
                }
                _context.Entry(result).CurrentValues.SetValues(atendimento);
               // _context.Atendimento.Update(atendimento);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao actualizar o atendimento.");
                throw new RepositoryException("Ocorreu um erro ao actualizar o atendimento.", ex);
            }
        }
    }
}
