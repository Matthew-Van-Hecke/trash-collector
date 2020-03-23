using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class AddedPickedUpBoolToPickUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "399a9fdb-38b4-452f-a46f-3fb46a311c8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6c4cf1e-25fb-4631-8239-8f54961acf7e");

            migrationBuilder.AddColumn<bool>(
                name: "PickedUp",
                table: "Pickups",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "25c7b847-1567-4220-ac94-3ccdf5dd93a1", "7c4875ab-8289-4149-b16e-41df693a0ec9", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "21ccca8d-320e-477d-933c-7da85ff4479a", "ca5ab5bc-d050-465c-bbb1-dd68ca4f7dce", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21ccca8d-320e-477d-933c-7da85ff4479a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25c7b847-1567-4220-ac94-3ccdf5dd93a1");

            migrationBuilder.DropColumn(
                name: "PickedUp",
                table: "Pickups");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e6c4cf1e-25fb-4631-8239-8f54961acf7e", "ed2713ca-c903-4933-9a7a-1c5e0a2f0688", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "399a9fdb-38b4-452f-a46f-3fb46a311c8b", "c106aa4c-1782-4ae0-8c9f-66235892368f", "Employee", "EMPLOYEE" });
        }
    }
}
