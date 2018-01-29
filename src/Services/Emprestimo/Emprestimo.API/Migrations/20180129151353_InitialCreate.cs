using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace trturino.GerenciadorGames.Services.Emprestimo.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "emprestimo_id_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Emprestimos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    AmigoId = table.Column<int>(nullable: false),
                    AmigoNome = table.Column<string>(nullable: true),
                    DataDoEmprestimo = table.Column<DateTime>(nullable: false),
                    Devolvido = table.Column<bool>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    GameNome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimos");

            migrationBuilder.DropSequence(
                name: "emprestimo_id_hilo");
        }
    }
}
