using LojaServicos.Api.CarrinhoCompra.RemoteInterface;
using LojaServicos.Api.CarrinhoCompra.RemoteModel;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LojaServicos.Api.CarrinhoCompra.RemoteService
{
    public class LivroService : ILivroService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<LivroService> _logger;

        public LivroService (IHttpClientFactory httpClient, ILogger<LivroService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool resultado, LivroRemote Livro, string ErrorMessage)> GetLivro(Guid LivroId)
        {
            try
            {
                Console.WriteLine("*** *** CarrinhoCompra.RemoteService - LivroService - GetLivro *** ***");
                var cliente = _httpClient.CreateClient("Livros");

                var response = await cliente.GetAsync($"api/livrariamaterial/{LivroId}");
                if (response.IsSuccessStatusCode)
                {
                    var contendo = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<LivroRemote>(contendo, options);

                    return (true, resultado,null );
                }

                return (false, null, response.ReasonPhrase);

            } catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);

            }

        }
    }
}
