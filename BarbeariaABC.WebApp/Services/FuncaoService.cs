using BarbeariaABC.Models;
using System.Text.Json;

namespace BarbeariaABC.WebApp.Services
{
    public class FuncaoService : IFuncaoService
    {
        public readonly HttpClient _httpClient;
        private readonly ILogger<FuncaoService> _logger;

        public FuncaoService(HttpClient httpClient, ILogger<FuncaoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<Funcao> AddAsync(Funcao obj)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<Funcao>("api/v1/Funcoes", obj);
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

        public async Task<IEnumerable<Funcao>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Funcao[]>("api/v1/Funcoes");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Funcao> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Funcao>($"api/v1/Funcoes/{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Funcao> UpdateAsync(Funcao obj)
        {
            try
            {
                { }
                var response = await _httpClient.PutAsJsonAsync<Funcao>($"api/v1/Funcoes/{obj.Id}", obj);
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

        public async Task<Funcao> DeserializaResponseAsync(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            try
            {
                return JsonSerializer.Deserialize<Funcao>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (JsonException ex)
            {
                throw new Exception($"Erro ao desserializar a resposta JSON: {content} {ex.Message}");
            }
        }
    }
}
