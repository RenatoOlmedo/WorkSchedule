using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSchedule.Data.Migrations
{
    public partial class userComplementos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nomeCompleto",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nomeCompleto",
                table: "AspNetUsers");
        }
    }
}
