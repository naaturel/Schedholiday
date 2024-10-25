using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchedHoliday.Migrations
{
    public partial class final_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activitys_Holidays_Id",
                table: "Activitys");

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: "311002a360044f27b49d6055a27c7fac");

            migrationBuilder.AlterColumn<string>(
                name: "HolidayId",
                table: "Activitys",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "EndDate", "Latitude", "Longitude", "Name", "StartDate" },
                values: new object[] { "bf5dffde7b024a2582a6d4b74eeda8c6", new DateTime(2023, 12, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 5.3641508749561657, 43.299232110638997, "Voyage Marseille", new DateTime(2023, 12, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Activitys_HolidayId",
                table: "Activitys",
                column: "HolidayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activitys_Holidays_HolidayId",
                table: "Activitys",
                column: "HolidayId",
                principalTable: "Holidays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activitys_Holidays_HolidayId",
                table: "Activitys");

            migrationBuilder.DropIndex(
                name: "IX_Activitys_HolidayId",
                table: "Activitys");

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: "bf5dffde7b024a2582a6d4b74eeda8c6");

            migrationBuilder.AlterColumn<string>(
                name: "HolidayId",
                table: "Activitys",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "EndDate", "Latitude", "Longitude", "Name", "StartDate" },
                values: new object[] { "311002a360044f27b49d6055a27c7fac", new DateTime(2023, 12, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 5.3641508749561657, 43.299232110638997, "Voyage Marseille", new DateTime(2023, 12, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.AddForeignKey(
                name: "FK_Activitys_Holidays_Id",
                table: "Activitys",
                column: "Id",
                principalTable: "Holidays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
