using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla.Migrations
{
    public partial class workingfineagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Magical_Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "createdDate",
                value: new DateTime(2024, 1, 9, 0, 7, 31, 994, DateTimeKind.Local).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "Magical_Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "createdDate",
                value: new DateTime(2024, 1, 9, 0, 7, 31, 994, DateTimeKind.Local).AddTicks(4913));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
