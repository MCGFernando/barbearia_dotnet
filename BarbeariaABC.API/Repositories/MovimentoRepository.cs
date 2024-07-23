
using BarbeariaABC.API.Data;
using BarbeariaABC.API.Repositories.Exceptions;
using BarbeariaABC.Models;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaABC.API.Repositories
{
    public class MovimentoRepository : IMovimentoRepository
    {
        private readonly DbSqlServerContext _context;
        private readonly ILogger<MovimentoRepository> _logger;
        public MovimentoRepository(DbSqlServerContext context, ILogger<MovimentoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Movimento> AddAsync(Movimento funcao)
        {
            try
            {
                var obj = await _context.Movimento.AddAsync(funcao);
                await _context.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new RepositoryException("Ocorreu um erro ao inserir a função.", ex);
            }
        }

        public async Task<Movimento> DeleteAsync(int id)
        {
            try
            {
                var funcao = await _context.Movimento.FirstOrDefaultAsync(x => x.Id == id);
                if (funcao == null)
                {
                    throw new KeyNotFoundException($"Função com ID = {id} não foi encontrado.");
                }
                var obj = _context.Movimento.Remove(funcao);
                await _context.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocorreu um erro ao remover a função com o ID {id}.");
                throw new RepositoryException($"Ocorreu um erro ao remover a função com o ID {id}.", ex);
            }
        }

        public async Task<IEnumerable<Movimento>> GetAllAsync()
        {
            try
            {
                return await _context.Movimento.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao buscar as funções.");
                throw new RepositoryException("Ocorreu um erro ao buscar as funções.", ex);
            }
        }

        public async Task<Movimento> GetByIdAsync(int id)
        {
            try
            {
                var funcao = await _context.Movimento.FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task<Movimento> UpdateAsync(Movimento funcao)
        {
            try
            {
                var result = await _context.Movimento.FirstOrDefaultAsync(x => x.Id == funcao.Id);
                if (result == null)
                {
                    throw new KeyNotFoundException($"Função com ID = {funcao.Id} não foi encontrado.");
                }
                _context.Entry(result).CurrentValues.SetValues(funcao);
                //_context.Movimento.Update(funcao);

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
