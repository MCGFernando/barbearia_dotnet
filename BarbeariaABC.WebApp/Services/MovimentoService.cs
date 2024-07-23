using BarbeariaABC.Models;
using System.Text.Json;

namespace BarbeariaABC.WebApp.Services
{
    public class MovimentoService : IMovimentoService
    {
        public readonly HttpClient _httpClient;
        private readonly ILogger<MovimentoService> _logger;

        public MovimentoService(HttpClient httpClient, ILogger<MovimentoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<Movimento> AddAsync(Movimento obj)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<Movimento>("api/v1/Movimentos", obj);
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

        public async Task<IEnumerable<Movimento>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Movimento[]>("api/v1/Movimentos");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Movimento> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Movimento>($"api/v1/Movimentos/{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Movimento> UpdateAsync(Movimento obj)
        {
            try
            {
                { }
                var response = await _httpClient.PutAsJsonAsync<Movimento>($"api/v1/Movimentos/{obj.Id}", obj);
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

        public async Task<Movimento> DeserializaResponseAsync(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            try
            {
                return JsonSerializer.Deserialize<Movimento>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (JsonException ex)
            {
                throw new Exception($"Erro ao desserializar a resposta JSON: {content} {ex.Message}");
            }
        }
    }
}
