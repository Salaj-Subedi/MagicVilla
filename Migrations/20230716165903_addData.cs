using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla.Migrations
{
    public partial class addData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Magical_Villas",
                columns: new[] { "Id", "Amenity", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "SqFt", "createdDate", "updatedDate" },
                values: new object[] { 1, "", "abcd acbef sdfsdfhubsdf", "", "villa1", 5, 500, 5000, new DateTime(2023, 7, 16, 22, 44, 2, 909, DateTimeKind.Local).AddTicks(2923), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Magical_Villas",
                columns: new[] { "Id", "Amenity", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "SqFt", "createdDate", "updatedDate" },
                values: new object[] { 2, "", "abcdsafasd acbef sdfsdfhubsdf", "", "villa2", 6, 300, 4000, new DateTime(2023, 7, 16, 22, 44, 2, 909, DateTimeKind.Local).AddTicks(2931), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Magical_Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Magical_Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
