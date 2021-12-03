    using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class NewProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Create",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 3, 13, 46, 24, 140, DateTimeKind.Local).AddTicks(5191),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 15, 22, 9, 85, DateTimeKind.Local).AddTicks(8746));

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Clientes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Create",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 15, 22, 9, 85, DateTimeKind.Local).AddTicks(8746),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 3, 13, 46, 24, 140, DateTimeKind.Local).AddTicks(5191));
        }
    }
}
