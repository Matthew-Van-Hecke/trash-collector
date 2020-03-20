using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class MadeStartEndAndExtraDatesInPickupNullableB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24fc53aa-7e4d-4e07-ae3f-d4f7262874be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acb4cd9f-386e-453e-a75a-e00e6d7608e6");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start_Of_Pickup_Suspension",
                table: "Pickups",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End_Of_Pickup_Suspension",
                table: "Pickups",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Of_Extra_Pickup",
                table: "Pickups",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e6c4cf1e-25fb-4631-8239-8f54961acf7e", "ed2713ca-c903-4933-9a7a-1c5e0a2f0688", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "399a9fdb-38b4-452f-a46f-3fb46a311c8b", "c106aa4c-1782-4ae0-8c9f-66235892368f", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "399a9fdb-38b4-452f-a46f-3fb46a311c8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6c4cf1e-25fb-4631-8239-8f54961acf7e");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start_Of_Pickup_Suspension",
                table: "Pickups",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "End_Of_Pickup_Suspension",
                table: "Pickups",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Of_Extra_Pickup",
                table: "Pickups",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24fc53aa-7e4d-4e07-ae3f-d4f7262874be", "e7884ef1-e7b8-4a97-8fbb-29b2d41ee0fa", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "acb4cd9f-386e-453e-a75a-e00e6d7608e6", "6030451f-0804-41e0-af5c-84122832e828", "Employee", "EMPLOYEE" });
        }
    }
}
