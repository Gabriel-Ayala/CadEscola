using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CadEscola.Migrations
{
    public partial class responsaveis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "responsavelId",
                table: "Alunos",
                newName: "ResponsavelId");

            migrationBuilder.CreateTable(
                name: "Responsaveis",
                columns: table => new
                {
                    ResponsavelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<int>(type: "int", maxLength: 180, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsaveis", x => x.ResponsavelId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ResponsavelId",
                table: "Alunos",
                column: "ResponsavelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Responsaveis_ResponsavelId",
                table: "Alunos",
                column: "ResponsavelId",
                principalTable: "Responsaveis",
                principalColumn: "ResponsavelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Responsaveis_ResponsavelId",
                table: "Alunos");

            migrationBuilder.DropTable(
                name: "Responsaveis");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_ResponsavelId",
                table: "Alunos");

            migrationBuilder.RenameColumn(
                name: "ResponsavelId",
                table: "Alunos",
                newName: "responsavelId");
        }
    }
}
