using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSchedule.Data.Migrations
{
    public partial class _2tiposEscala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "horasTrabalho",
                table: "cargo",
                newName: "Trabalho");

            migrationBuilder.RenameColumn(
                name: "horasDescanso",
                table: "cargo",
                newName: "Descanso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Trabalho",
                table: "cargo",
                newName: "horasTrabalho");

            migrationBuilder.RenameColumn(
                name: "Descanso",
                table: "cargo",
                newName: "horasDescanso");
        }
    }
}
