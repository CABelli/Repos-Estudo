using LojaServicos.Api.GateWay.InterfaceRemoto;
using LojaServicos.Api.GateWay.LivroRemoto;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LojaServicos.Api.GateWay.ImplementRemote
{
    public class AutorRemoto : IAutorRemoto
	{ 
	  private readonly IHttpClientFactory _httpClient;
	  private readonly ILogger<AutorRemoto> _logger;
	  public AutorRemoto(IHttpClientFactory httpClient, ILogger<AutorRemoto> logger)
	  {
		_httpClient = httpClient;
			_logger = logger;
	  }

	  public async Task<(bool resultado, AutorModeloRemoto autor, string ErrorMessage)> GetAutor(Guid AutorId)
	  {
		try
		{
			var cliente = _httpClient.CreateClient("AutorService");
			var response = await cliente.GetAsync($"/Autor/{AutorId}");

			if (response.IsSuccessStatusCode)
			{

				var contendo = await response.Content.ReadAsStringAsync();
				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				var resultado = JsonSerializer.Deserialize<AutorModeloRemoto>(contendo, options);

				return (true, resultado, null);
			}

			return (false, null, response.ReasonPhrase);
		}
		catch (Exception e)
		{
			_logger.LogError(e.ToString());
			return (false, null, e.Message);
		}
	  }
    }
}
