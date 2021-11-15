using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pessoa.api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Logradouro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Cep = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TELEFONE_TIPO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TELEFONE_TIPO", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PESSOA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<long>(type: "bigint", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    PessoaTelefoneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PESSOA_ENDERECO_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "ENDERECO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PESSOA_TELEFONE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    TelefoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA_TELEFONE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PESSOA_TELEFONE_PESSOA_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "PESSOA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TELEFONE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Ddd = table.Column<int>(type: "int", nullable: false),
                    TipoTelefoneId = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: true),
                    PessoaTelefoneId = table.Column<int>(type: "int", nullable: true),
                    TipoTelefoneId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TELEFONE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TELEFONE_PESSOA_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "PESSOA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TELEFONE_PESSOA_TELEFONE_PessoaTelefoneId",
                        column: x => x.PessoaTelefoneId,
                        principalTable: "PESSOA_TELEFONE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TELEFONE_TELEFONE_TIPO_TipoTelefoneId",
                        column: x => x.TipoTelefoneId,
                        principalTable: "TELEFONE_TIPO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TELEFONE_TELEFONE_TIPO_TipoTelefoneId1",
                        column: x => x.TipoTelefoneId1,
                        principalTable: "TELEFONE_TIPO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_EnderecoId",
                table: "PESSOA",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_PessoaTelefoneId",
                table: "PESSOA",
                column: "PessoaTelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_TELEFONE_PessoaId",
                table: "PESSOA_TELEFONE",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_TELEFONE_TelefoneId",
                table: "PESSOA_TELEFONE",
                column: "TelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_TELEFONE_PessoaId",
                table: "TELEFONE",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_TELEFONE_PessoaTelefoneId",
                table: "TELEFONE",
                column: "PessoaTelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_TELEFONE_TipoTelefoneId",
                table: "TELEFONE",
                column: "TipoTelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_TELEFONE_TipoTelefoneId1",
                table: "TELEFONE",
                column: "TipoTelefoneId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOA_PESSOA_TELEFONE_PessoaTelefoneId",
                table: "PESSOA",
                column: "PessoaTelefoneId",
                principalTable: "PESSOA_TELEFONE",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOA_TELEFONE_TELEFONE_TelefoneId",
                table: "PESSOA_TELEFONE",
                column: "TelefoneId",
                principalTable: "TELEFONE",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOA_ENDERECO_EnderecoId",
                table: "PESSOA");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOA_PESSOA_TELEFONE_PessoaTelefoneId",
                table: "PESSOA");

            migrationBuilder.DropForeignKey(
                name: "FK_TELEFONE_PESSOA_TELEFONE_PessoaTelefoneId",
                table: "TELEFONE");

            migrationBuilder.DropTable(
                name: "ENDERECO");

            migrationBuilder.DropTable(
                name: "PESSOA_TELEFONE");

            migrationBuilder.DropTable(
                name: "TELEFONE");

            migrationBuilder.DropTable(
                name: "PESSOA");

            migrationBuilder.DropTable(
                name: "TELEFONE_TIPO");
        }
    }
}
