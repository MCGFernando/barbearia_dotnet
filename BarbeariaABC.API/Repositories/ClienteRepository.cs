
using BarbeariaABC.API.Data;
using BarbeariaABC.API.Repositories.Exceptions;
using BarbeariaABC.Models;
using Microsoft.EntityFrameworkCore;

using System.Diagnostics.Contracts;

namespace BarbeariaABC.API.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbSqlServerContext _context;
        private readonly ILogger<ClienteRepository> _logger;
        public ClienteRepository(DbSqlServerContext context, ILogger<ClienteRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Cliente> AddAsync(Cliente cliente)
        {
            try
            {
                var result = await _context.Cliente.AddAsync(cliente);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir o cliente.");
                throw new RepositoryException("Ocorreu um erro ao inserir o cliente.", ex);
            }
        }

        public async Task<Cliente> DeleteAsync(int id)
        {
            try
            {
                var cliente = await _context.Cliente.FirstOrDefaultAsync(x => x.Id == id);
                if (cliente == null)
                {
                    throw new KeyNotFoundException($"Cliente com ID = {id} não foi encontrado.");
                }
                var result = _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocorreu um erro ao remover o cliente com o ID {id}.");
                throw new RepositoryException($"Ocorreu um erro ao remover o cliente com o ID {id}.", ex);
            }
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            try
            {
                return await _context.Cliente.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao busca os clientes.");
                throw new RepositoryException("Ocorreu um erro ao buscar os clientes.", ex);
            }
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            try
            {
                var cliente = await _context.Cliente.FirstOrDefaultAsync(x => x.Id == id);
                if (cliente == null)
                {
                    throw new KeyNotFoundException($"Cliente com ID = {id} não foi encontrado.");
                }
                return cliente;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocorreu um erro ao recuperar o cliente com o ID {id}.");
                throw new RepositoryException($"Ocorreu um erro ao recuperar o cliente com o ID {id}.", ex);
            }
        }

        public async Task<Cliente> UpdateAsync(Cliente cliente)
        {
            try
            {
                var result = await _context.Cliente.FirstOrDefaultAsync(x => x.Id == cliente.Id);
                if (result == null)
                {
                    throw new KeyNotFoundException($"Cliente com ID = {cliente.Id} não foi encontrado.");
                }
                _context.Entry(result).CurrentValues.SetValues(cliente);
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao actualizar o cliente.");
                throw new RepositoryException("Ocorreu um erro ao actualizar o cliente.", ex);
            }
        }
    }
}
