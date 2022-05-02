using LojaServicos.Api.CarrinhoCompra.Persistencia;
using LojaServicos.Api.CarrinhoCompra.RemoteInterface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static LojaServicos.Api.CarrinhoCompra.Aplicacao.Novo;

namespace LojaServicos.Api.CarrinhoCompra.Aplicacao
{
    public class Consulta
    {
        public class Executa : IRequest<CarrinhoDto> {
            public  int CarrinhoSecaoId { get; set; }
        }

        public class Manejador : IRequestHandler<Executa, CarrinhoDto>
        {
            private readonly CarrinhoContexto _contexto;
            private readonly ILivroService _livroService;

            public Manejador(CarrinhoContexto contexto, ILivroService livroService)
            {
                _contexto = contexto;
                _livroService = livroService;
            }

            public async Task<CarrinhoDto> Handle(Executa request, CancellationToken cancellationToken)
            {
                var carrinhoSecao = await _contexto.CarrinhoSecao.FirstOrDefaultAsync
                    (x => x.CarrinhoSecaoId == request.CarrinhoSecaoId);

                var carrinhoSecaoDetalhe = await _contexto.CarrinhoSecaoDetalhe.Where(X => X.CarrinhoSecaoId == request.CarrinhoSecaoId).ToListAsync();

                var listaCarrinhoDto = new List<CarrinhoDetalheDto>();

                foreach (var livro in carrinhoSecaoDetalhe )
                {
                   var response = await _livroService.GetLivro( new Guid (livro.ProdutoSelecionado) );
                    if (response.resultado)
                    {
                        var objetoLivro = response.Livro;

                        var carrinhoDetalhe = new CarrinhoDetalheDto
                        {
                            TituloLivro = objetoLivro.Titulo,
                            DataPublicacao = objetoLivro.DataPublicacao,
                            LivroId = objetoLivro.LivrariaMaterialId

                        };

                        listaCarrinhoDto.Add(carrinhoDetalhe);
                    }
                }

                var carrinhoSecaoDto = new CarrinhoDto
                {
                    CarrinhoId = carrinhoSecao.CarrinhoSecaoId,
                    DataCriacaoSecao = carrinhoSecao.DataCriacao,
                    ListaProdutos = listaCarrinhoDto
                    
                };

                return carrinhoSecaoDto;
            }
        }

    }
}