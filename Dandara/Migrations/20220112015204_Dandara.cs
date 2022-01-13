using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dandara.Migrations
{
    public partial class Dandara : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginCliente",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginCliente", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "LoginVendedor",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginVendedor", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    moeda = table.Column<double>(type: "float", nullable: false),
                    Condicoesdepagamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    condicaoeentrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    videodosprodutos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tamanho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cores = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricaoproduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoriaa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoriab = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoriac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoriad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoriae = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoriag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datavalidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    contatovendendor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ClienteCadastro",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartaoCredito = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteCadastro", x => x.Email);
                    table.ForeignKey(
                        name: "FK_ClienteCadastro_LoginCliente_Email",
                        column: x => x.Email,
                        principalTable: "LoginCliente",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CadastroVendedor",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mei = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartaoCredito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriçãoAtividade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroVendedor", x => x.Email);
                    table.ForeignKey(
                        name: "FK_CadastroVendedor_LoginVendedor_Email",
                        column: x => x.Email,
                        principalTable: "LoginVendedor",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vendedorProduto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendedorId = table.Column<int>(type: "int", nullable: false),
                    CadastroVendedorEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendedorProduto", x => x.id);
                    table.ForeignKey(
                        name: "FK_vendedorProduto_CadastroVendedor_CadastroVendedorEmail",
                        column: x => x.CadastroVendedorEmail,
                        principalTable: "CadastroVendedor",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vendedorProduto_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vendedorProduto_CadastroVendedorEmail",
                table: "vendedorProduto",
                column: "CadastroVendedorEmail");

            migrationBuilder.CreateIndex(
                name: "IX_vendedorProduto_ProdutoId",
                table: "vendedorProduto",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteCadastro");

            migrationBuilder.DropTable(
                name: "vendedorProduto");

            migrationBuilder.DropTable(
                name: "LoginCliente");

            migrationBuilder.DropTable(
                name: "CadastroVendedor");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "LoginVendedor");
        }
    }
}
