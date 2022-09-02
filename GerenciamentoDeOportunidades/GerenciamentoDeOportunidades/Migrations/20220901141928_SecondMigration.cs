﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeOportunidades.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodEstadoIBGE",
                table: "Oportunidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodEstadoIBGE",
                table: "Oportunidades");
        }
    }
}
