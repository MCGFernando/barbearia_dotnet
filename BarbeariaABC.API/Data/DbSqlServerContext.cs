using BarbeariaABC.Models;
using Microsoft.EntityFrameworkCore;


namespace BarbeariaABC.API.Data
{
    public class DbSqlServerContext : DbContext
    {
        public DbSqlServerContext(DbContextOptions<DbSqlServerContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<AgendaFuncionario> AgendaFuncionario { get; set; }
        public DbSet<Atendimento> Atendimento { get; set; }
        public DbSet<ItemAtendimento> ItemAtendimento { get; set; }
        public DbSet<Funcao> Funcao { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<FuncionarioFuncao> FuncionarioFuncao { get; set; }
        public DbSet<FuncionarioServico> FuncionarioServico { get; set; }
        public DbSet<Marcacao> Marcacao { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public DbSet<ContaCliente> ContaCliente { get; set; }
        public DbSet<Movimento> Movimento { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }

        
    }
}
