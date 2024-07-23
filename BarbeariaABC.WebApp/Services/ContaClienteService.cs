using BarbeariaABC.Models;
using System.Text.Json;

namespace BarbeariaABC.WebApp.Services
{
    public class ContaClienteService : IContaClienteService
    {
        public readonly HttpClient _httpClient;
        private readonly ILogger<ContaClienteService> _logger;

        public ContaClienteService(HttpClient httpClient, ILogger<ContaClienteService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ContaCliente> AddAsync(ContaCliente obj)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<ContaCliente>("api/v1/ContaClientes", obj);
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Erro ao criar o local: {response.StatusCode}. Detalhes: {errorContent}");
                }

                return await DeserializaResponseAsync(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ContaCliente>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ContaCliente[]>("api/v1/ContaClientes");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<ContaCliente> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ContaCliente>($"api/v1/ContaClientes/{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<ContaCliente> UpdateAsync(ContaCliente obj)
        {
            try
            {
                { }
                var response = await _httpClient.PutAsJsonAsync<ContaCliente>($"api/v1/ContaClientes/{obj.Id}", obj);
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Erro ao criar o local: {response.StatusCode}. Detalhes: {errorContent}");
                }

                return await DeserializaResponseAsync(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<ContaCliente> DeserializaResponseAsync(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            try
            {
                return JsonSerializer.Deserialize<ContaCliente>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (JsonException ex)
            {
                throw new Exception($"Erro ao desserializar a resposta JSON: {content} {ex.Message}");
            }
        }
    }
}
