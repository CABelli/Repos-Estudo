using LojaServicos.Api.CarrinhoCompra.Modelo;
using LojaServicos.Api.CarrinhoCompra.Persistencia;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LojaServicos.Api.CarrinhoCompra.Aplicacao
{
    public class Novo
    {
        public class Executa : IRequest
        {
            public DateTime DataCriacao { get; set; }

            public List<string> ProdutoLista { get; set; }
        }

        public class Manejador : IRequestHandler<Executa>
        {

            public readonly CarrinhoContexto _contexto;

            public Manejador(CarrinhoContexto contexto)
            {
                _contexto = contexto;
            }


            public async Task<Unit> Handle(Executa request, CancellationToken cancellationToken)
            {
                var carrinhoSecao = new CarrinhoSecao
                {
                    DataCriacao  =  request.DataCriacao
                };
                _contexto.CarrinhoSecao.Add(carrinhoSecao);

                var valor = await _contexto.SaveChangesAsync();

                if (valor < 1 )
                {
                    //return Unit.Value;
                    throw new Exception("Não pode inserir uma seção no xxx Carrinho");
                }

                int id = carrinhoSecao.CarrinhoSecaoId;

                foreach ( var obj in request.ProdutoLista)
                {
                    var detalheSecao = new CarrinhoSecaoDetalhe
                    {
                        DataCriacao = DateTime.Now,
                        CarrinhoSecaoId = id,
                        ProdutoSelecionado = obj

                    };

                    _contexto.CarrinhoSecaoDetalhe.Add(detalheSecao);

                };

                valor = await _contexto.SaveChangesAsync();

                if (valor > 0 )
                {
                    return Unit.Value;
                }

                throw new Exception("Não pode inserir o livro no Carrinho ");
            }
        }
    }
}