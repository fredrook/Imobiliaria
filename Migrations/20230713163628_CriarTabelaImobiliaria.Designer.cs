﻿// <auto-generated />
using System;
using Imobiliaria.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace C__DIO.Migrations
{
    [DbContext(typeof(ImobiliariaContext))]
    [Migration("20230713163628_CriarTabelaImobiliaria")]
    partial class CriarTabelaImobiliaria
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Imovel", b =>
                {
                    b.Property<int>("IdImovel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdImovel"));

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("DisponivelParaAluguel")
                        .HasColumnType("bit");

                    b.Property<bool?>("DisponivelParaVenda")
                        .HasColumnType("bit");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<bool?>("Locado")
                        .HasColumnType("bit");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetrosQuadrados")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NBanheiro")
                        .HasColumnType("int");

                    b.Property<int>("NQuarto")
                        .HasColumnType("int");

                    b.Property<int>("NVagasGaragem")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeImovel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Situacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioAlteracao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioExclusao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioIdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioInclusao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorAluguel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorCondominio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorIptu")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorVenda")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("Vendido")
                        .HasColumnType("bit");

                    b.HasKey("IdImovel");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("Imoveis");
                });

            modelBuilder.Entity("Entities.Negociacao", b =>
                {
                    b.Property<int>("IdImovelNegociacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdImovelNegociacao"));

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("DisponivelParaAluguel")
                        .HasColumnType("bit");

                    b.Property<bool?>("DisponivelParaVenda")
                        .HasColumnType("bit");

                    b.Property<int>("IdImovel")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<bool?>("Locado")
                        .HasColumnType("bit");

                    b.Property<string>("Situacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioAlteracao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioExclusao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioInclusao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorAluguel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorCondominio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorIptu")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorVenda")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("Vendido")
                        .HasColumnType("bit");

                    b.HasKey("IdImovelNegociacao");

                    b.HasIndex("IdImovel");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Negociacao");
                });

            modelBuilder.Entity("Entities.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Situacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioAlteracao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioExclusao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioInclusao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Entities.Imovel", b =>
                {
                    b.HasOne("Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioIdUsuario");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entities.Negociacao", b =>
                {
                    b.HasOne("Entities.Imovel", "Imovel")
                        .WithMany("Negociacao")
                        .HasForeignKey("IdImovel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imovel");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entities.Imovel", b =>
                {
                    b.Navigation("Negociacao");
                });
#pragma warning restore 612, 618
        }
    }
}
