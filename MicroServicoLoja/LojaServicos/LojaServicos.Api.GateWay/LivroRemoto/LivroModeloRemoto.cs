using System;

namespace LojaServicos.Api.GateWay.LivroRemoto
{
    public class LivroModeloRemoto
    {
        public Guid? LivrariaMaterialId { get; set; }

        public string Titulo { get; set; }

        public DateTime? DataPublicacao { get; set; }

        public Guid? AutorLivroGuid { get; set; }

        public AutorModeloRemoto AutorDados { get; set; }
    }
}
