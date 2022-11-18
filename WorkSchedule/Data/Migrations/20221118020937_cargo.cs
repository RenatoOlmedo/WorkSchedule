using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSchedule.Data.Migrations
{
    public partial class cargo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cargaHorariaDiaria",
                table: "AspNetUsers",
                newName: "horasTrabalho");

            migrationBuilder.AddColumn<int>(
                name: "User_status",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cargoId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nomeCargo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_cargoId",
                table: "AspNetUsers",
                column: "cargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_cargoId",
                table: "AspNetUsers",
                column: "cargoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_cargoId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_cargoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "User_status",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "cargoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "nomeCargo",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "horasTrabalho",
                table: "AspNetUsers",
                newName: "cargaHorariaDiaria");
        }
    }
}
