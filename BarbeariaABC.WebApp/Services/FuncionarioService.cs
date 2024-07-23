using BarbeariaABC.Models;
using System.Text.Json;

namespace BarbeariaABC.WebApp.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        public readonly HttpClient _httpClient;
        private readonly ILogger<FuncionarioService> _logger;

        public FuncionarioService(HttpClient httpClient, ILogger<FuncionarioService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<Funcionario> AddAsync(Funcionario obj)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<Funcionario>("api/v1/Funcionarios", obj);
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

        public async Task<IEnumerable<Funcionario>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Funcionario[]>("api/v1/Funcionarios");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Funcionario> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Funcionario>($"api/v1/Funcionarios/{id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao inserir a função.");
                throw new Exception(ex.Message);
            }
        }

        public async Task<Funcionario> UpdateAsync(Funcionario obj)
        {
            try
            {
                { }
                var response = await _httpClient.PutAsJsonAsync<Funcionario>($"api/v1/Funcionarios/{obj.Id}", obj);
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

        public async Task<Funcionario> DeserializaResponseAsync(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            try
            {
                return JsonSerializer.Deserialize<Funcionario>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (JsonException ex)
            {
                throw new Exception($"Erro ao desserializar a resposta JSON: {content} {ex.Message}");
            }
        }
    }
}
