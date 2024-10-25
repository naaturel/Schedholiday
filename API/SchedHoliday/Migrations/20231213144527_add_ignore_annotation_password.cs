using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchedHoliday.Migrations
{
    public partial class add_ignore_annotation_password : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: "6afd7c5f4e5441a6a97e8654f205cbcd");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "EndDate", "Latitude", "Longitude", "Name", "StartDate" },
                values: new object[] { "0f51851b922045579c31df74767adcd2", new DateTime(2023, 12, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 5.3641508749561657, 43.299232110638997, "Voyage Marseille", new DateTime(2023, 12, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: "0f51851b922045579c31df74767adcd2");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "EndDate", "Latitude", "Longitude", "Name", "StartDate" },
                values: new object[] { "6afd7c5f4e5441a6a97e8654f205cbcd", new DateTime(2023, 12, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 5.3641508749561657, 43.299232110638997, "Voyage Marseille", new DateTime(2023, 12, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
