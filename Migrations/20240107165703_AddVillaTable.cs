using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla.Migrations
{
    public partial class AddVillaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Magical_Villas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    SqFt = table.Column<int>(type: "int", nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amenity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magical_Villas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Magical_Villas",
                columns: new[] { "Id", "Amenity", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "SqFt", "createdDate", "updatedDate" },
                values: new object[] { 1, "", "abcd acbef sdfsdfhubsdf", "", "villa1", 5, 500, 5000, new DateTime(2024, 1, 7, 22, 42, 3, 702, DateTimeKind.Local).AddTicks(4756), null });

            migrationBuilder.InsertData(
                table: "Magical_Villas",
                columns: new[] { "Id", "Amenity", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "SqFt", "createdDate", "updatedDate" },
                values: new object[] { 2, "", "abcdsafasd acbef sdfsdfhubsdf", "", "villa2", 6, 300, 4000, new DateTime(2024, 1, 7, 22, 42, 3, 702, DateTimeKind.Local).AddTicks(4758), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Magical_Villas");
        }
    }
}
