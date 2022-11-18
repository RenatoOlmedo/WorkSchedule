using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSchedule.Data.Migrations
{
    public partial class cargoFkEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "empresaId",
                table: "cargo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_cargo_empresaId",
                table: "cargo",
                column: "empresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_cargo_empresa_empresaId",
                table: "cargo",
                column: "empresaId",
                principalTable: "empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cargo_empresa_empresaId",
                table: "cargo");

            migrationBuilder.DropIndex(
                name: "IX_cargo_empresaId",
                table: "cargo");

            migrationBuilder.DropColumn(
                name: "empresaId",
                table: "cargo");
        }
    }
}
