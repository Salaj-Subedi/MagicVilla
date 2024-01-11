using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla.Migrations
{
    public partial class workingfine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Magical_Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "createdDate",
                value: new DateTime(2024, 1, 9, 0, 7, 16, 903, DateTimeKind.Local).AddTicks(5565));

            migrationBuilder.UpdateData(
                table: "Magical_Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "createdDate",
                value: new DateTime(2024, 1, 9, 0, 7, 16, 903, DateTimeKind.Local).AddTicks(5643));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Magical_Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "createdDate",
                value: new DateTime(2024, 1, 7, 22, 42, 3, 702, DateTimeKind.Local).AddTicks(4756));

            migrationBuilder.UpdateData(
                table: "Magical_Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "createdDate",
                value: new DateTime(2024, 1, 7, 22, 42, 3, 702, DateTimeKind.Local).AddTicks(4758));
        }
    }
}
