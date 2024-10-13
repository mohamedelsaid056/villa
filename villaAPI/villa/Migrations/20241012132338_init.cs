using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace villa.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Sqft = table.Column<int>(type: "int", nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amenity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2024, 10, 12, 16, 23, 35, 304, DateTimeKind.Local).AddTicks(3023), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet.", "https://dotnetmastery.com/bluevillaimages/villa1.jpg", "Royal Villa", 4, 200.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", new DateTime(2024, 10, 12, 16, 23, 35, 304, DateTimeKind.Local).AddTicks(3030), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet.", "https://dotnetmastery.com/bluevillaimages/villa2.jpg", "Premium Pool Villa", 4, 300.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", new DateTime(2024, 10, 12, 16, 23, 35, 304, DateTimeKind.Local).AddTicks(3076), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet.", "https://dotnetmastery.com/bluevillaimages/villa3.jpg", "Luxury Ocean Villa", 6, 500.0, 750, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "", new DateTime(2024, 10, 12, 16, 23, 35, 304, DateTimeKind.Local).AddTicks(3081), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet.", "https://dotnetmastery.com/bluevillaimages/villa4.jpg", "Diamond Villa", 4, 550.0, 900, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "", new DateTime(2024, 10, 12, 16, 23, 35, 304, DateTimeKind.Local).AddTicks(3087), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet.", "https://dotnetmastery.com/bluevillaimages/villa5.jpg", "Diamond Pool Villa", 4, 600.0, 1100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
