using BarbeariaABC.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace BarbeariaABC.WebApp.Services
{
    public class ServicoService : IServicoService
    {
        public readonly HttpClient _httpClient;
        private readonly ILogger<ServicoService> _logger;

        public ServicoService(HttpClient httpClient, ILogger<ServicoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<Servico> AddAsync(Servico obj)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<Servico>("api/v1/Servicos", obj);
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

        

        public async Task<IEnumerable<Servico>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Servico[]>("api/v1/Servicos");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Servico> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Servico>($"api/v1/Servicos/{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Servico> UpdateAsync(Servico obj)
        {
            try
            {
                { }
                var response = await _httpClient.PutAsJsonAsync<Servico>($"api/v1/Servicos/{obj.Id}", obj);
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

        public async Task<Servico> DeserializaResponseAsync(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            try
            {
                return JsonSerializer.Deserialize<Servico>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (JsonException ex)
            {
                throw new Exception($"Erro ao desserializar a resposta JSON: {content} {ex.Message}");
            }
        }
    }
}
