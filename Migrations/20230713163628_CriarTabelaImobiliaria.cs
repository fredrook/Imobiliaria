using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C__DIO.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaImobiliaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioInclusao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioExclusao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Imoveis",
                columns: table => new
                {
                    IdImovel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeImovel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NQuarto = table.Column<int>(type: "int", nullable: false),
                    NBanheiro = table.Column<int>(type: "int", nullable: false),
                    NVagasGaragem = table.Column<int>(type: "int", nullable: false),
                    MetrosQuadrados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorAluguel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorCondominio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorIptu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Locado = table.Column<bool>(type: "bit", nullable: true),
                    Vendido = table.Column<bool>(type: "bit", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioIdUsuario = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisponivelParaAluguel = table.Column<bool>(type: "bit", nullable: true),
                    DisponivelParaVenda = table.Column<bool>(type: "bit", nullable: true),
                    UsuarioInclusao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioExclusao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imoveis", x => x.IdImovel);
                    table.ForeignKey(
                        name: "FK_Imoveis_Usuario_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Negociacao",
                columns: table => new
                {
                    IdImovelNegociacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorAluguel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorCondominio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorIptu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DisponivelParaAluguel = table.Column<bool>(type: "bit", nullable: true),
                    DisponivelParaVenda = table.Column<bool>(type: "bit", nullable: true),
                    Locado = table.Column<bool>(type: "bit", nullable: true),
                    Vendido = table.Column<bool>(type: "bit", nullable: true),
                    IdImovel = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuarioInclusao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioExclusao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negociacao", x => x.IdImovelNegociacao);
                    table.ForeignKey(
                        name: "FK_Negociacao_Imoveis_IdImovel",
                        column: x => x.IdImovel,
                        principalTable: "Imoveis",
                        principalColumn: "IdImovel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Negociacao_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_UsuarioIdUsuario",
                table: "Imoveis",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Negociacao_IdImovel",
                table: "Negociacao",
                column: "IdImovel");

            migrationBuilder.CreateIndex(
                name: "IX_Negociacao_IdUsuario",
                table: "Negociacao",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Negociacao");

            migrationBuilder.DropTable(
                name: "Imoveis");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
