using BarbeariaABC.Models;
using System.Text.Json;

namespace BarbeariaABC.WebApp.Services
{
    public class MarcacaoService : IMarcacaoService
    {
        public readonly HttpClient _httpClient;
        private readonly ILogger<MarcacaoService> _logger;

        public MarcacaoService(HttpClient httpClient, ILogger<MarcacaoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<Marcacao> AddAsync(Marcacao obj)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<Marcacao>("api/v1/Marcacoes", obj);
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

        public async Task<IEnumerable<Marcacao>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Marcacao[]>("api/v1/Marcacoes");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Marcacao> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Marcacao>($"api/v1/Marcacoes/{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Marcacao> UpdateAsync(Marcacao obj)
        {
            try
            {
                { }
                var response = await _httpClient.PutAsJsonAsync<Marcacao>($"api/v1/Marcacoes/{obj.Id}", obj);
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

        public async Task<Marcacao> DeserializaResponseAsync(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            try
            {
                return JsonSerializer.Deserialize<Marcacao>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (JsonException ex)
            {
                throw new Exception($"Erro ao desserializar a resposta JSON: {content} {ex.Message}");
            }
        }
    }
}
