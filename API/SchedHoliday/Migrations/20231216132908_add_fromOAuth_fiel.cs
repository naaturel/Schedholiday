using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchedHoliday.Migrations
{
    public partial class add_fromOAuth_fiel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: "0f51851b922045579c31df74767adcd2");

            migrationBuilder.AddColumn<bool>(
                name: "fromOAuth",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "EndDate", "Latitude", "Longitude", "Name", "StartDate" },
                values: new object[] { "c4586a79cabf4534b690864d7d2093a8", new DateTime(2023, 12, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 5.3641508749561657, 43.299232110638997, "Voyage Marseille", new DateTime(2023, 12, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: "c4586a79cabf4534b690864d7d2093a8");

            migrationBuilder.DropColumn(
                name: "fromOAuth",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "EndDate", "Latitude", "Longitude", "Name", "StartDate" },
                values: new object[] { "0f51851b922045579c31df74767adcd2", new DateTime(2023, 12, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 5.3641508749561657, 43.299232110638997, "Voyage Marseille", new DateTime(2023, 12, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
