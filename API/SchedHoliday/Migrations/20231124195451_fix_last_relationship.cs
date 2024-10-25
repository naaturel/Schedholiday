using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchedHoliday.Migrations
{
    public partial class fix_last_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Holidays_Id",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Participe_AspNetUsers_UsersId",
                table: "Participe");

            migrationBuilder.DropForeignKey(
                name: "FK_Participe_Holidays_HolidaysId",
                table: "Participe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participe",
                table: "Participe");

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: "bf5dffde7b024a2582a6d4b74eeda8c6");

            migrationBuilder.RenameTable(
                name: "Participe",
                newName: "UsersHolidays");

            migrationBuilder.RenameIndex(
                name: "IX_Participe_UsersId",
                table: "UsersHolidays",
                newName: "IX_UsersHolidays_UsersId");

            migrationBuilder.AlterColumn<string>(
                name: "HolidayId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Activitys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Activitys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Activitys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Activitys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersHolidays",
                table: "UsersHolidays",
                columns: new[] { "HolidaysId", "UsersId" });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "EndDate", "Latitude", "Longitude", "Name", "StartDate" },
                values: new object[] { "7f72fa9435754e24b46f82648ddd3c88", new DateTime(2023, 12, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 5.3641508749561657, 43.299232110638997, "Voyage Marseille", new DateTime(2023, 12, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_HolidayId",
                table: "Messages",
                column: "HolidayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Holidays_HolidayId",
                table: "Messages",
                column: "HolidayId",
                principalTable: "Holidays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersHolidays_AspNetUsers_UsersId",
                table: "UsersHolidays",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersHolidays_Holidays_HolidaysId",
                table: "UsersHolidays",
                column: "HolidaysId",
                principalTable: "Holidays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Holidays_HolidayId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersHolidays_AspNetUsers_UsersId",
                table: "UsersHolidays");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersHolidays_Holidays_HolidaysId",
                table: "UsersHolidays");

            migrationBuilder.DropIndex(
                name: "IX_Messages_HolidayId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersHolidays",
                table: "UsersHolidays");

            migrationBuilder.DeleteData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: "7f72fa9435754e24b46f82648ddd3c88");

            migrationBuilder.RenameTable(
                name: "UsersHolidays",
                newName: "Participe");

            migrationBuilder.RenameIndex(
                name: "IX_UsersHolidays_UsersId",
                table: "Participe",
                newName: "IX_Participe_UsersId");

            migrationBuilder.AlterColumn<string>(
                name: "HolidayId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Activitys",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Activitys",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Activitys",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Activitys",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participe",
                table: "Participe",
                columns: new[] { "HolidaysId", "UsersId" });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "EndDate", "Latitude", "Longitude", "Name", "StartDate" },
                values: new object[] { "bf5dffde7b024a2582a6d4b74eeda8c6", new DateTime(2023, 12, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 5.3641508749561657, 43.299232110638997, "Voyage Marseille", new DateTime(2023, 12, 15, 17, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Holidays_Id",
                table: "Messages",
                column: "Id",
                principalTable: "Holidays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participe_AspNetUsers_UsersId",
                table: "Participe",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participe_Holidays_HolidaysId",
                table: "Participe",
                column: "HolidaysId",
                principalTable: "Holidays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
