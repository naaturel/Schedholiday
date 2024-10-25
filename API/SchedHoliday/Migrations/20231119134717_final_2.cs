using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchedHoliday.Migrations
{
    public partial class final_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: "b658272012da44d4a456ec8c5fa5f1bf");

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "EndDate", "Latitude", "Longitude", "Name", "StartDate" },
                values: new object[] { "311002a360044f27b49d6055a27c7fac", new DateTime(2023, 12, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 5.3641508749561657, 43.299232110638997, "Voyage Marseille", new DateTime(2023, 12, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: "311002a360044f27b49d6055a27c7fac");

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "EndDate", "Latitude", "Longitude", "Name", "StartDate" },
                values: new object[] { "b658272012da44d4a456ec8c5fa5f1bf", new DateTime(2023, 12, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 5.3641508749561657, 43.299232110638997, "Voyage Marseille", new DateTime(2023, 12, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
