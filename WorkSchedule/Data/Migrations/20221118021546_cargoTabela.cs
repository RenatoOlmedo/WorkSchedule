using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSchedule.Data.Migrations
{
    public partial class cargoTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_cargoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "User_status",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "horasDescanso",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "horasTrabalho",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "nomeCargo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "tipoEscala",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "cargoId",
                table: "AspNetUsers",
                newName: "cargoid");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_cargoId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_cargoid");

            migrationBuilder.AlterColumn<int>(
                name: "cargoid",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "cargo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeCargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoEscala = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    horasTrabalho = table.Column<int>(type: "int", nullable: true),
                    horasDescanso = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargo", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_cargo_cargoid",
                table: "AspNetUsers",
                column: "cargoid",
                principalTable: "cargo",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_cargo_cargoid",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "cargo");

            migrationBuilder.RenameColumn(
                name: "cargoid",
                table: "AspNetUsers",
                newName: "cargoId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_cargoid",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_cargoId");

            migrationBuilder.AlterColumn<string>(
                name: "cargoId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_status",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "horasDescanso",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "horasTrabalho",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nomeCargo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tipoEscala",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_cargoId",
                table: "AspNetUsers",
                column: "cargoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
