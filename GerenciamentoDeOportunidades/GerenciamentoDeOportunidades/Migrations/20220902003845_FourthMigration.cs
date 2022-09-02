using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeOportunidades.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oportunidades");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oportunidades",
                columns: table => new
                {
                    CNPJ = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodEstadoIBGE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescricaoDeAtividades = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ValorMonetario = table.Column<float>(type: "real", nullable: false)
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
    }
}
