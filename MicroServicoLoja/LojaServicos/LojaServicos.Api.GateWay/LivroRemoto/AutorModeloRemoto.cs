using System;

namespace LojaServicos.Api.GateWay.LivroRemoto
{
    public class AutorModeloRemoto
    {
        public string Nome { get; set; }

        public string Apelido { get; set; }

        public DateTime? DataNascimento { get; set; }

        public string AutorLivroGuid { get; set; }
    }
}
