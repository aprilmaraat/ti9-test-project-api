using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ti9.Models.Migrations
{
    public partial class Modify_Clients_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LocalTime",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Resolution",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeZone",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Browser",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LocalTime",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Resolution",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "TimeZone",
                table: "Clients");
        }
    }
}
