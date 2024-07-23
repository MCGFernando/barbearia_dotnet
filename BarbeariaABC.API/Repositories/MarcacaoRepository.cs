
using BarbeariaABC.API.Data;
using BarbeariaABC.API.Repositories.Exceptions;
using BarbeariaABC.Models;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaABC.API.Repositories
{
    public class MarcacaoRepository : IMarcacaoRepository
    {
        private readonly DbSqlServerContext _context;
        private readonly ILogger<MarcacaoRepository> _logger;
        public MarcacaoRepository(DbSqlServerContext context, ILogger<MarcacaoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddAsync(Marcacao marcacao)
        {
            try
            {
                await _context.Marcacao.AddAsync(marcacao);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a marcação.");
                throw new RepositoryException("Ocorreu um erro ao inserir a marcação.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var marcacao = await _context.Marcacao.FirstOrDefaultAsync(x => x.Id == id);
                if (marcacao == null)
                {
                    throw new KeyNotFoundException($"Marcação com ID = {id} não foi encontrado.");
                }
                _context.Marcacao.Remove(marcacao);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocorreu um erro ao remover a marcação com o ID {id}.");
                throw new RepositoryException($"Ocorreu um erro ao remover a marcação com o ID {id}.", ex);
            }
        }

        public async Task<IEnumerable<Marcacao>> GetAllAsync()
        {
            try
            {
                return await _context.Marcacao
                    .Include(x => x.Cliente)
                    .Include(x => x.Servico)
                    .Include(x => x.Funcionario)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao buscar as marcações.");
                throw new RepositoryException("Ocorreu um erro ao buscar as marcações.", ex);
            }
        }

        public async Task<Marcacao> GetByIdAsync(int id)
        {
            try
            {
                var marcacao = await _context.Marcacao
                    .Include(x => x.Cliente)
                    .Include(x => x.Servico)
                    .Include(x => x.Funcionario)
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (marcacao == null)
                {
                    throw new KeyNotFoundException($"Marcação com ID = {id} não foi encontrado.");
                }
                return marcacao;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocorreu um erro ao recuperar a marcação com o ID {id}.");
                throw new RepositoryException($"Ocorreu um erro ao recuperar a marcação com o ID {id}.", ex);
            }
        }

        public async Task UpdateAsync(Marcacao marcacao)
        {
            try
            {
                var result = await _context.Marcacao.FirstOrDefaultAsync(x => x.Id == marcacao.Id);
                if (result == null)
                {
                    throw new KeyNotFoundException($"Marcação com ID = {marcacao.Id} não foi encontrado.");
                }
                _context.Entry(result).CurrentValues.SetValues(marcacao);
                //_context.Marcacao.Update(marcacao);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao actualizar a marcação.");
                throw new RepositoryException("Ocorreu um erro ao actualizar a marcação.", ex);
            }
        }
    }
}
