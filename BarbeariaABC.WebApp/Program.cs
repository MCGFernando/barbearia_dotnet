using BarbeariaABC.WebApp.Data;
using BarbeariaABC.WebApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BarbeariaABC.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var baseURI = "https://localhost:7149/";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddBlazorBootstrap();
            builder.Services.AddScoped<IFuncaoService, FuncaoService>();
            builder.Services.AddHttpClient<IFuncaoService, FuncaoService>(opt =>
            {
                opt.BaseAddress = new Uri(baseURI);
            });
            builder.Services.AddHttpClient<IServicoService, ServicoService>(opt =>
            {
                opt.BaseAddress = new Uri(baseURI);
            });
            builder.Services.AddHttpClient<IClienteService, ClienteService>(opt =>
            {
                opt.BaseAddress = new Uri(baseURI);
            });
            builder.Services.AddHttpClient<IFuncionarioService, FuncionarioService>(opt =>
            {
                opt.BaseAddress = new Uri(baseURI);
            });
            builder.Services.AddHttpClient<IMarcacaoService, MarcacaoService>(opt =>
            {
                opt.BaseAddress = new Uri(baseURI);
            });
            builder.Services.AddHttpClient<IContaClienteService, ContaClienteService>(opt =>
            {
                opt.BaseAddress = new Uri(baseURI);
            });
            builder.Services.AddHttpClient<IMovimentoService, MovimentoService>(opt =>
            {
                opt.BaseAddress = new Uri(baseURI);
            });
            builder.Services.AddHttpClient<IPagamentoService, PagamentoService>(opt =>
            {
                opt.BaseAddress = new Uri(baseURI);
            });
            builder.Services.AddHttpClient<IAtendimentoService, AtendimentoService>(opt =>
            {
                opt.BaseAddress = new Uri(baseURI);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}