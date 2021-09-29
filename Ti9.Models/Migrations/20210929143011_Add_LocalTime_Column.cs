using Microsoft.EntityFrameworkCore.Migrations;

namespace Ti9.Models.Migrations
{
    public partial class Add_LocalTime_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocalTime",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalTime",
                table: "Clients");
        }
    }
}
