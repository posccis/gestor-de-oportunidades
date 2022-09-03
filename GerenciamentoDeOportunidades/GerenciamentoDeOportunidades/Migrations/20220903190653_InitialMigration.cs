using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeOportunidades.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    EmailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regiao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.EmailId);
                });

            migrationBuilder.CreateTable(
                name: "Oportunidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorMonetario = table.Column<float>(type: "real", nullable: false),
                    DescricaoDeAtividades = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodEstadoIBGE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioEmailId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oportunidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oportunidades_usuarios_UsuarioEmailId",
                        column: x => x.UsuarioEmailId,
                        principalTable: "usuarios",
                        principalColumn: "EmailId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oportunidades_UsuarioEmailId",
                table: "Oportunidades",
                column: "UsuarioEmailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oportunidades");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
