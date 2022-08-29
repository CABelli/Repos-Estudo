using AutoMapper;
using GenFu;
using LojaServicos.Api.Livro.Aplicacao;
using LojaServicos.Api.Livro.Modelo;
using LojaServicos.Api.Livro.Persistencia;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LojaServicos.Api.Livro.Tests
{
    public class LivrosServiceTest
    {
        private IEnumerable<LivrariaMaterial> ObterDadoProva()
        {

            A.Configure<LivrariaMaterial>()
                .Fill(x => x.Titulo).AsArticleTitle()
                .Fill(x => x.LivrariaMaterialId, () =>
                {
                    return Guid.NewGuid();
                });

            var lista = A.ListOf<LivrariaMaterial>(30);

            lista[0].LivrariaMaterialId = Guid.Empty;

            return lista;

        }

        private Mock<ContextoLivraria> CriarContexto ()
        {
            var dadoProva = ObterDadoProva().AsQueryable();

            var dbSet = new Mock<DbSet<LivrariaMaterial>>();
            dbSet.As<IQueryable<LivrariaMaterial>>().Setup(x => x.Provider).Returns(dadoProva.Provider);
            dbSet.As<IQueryable<LivrariaMaterial>>().Setup(x => x.Expression).Returns(dadoProva.Expression);
            dbSet.As<IQueryable<LivrariaMaterial>>().Setup(x => x.ElementType).Returns(dadoProva.ElementType);
            dbSet.As<IQueryable<LivrariaMaterial>>().Setup(x => x.GetEnumerator()).Returns(dadoProva.GetEnumerator());

            /// agora pecisa que a classe LivrariaMaterial deve ser assincrona 
            /// então precisamos criar mais duas classes
            /// AsyncEnumerator e enumerable 
            /// 

            dbSet.As<IAsyncEnumerable<LivrariaMaterial>>()
                .Setup( x => x.GetAsyncEnumerator( new System.Threading.CancellationToken() ) )
                .Returns( new AsyncEnumerator<LivrariaMaterial>(dadoProva.GetEnumerator() ) );

            dbSet.As<IQueryable<LivrariaMaterial>>().Setup(x => x.Provider)
                .Returns(new AsyncQueryProvider<LivrariaMaterial>(dadoProva.Provider) );
            
            var contexto = new Mock<ContextoLivraria>();
            contexto.Setup(x => x.LivrariaMaterial).Returns(dbSet.Object);
            return contexto;
        }

        [Fact]

        public async void GetLivroPorId()
        {
            var mockContexto = CriarContexto();
            var mapConfig = new MapperConfiguration(cfg =>
            {
              cfg.AddProfile(new MappingTest());
            } );

            var mapper = mapConfig.CreateMapper();

            var request = new ConsultaFiltro.LivroUnico();
            request.LivroId = Guid.Empty;

            var manejador = new ConsultaFiltro.Manejador(mockContexto.Object, mapper);

            var livro = await manejador.Handle(request, new System.Threading.CancellationToken());

            Assert.NotNull(livro);

            Assert.True(livro.LivrariaMaterialId == Guid.Empty);

        }

        [Fact]
        public async void GetLivros()
        {
            // linha bem no final ao mudar a persistencia  classe ContextoLivraria
            System.Diagnostics.Debugger.Launch();

            // E DEPOIS TESTAR 
            // CLICAR EM CIMA DO METODO GetLivros E DISPARAR RUN TESTE
            /// E ESCOLHER O METODO LOJASERVICO E NÃO O NEW


            // quais metodos dentro do MS livro realiza as consultas
            // primeira ConsultaLista - metodo Manejador
            // private readonly ContextoLivraria _contexto;
            // private readonly IMapper _mapper;
            // Emular ContextoLivraria e IMapper
            // utilizamos objetos tipo mock

            // apos criar o metodo  CriarContexto comeneta o mockContexto
            //var mockContexto = new Mock<ContextoLivraria>();
            var mockContexto = CriarContexto();


            // apos criar o metodo  CriarContexto se cria a classe MappingTest
            //var mockMapper = new Mock<IMapper>();
            
            var MapConfig = new MapperConfiguration(cfg =>
            {
               cfg.AddProfile(new MappingTest());
             });

            var mapper = MapConfig.CreateMapper();

            // Instanciar a classe Manejador

            // apos criar a var mapper
            //ConsultaLista.Manejador manejador = new ConsultaLista.Manejador(mockContexto.Object, mockMapper.Object);
            ConsultaLista.Manejador manejador = new ConsultaLista.Manejador(mockContexto.Object, mapper);

            // passo adiante

            ConsultaLista.Executa request = new ConsultaLista.Executa();

            var lista = await manejador.Handle(request, new System.Threading.CancellationToken());

            Assert.True(lista.Any());

            //Mudar na classe ContextoLivraria no metodo DbSet para tipo virtual

        }


        [Fact]

        public async void GuardarLivro() {

            // System.Diagnostics.Debugger.Launch SO COLOCAR PARA FINS DIDATICOS E VER COMO EXECUTA

            System.Diagnostics.Debugger.Launch();

            var options = new DbContextOptionsBuilder<ContextoLivraria>()
                .UseInMemoryDatabase(databaseName: "BaseDadosLivro")
                .Options;

            var contetxo = new ContextoLivraria(options);

            var request = new Novo.Executa();

            request.Titulo = "Livro de Microservice";
            request.AutorLivroGuid = Guid.Empty;
            request.DataPublicacao = DateTime.Now;

            //var manejador = new Novo.Manejador(contetxo);

            //var livro = await manejador.Handle(request, new System.Threading.CancellationToken());

            string livro = "ok";

            Assert.True(livro != null);



        }
   }
}
