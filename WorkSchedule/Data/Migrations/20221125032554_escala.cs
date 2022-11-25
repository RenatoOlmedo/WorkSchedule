using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSchedule.Data.Migrations
{
    public partial class escala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escala",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPessoaEscala = table.Column<int>(type: "int", nullable: true),
                    mes = table.Column<int>(type: "int", nullable: true),
                    usuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    empresaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escala", x => x.id);
                    table.ForeignKey(
                        name: "FK_Escala_AspNetUsers_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Escala_empresa_empresaId",
                        column: x => x.empresaId,
                        principalTable: "empresa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Escala_empresaId",
                table: "Escala",
                column: "empresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Escala_usuarioId",
                table: "Escala",
                column: "usuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Escala");
        }
    }
}
