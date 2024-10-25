using NSE.WebApp.MVC.Models;
using System.Text;
using System.Text.Json;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContext = new StringContent(JsonSerializer.Serialize(usuarioLogin), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5038/api/identidade/autenticar", loginContext);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContext = new StringContent(JsonSerializer.Serialize(usuarioRegistro), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5038/api/identidade/nova-conta", registroContext);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }
    }
}
