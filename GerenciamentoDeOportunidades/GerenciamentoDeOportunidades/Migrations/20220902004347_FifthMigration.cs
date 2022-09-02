using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeOportunidades.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oportunidades",
                columns: table => new
                {
                    CNPJ = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorMonetario = table.Column<float>(type: "real", nullable: false),
                    DescricaoDeAtividades = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodEstadoIBGE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oportunidades", x => x.CNPJ);
                    table.ForeignKey(
                        name: "FK_Oportunidades_Usuarios_UsuarioEmail",
                        column: x => x.UsuarioEmail,
                        principalTable: "Usuarios",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oportunidades_UsuarioEmail",
                table: "Oportunidades",
                column: "UsuarioEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oportunidades");
        }
    }
}
