using BarbeariaABC.Models;
using System.Text.Json;

namespace BarbeariaABC.WebApp.Services
{
    public class ClienteService : IClienteService
    {
        public readonly HttpClient _httpClient;
        private readonly ILogger<ClienteService> _logger;

        public ClienteService(HttpClient httpClient, ILogger<ClienteService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<Cliente> AddAsync(Cliente obj)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<Cliente>("api/v1/Clientes", obj);
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

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Cliente[]>("api/v1/Clientes");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Cliente>($"api/v1/Clientes/{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente> UpdateAsync(Cliente obj)
        {
            try
            {
                { }
                var response = await _httpClient.PutAsJsonAsync<Cliente>($"api/v1/Clientes/{obj.Id}", obj);
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

        public async Task<Cliente> DeserializaResponseAsync(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            try
            {
                return JsonSerializer.Deserialize<Cliente>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (JsonException ex)
            {
                throw new Exception($"Erro ao desserializar a resposta JSON: {content} {ex.Message}");
            }
        }
    }
}
