using LojaServicos.Api.GateWay.InterfaceRemoto;
using LojaServicos.Api.GateWay.LivroRemoto;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace LojaServicos.Api.GateWay.MessageHandler
{
    public class LivroHandler : DelegatingHandler
	{
		private readonly ILogger<LivroHandler> _logger;
		private readonly IAutorRemoto _autorRemoto;

		public LivroHandler(ILogger<LivroHandler> logger,
			IAutorRemoto autorRemoto)
		{
			_logger = logger;
			_autorRemoto = autorRemoto;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var tempo = Stopwatch.StartNew();
			_logger.LogInformation("*** *** Inicia o request *** *** ");
			var response = await base.SendAsync(request, cancellationToken);
			if (response.IsSuccessStatusCode)
			{
				_logger.LogInformation("*** ***  response  OK *** ***  ");

				var contendo = await response.Content.ReadAsStringAsync();
				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				var resultado = JsonSerializer.Deserialize<LivroModeloRemoto>(contendo, options);

				var responseAutor = await _autorRemoto.GetAutor(resultado.AutorLivroGuid ?? Guid.Empty);				
				if (responseAutor.resultado)
				{
					_logger.LogInformation("*** ***  AUTOR OK  *** ***  ");
					var objetoAutor = responseAutor.autor;
					resultado.AutorDados = objetoAutor;
					var resultadoStr = JsonSerializer.Serialize(resultado);
					response.Content = new StringContent(resultadoStr, System.Text.Encoding.UTF8, "application/json");
				}
			}

			_logger.LogInformation($"*** ***  Este processo se foi em {tempo.ElapsedMilliseconds} ms  *** *** ");

			return response;
		}
	}
}
