using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaServicos.Api.Livro.Migrations
{
    public partial class MigrationSqlServerInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LivrariaMaterial",
                columns: table => new
                {
                    LivrariaMaterialId = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    DataPublicacao = table.Column<DateTime>(nullable: true),
                    AutorLivroGuid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivrariaMaterial", x => x.LivrariaMaterialId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivrariaMaterial");
        }
    }
}
