﻿// <auto-generated />
using System;
using LojaServicos.Api.CarrinhoCompra.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LojaServicos.Api.CarrinhoCompra.Migrations
{
    [DbContext(typeof(CarrinhoContexto))]
    [Migration("20220218182657_MigrationMySQLInicial")]
    partial class MigrationMySQLInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LojaServicos.Api.CarrinhoCompra.Modelo.CarrinhoSecao", b =>
                {
                    b.Property<int>("CarrinhoSecaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("datetime");

                    b.HasKey("CarrinhoSecaoId");

                    b.ToTable("CarrinhoSecao");
                });

            modelBuilder.Entity("LojaServicos.Api.CarrinhoCompra.Modelo.CarrinhoSecaoDetalhe", b =>
                {
                    b.Property<int>("CarrinhoSecaoDetalheId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarrinhoSecaoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<string>("ProdutoSelecionado")
                        .HasColumnType("text");

                    b.HasKey("CarrinhoSecaoDetalheId");

                    b.HasIndex("CarrinhoSecaoId");

                    b.ToTable("CarrinhoSecaoDetalhe");
                });

            modelBuilder.Entity("LojaServicos.Api.CarrinhoCompra.Modelo.CarrinhoSecaoDetalhe", b =>
                {
                    b.HasOne("LojaServicos.Api.CarrinhoCompra.Modelo.CarrinhoSecao", "CarrinhoSecao")
                        .WithMany("ListaDetalhe")
                        .HasForeignKey("CarrinhoSecaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
