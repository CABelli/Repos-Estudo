using LojaServicos.RabbitMQ.Bus.Eventos;

namespace LojaServicos.RabbitMQ.Bus.EventoQueue
{
    public class EmailEventoQueue : Evento
	{
		public string Destinatario { get; set; }
		public string Titulo { get; set; }
		public string Conteudo { get; set; }

		public EmailEventoQueue(string destinatario,
			string titulo,
			string conteudo)
		{
			Destinatario = destinatario;
			Titulo = titulo;
			Conteudo = conteudo;
		}
	}
}
