using BarbeariaABC.API.Data;
using BarbeariaABC.API.Middlewares;
using BarbeariaABC.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaABC.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DbSqlServerContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DbSqlServerContext") ?? throw new InvalidOperationException("Connection string 'DbSqlServerContext' not found.")));
            // Add services to the container.

            builder.Services.AddControllers();
                
                /*.AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                options.JsonSerializerOptions.WriteIndented = true;
            });*/
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IFuncaoRepository, FuncaoRepository>();
            builder.Services.AddScoped<IServicoRepository, ServicoRepository>();
            builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            builder.Services.AddScoped<IMarcacaoRepository, MarcacaoRepository>();
            builder.Services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
            builder.Services.AddScoped<IContaClienteRepository, ContaClienteRepository>();
            builder.Services.AddScoped<IMovimentoRepository, MovimentoRepository>();
            builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}