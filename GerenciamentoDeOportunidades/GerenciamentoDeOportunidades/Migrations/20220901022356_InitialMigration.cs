using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeOportunidades.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regiao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Oportunidades",
                columns: table => new
                {
                    CNPJ = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorMonetario = table.Column<float>(type: "real", nullable: false),
                    DescricaoDeAtividades = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
