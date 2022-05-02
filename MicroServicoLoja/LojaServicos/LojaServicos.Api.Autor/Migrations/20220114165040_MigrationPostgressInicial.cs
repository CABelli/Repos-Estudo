using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LojaServicos.Api.Autor.Migrations
{
    public partial class MigrationPostgressInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutorLivro",
                columns: table => new
                {
                    AutorLivroId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    Apelido = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    AutorLivroGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorLivro", x => x.AutorLivroId);
                });

            migrationBuilder.CreateTable(
                name: "GrauAcademico",
                columns: table => new
                {
                    GrauAcademicoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(nullable: true),
                    CentroAcademico = table.Column<string>(nullable: true),
                    DataGrau = table.Column<DateTime>(nullable: true),
                    AutorLivroId = table.Column<int>(nullable: false),
                    GrauAcademicoGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrauAcademico", x => x.GrauAcademicoId);
                    table.ForeignKey(
                        name: "FK_GrauAcademico_AutorLivro_AutorLivroId",
                        column: x => x.AutorLivroId,
                        principalTable: "AutorLivro",
                        principalColumn: "AutorLivroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrauAcademico_AutorLivroId",
                table: "GrauAcademico",
                column: "AutorLivroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrauAcademico");

            migrationBuilder.DropTable(
                name: "AutorLivro");
        }
    }
}
