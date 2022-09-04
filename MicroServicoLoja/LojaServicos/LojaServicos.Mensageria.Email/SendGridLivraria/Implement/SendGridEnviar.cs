using LojaServicos.Mensageria.Email.SendGridLivraria.Interface;
using LojaServicos.Mensageria.Email.SendGridLivraria.Modelo;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace LojaServicos.Mensageria.Email.SendGridLivraria.Implement
{
    public class SendGridEnviar : ISendGridEnviar
    {
        public async Task<(bool resultado, string errorMessage)> EnviarEmail(SendGridData data)
        {
            try
            {
                Console.WriteLine("*** ***  SendGridEnviar *** ***");
                var sendGridCliente = new SendGridClient(data.SendGridApiKey);
                var destinatario = new EmailAddress(data.EmailDestinatario, data.NomeDestinatario);
                var tituloEmail = data.Titulo;
                var sender = new EmailAddress("cesar.belli@hotmail.com", "Cesar Belli");
                var conteudoMessage = data.Conteudo;

                var objMessage = MailHelper.CreateSingleEmail(sender,
                    destinatario,
                    tituloEmail,
                    conteudoMessage,
                    conteudoMessage);

                await sendGridCliente.SendEmailAsync(objMessage);

                Console.WriteLine("*** ***  SendGridEnviar - ok *** ***");

                return (true, null);

            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }
    }
}
