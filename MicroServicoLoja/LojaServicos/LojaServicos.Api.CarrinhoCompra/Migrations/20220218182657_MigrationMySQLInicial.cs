using System;
using Microsoft.EntityFrameworkCore.Migrations;
//using MySql.Data.EntityFrameworkCore.Metadata;
using MySql.EntityFrameworkCore.Metadata;

namespace LojaServicos.Api.CarrinhoCompra.Migrations
{
    public partial class MigrationMySQLInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarrinhoSecao",
                columns: table => new
                {
                    CarrinhoSecaoId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoSecao", x => x.CarrinhoSecaoId);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoSecaoDetalhe",
                columns: table => new
                {
                    CarrinhoSecaoDetalheId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: true),
                    ProdutoSelecionado = table.Column<string>(nullable: true),
                    CarrinhoSecaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoSecaoDetalhe", x => x.CarrinhoSecaoDetalheId);
                    table.ForeignKey(
                        name: "FK_CarrinhoSecaoDetalhe_CarrinhoSecao_CarrinhoSecaoId",
                        column: x => x.CarrinhoSecaoId,
                        principalTable: "CarrinhoSecao",
                        principalColumn: "CarrinhoSecaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoSecaoDetalhe_CarrinhoSecaoId",
                table: "CarrinhoSecaoDetalhe",
                column: "CarrinhoSecaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoSecaoDetalhe");

            migrationBuilder.DropTable(
                name: "CarrinhoSecao");
        }
    }
}
