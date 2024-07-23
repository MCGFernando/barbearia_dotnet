using BarbeariaABC.API.Data;
using BarbeariaABC.API.Repositories.Exceptions;
using BarbeariaABC.Models;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaABC.API.Repositories
{
    public class ItemAtendimentoRepository : IItemAtendimentoRepository
    {
        private readonly DbSqlServerContext _context;
        private readonly ILogger<ItemAtendimentoRepository> _logger;
        public ItemAtendimentoRepository(DbSqlServerContext context, ILogger<ItemAtendimentoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddAsync(ItemAtendimento item)
        {
            try
            {
                await _context.ItemAtendimento.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir o item atendimento.");
                throw new RepositoryException("Ocorreu um erro ao inserir o item atendimento.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var item = await _context.ItemAtendimento.FirstOrDefaultAsync(x => x.Id == id);
                if (item == null)
                {
                    throw new KeyNotFoundException($"Item atendimento com ID = {id} não foi encontrado.");
                }
                _context.ItemAtendimento.Remove(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocorreu um erro ao remover o item atendimento com o ID {id}.");
                throw new RepositoryException($"Ocorreu um erro ao remover o item atendimento com o ID {id}.", ex);
            }
        }

        public async Task<IEnumerable<ItemAtendimento>> GetAllAsync()
        {
            try
            {
                return await _context.ItemAtendimento.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao busca dos itens de atendimentos.");
                throw new RepositoryException("Ocorreu um erro ao buscar dos iten de atendimentos.", ex);
            }
        }

        public async Task<ItemAtendimento> GetByIdAsync(int id)
        {
            try
            {
                var item = await _context.ItemAtendimento.FirstOrDefaultAsync(x => x.Id == id);
                if (item == null)
                {
                    throw new KeyNotFoundException($"Item atendimento com ID = {id} não foi encontrado.");
                }
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocorreu um erro ao recuperar o item atendimento com o ID {id}.");
                throw new RepositoryException($"Ocorreu um erro ao recuperar o item atendimento com o ID {id}.", ex);
            }
        }

        public async Task UpdateAsync(ItemAtendimento item)
        {
            try
            {
                var result = await _context.ItemAtendimento.FirstOrDefaultAsync(x => x.Id == item.Id);
                if (result == null)
                {
                    throw new KeyNotFoundException($"Item atendimento com ID = {item.Id} não foi encontrado.");
                }
                _context.Entry(result).CurrentValues.SetValues(item);
                //_context.ItemAtendimento.Update(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao actualizar o item atendimento.");
                throw new RepositoryException("Ocorreu um erro ao actualizar o item atendimento.", ex);
            }
        }
    }
}
