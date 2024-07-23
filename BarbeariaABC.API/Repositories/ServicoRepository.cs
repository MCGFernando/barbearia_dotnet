
using BarbeariaABC.API.Data;
using BarbeariaABC.API.Repositories.Exceptions;
using BarbeariaABC.Models;
using BarbeariaABC.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BarbeariaABC.API.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly DbSqlServerContext _context;
        private readonly ILogger<ServicoRepository> _logger;
        public ServicoRepository(DbSqlServerContext context, ILogger<ServicoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Servico> AddAsync(ServicoCreateDTO servicoDto)
        {
            try
            {
                var servico = FromDTO(servicoDto);
                var obj = await _context.Servico.AddAsync(servico);
                await _context.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir o serviço.");
                throw new RepositoryException("Ocorreu um erro ao inserir o serviço.", ex);
            }
        }

        public async Task<Servico> DeleteAsync(int id)
        {
            try
            {
                var servico = await _context.Servico.FirstOrDefaultAsync(x => x.Id == id);
                if (servico == null)
                {
                    throw new KeyNotFoundException($"Serviço com ID = {id} não foi encontrado.");
                }
                var obj = _context.Servico.Remove(servico);
                await _context.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocorreu um erro ao remover o serviço com o ID {id}.");
                throw new RepositoryException($"Ocorreu um erro ao remover o serviço com o ID {id}.", ex);
            }
        }

        public Servico FromDTO(ServicoCreateDTO servico)
        {
            return new Servico
            {
                Descricao = servico.Descricao,
                Preco = servico.Preco,
                Duracao = TimeSpan.Parse(servico.Duracao),
            };
        }

        public async Task<IEnumerable<Servico>> GetAllAsync()
        {
            try
            {
                return await _context.Servico.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao busca dos serviços.");
                throw new RepositoryException("Ocorreu um erro ao buscar dos serviços.", ex);
            }
        }

        public async Task<Servico> GetByIdAsync(int id)
        {
            try
            {
                var servico = await _context.Servico.FirstOrDefaultAsync(x => x.Id == id);
                if (servico == null)
                {
                    throw new KeyNotFoundException($"Serviço com ID = {id} não foi encontrado.");
                }
                return servico;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocorreu um erro ao recuperar o serviço com o ID {id}.");
                throw new RepositoryException($"Ocorreu um erro ao recuperar o serviço com o ID {id}.", ex);
            }
        }

        public async Task<Servico> UpdateAsync(Servico servico)
        {
            try
            {
                var result = await _context.Servico.FirstOrDefaultAsync(x => x.Id == servico.Id);
                if (result == null)
                {
                    throw new KeyNotFoundException($"Serviço com ID = {servico.Id} não foi encontrado.");
                }
                _context.Entry(result).CurrentValues.SetValues(servico);
                //_context.Servico.Update(servico);
                await _context.SaveChangesAsync();
                return servico;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao actualizar o serviço.");
                throw new RepositoryException("Ocorreu um erro ao actualizar o serviço.", ex);
            }
        }
    }
}
