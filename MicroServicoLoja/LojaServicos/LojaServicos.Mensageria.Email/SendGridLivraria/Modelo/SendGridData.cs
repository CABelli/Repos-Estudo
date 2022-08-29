namespace LojaServicos.Mensageria.Email.SendGridLivraria.Modelo
{
    public class SendGridData
    {
        public string SendGridApiKey { get; set; }
        public string EmailDestinatario { get; set; }
        public string NomeDestinatario { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
    }
}
