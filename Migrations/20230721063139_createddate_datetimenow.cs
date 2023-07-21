using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla.Migrations
{
    public partial class createddate_datetimenow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "createdDate",
                table: "Magical_Villas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Magical_Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "createdDate",
                value: new DateTime(2023, 7, 21, 12, 16, 38, 917, DateTimeKind.Local).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "Magical_Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "createdDate",
                value: new DateTime(2023, 7, 21, 12, 16, 38, 917, DateTimeKind.Local).AddTicks(8744));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "createdDate",
                table: "Magical_Villas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Magical_Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "createdDate",
                value: new DateTime(2023, 7, 21, 12, 7, 12, 530, DateTimeKind.Local).AddTicks(6606));

            migrationBuilder.UpdateData(
                table: "Magical_Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "createdDate",
                value: new DateTime(2023, 7, 21, 12, 7, 12, 530, DateTimeKind.Local).AddTicks(6616));
        }
    }
}
