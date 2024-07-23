using BarbeariaABC.Models;
using System.Text.Json;

namespace BarbeariaABC.WebApp.Services
{
    public class AtendimentoService : IAtendimentoService
    {
        public readonly HttpClient _httpClient;
        private readonly ILogger<AtendimentoService> _logger;

        public AtendimentoService(HttpClient httpClient, ILogger<AtendimentoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<Atendimento> AddAsync(Atendimento obj)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<Atendimento>("api/v1/Atendimentos", obj);
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

        public async Task<IEnumerable<Atendimento>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Atendimento[]>("api/v1/Atendimentos");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Atendimento> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Atendimento>($"api/v1/Atendimentos/{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Atendimento> UpdateAsync(Atendimento obj)
        {
            try
            {
                { }
                var response = await _httpClient.PutAsJsonAsync<Atendimento>($"api/v1/Atendimentos/{obj.Id}", obj);
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

        public async Task<Atendimento> DeserializaResponseAsync(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            try
            {
                return JsonSerializer.Deserialize<Atendimento>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (JsonException ex)
            {
                throw new Exception($"Erro ao desserializar a resposta JSON: {content} {ex.Message}");
            }
        }
    }
}
