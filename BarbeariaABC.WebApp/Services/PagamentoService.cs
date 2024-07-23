using BarbeariaABC.Models;
using System.Text.Json;

namespace BarbeariaABC.WebApp.Services
{
    public class PagamentoService : IPagamentoService
    {
        public readonly HttpClient _httpClient;
        private readonly ILogger<PagamentoService> _logger;

        public PagamentoService(HttpClient httpClient, ILogger<PagamentoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<Pagamento> AddAsync(Pagamento obj)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<Pagamento>("api/v1/Pagamentos", obj);
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

        public async Task<IEnumerable<Pagamento>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Pagamento[]>("api/v1/Pagamentos");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pagamento> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Pagamento>($"api/v1/Pagamentos/{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pagamento> UpdateAsync(Pagamento obj)
        {
            try
            {
                { }
                var response = await _httpClient.PutAsJsonAsync<Pagamento>($"api/v1/Pagamentos/{obj.Id}", obj);
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

        public async Task<Pagamento> DeserializaResponseAsync(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            try
            {
                return JsonSerializer.Deserialize<Pagamento>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (JsonException ex)
            {
                throw new Exception($"Erro ao desserializar a resposta JSON: {content} {ex.Message}");
            }
        }
    }
}
