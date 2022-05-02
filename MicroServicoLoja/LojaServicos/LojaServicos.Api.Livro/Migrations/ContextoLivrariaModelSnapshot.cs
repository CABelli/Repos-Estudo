﻿// <auto-generated />
using System;
using LojaServicos.Api.Livro.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LojaServicos.Api.Livro.Migrations
{
    [DbContext(typeof(ContextoLivraria))]
    partial class ContextoLivrariaModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LojaServicos.Api.Livro.Modelo.LivrariaMaterial", b =>
                {
                    b.Property<Guid?>("LivrariaMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AutorLivroGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataPublicacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LivrariaMaterialId");

                    b.ToTable("LivrariaMaterial");
                });
#pragma warning restore 612, 618
        }
    }
}
