
using BarbeariaABC.API.Data;
using BarbeariaABC.API.Repositories.Exceptions;
using BarbeariaABC.Models;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaABC.API.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly DbSqlServerContext _context;
        private readonly ILogger<PagamentoRepository> _logger;
        public PagamentoRepository(DbSqlServerContext context, ILogger<PagamentoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Pagamento> AddAsync(Pagamento funcao)
        {
            try
            {
                var obj = await _context.Pagamento.AddAsync(funcao);
                await _context.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new RepositoryException("Ocorreu um erro ao inserir a função.", ex);
            }
        }

        public async Task<Pagamento> DeleteAsync(int id)
        {
            try
            {
                var funcao = await _context.Pagamento.FirstOrDefaultAsync(x => x.Id == id);
                if (funcao == null)
                {
                    throw new KeyNotFoundException($"Função com ID = {id} não foi encontrado.");
                }
                var obj = _context.Pagamento.Remove(funcao);
                await _context.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocorreu um erro ao remover a função com o ID {id}.");
                throw new RepositoryException($"Ocorreu um erro ao remover a função com o ID {id}.", ex);
            }
        }

        public async Task<IEnumerable<Pagamento>> GetAllAsync()
        {
            try
            {
                return await _context.Pagamento.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao buscar as funções.");
                throw new RepositoryException("Ocorreu um erro ao buscar as funções.", ex);
            }
        }

        public async Task<Pagamento> GetByIdAsync(int id)
        {
            try
            {
                var funcao = await _context.Pagamento.FirstOrDefaultAsync(x => x.Id == id);
                if (funcao == null)
                {
                    throw new KeyNotFoundException($"Função com ID = {id} não foi encontrado.");
                }
                return funcao;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocorreu um erro ao recuperar a função com o ID {id}.");
                throw new RepositoryException($"Ocorreu um erro ao recuperar a função com o ID {id}.", ex);
            }
        }

        public async Task<Pagamento> UpdateAsync(Pagamento funcao)
        {
            try
            {
                var result = await _context.Pagamento.FirstOrDefaultAsync(x => x.Id == funcao.Id);
                if (result == null)
                {
                    throw new KeyNotFoundException($"Função com ID = {funcao.Id} não foi encontrado.");
                }
                _context.Entry(result).CurrentValues.SetValues(funcao);
                //_context.Pagamento.Update(funcao);

                _logger.LogWarning("Aqui Maro result: {result}", result);
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao actualizar a função.");
                throw new RepositoryException("Ocorreu um erro ao actualizar a função.", ex);
            }
        }
    }
}
