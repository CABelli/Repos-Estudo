using LojaServicos.Mensageria.Email.SendGridLivraria.Interface;
using LojaServicos.Mensageria.Email.SendGridLivraria.Modelo;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaServicos.Mensageria.Email.SendGridLivraria.Implement
{
    public class SendGridEnviar : ISendGridEnviar
    {
        public async Task<(bool resultado, string errorMessage)> EnviarEmail(SendGridData data)
        {
            try
            {
                var sendGridCliente = new SendGridClient(data.SendGridApiKey);
                var destinatario = new EmailAddress(data.EmailDestinatario, data.NomeDestinatario);
                var tituloEmail = data.Titulo;
                var sender = new EmailAddress("cesar.belli@gmail.com", "Cesar Belli");
                var conteudoMessage = data.Conteudo;

                var objMessage = MailHelper.CreateSingleEmail(sender,
                    destinatario,
                    tituloEmail,
                    conteudoMessage,
                    conteudoMessage);

                await sendGridCliente.SendEmailAsync(objMessage);

                return (true, null);

            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }
    }
}
