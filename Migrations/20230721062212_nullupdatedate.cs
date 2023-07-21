using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla.Migrations
{
    public partial class nullupdatedate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedDate",
                table: "Magical_Villas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
                columns: new[] { "createdDate", "updatedDate" },
                values: new object[] { new DateTime(2023, 7, 21, 12, 7, 12, 530, DateTimeKind.Local).AddTicks(6606), null });

            migrationBuilder.UpdateData(
                table: "Magical_Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "createdDate", "updatedDate" },
                values: new object[] { new DateTime(2023, 7, 21, 12, 7, 12, 530, DateTimeKind.Local).AddTicks(6616), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updatedDate",
                table: "Magical_Villas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
                columns: new[] { "createdDate", "updatedDate" },
                values: new object[] { new DateTime(2023, 7, 16, 22, 44, 2, 909, DateTimeKind.Local).AddTicks(2923), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Magical_Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "createdDate", "updatedDate" },
                values: new object[] { new DateTime(2023, 7, 16, 22, 44, 2, 909, DateTimeKind.Local).AddTicks(2931), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
