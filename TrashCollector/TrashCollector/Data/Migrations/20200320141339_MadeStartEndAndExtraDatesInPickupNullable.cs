using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class MadeStartEndAndExtraDatesInPickupNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b0fbf23-eac5-4909-8d73-ea1baa6bec5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25251984-e7cc-4cd5-af6e-f06fb81c44d0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24fc53aa-7e4d-4e07-ae3f-d4f7262874be", "e7884ef1-e7b8-4a97-8fbb-29b2d41ee0fa", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "acb4cd9f-386e-453e-a75a-e00e6d7608e6", "6030451f-0804-41e0-af5c-84122832e828", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24fc53aa-7e4d-4e07-ae3f-d4f7262874be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acb4cd9f-386e-453e-a75a-e00e6d7608e6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1b0fbf23-eac5-4909-8d73-ea1baa6bec5b", "955b72e3-f7ee-4171-b482-94856a84cbbc", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "25251984-e7cc-4cd5-af6e-f06fb81c44d0", "3584c3bf-93dc-4461-b8d6-80d089455fe4", "Employee", "EMPLOYEE" });
        }
    }
}
