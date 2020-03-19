using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class ReplacedAddressWithZipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Addresses_Address_Id",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Address_Id",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "957f167d-3071-4eb6-bb9e-d6b8a0dfa892");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "996c8aad-5f1c-4c8d-9e3c-98c7372a9c18");

            migrationBuilder.DropColumn(
                name: "Address_Id",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1b0fbf23-eac5-4909-8d73-ea1baa6bec5b", "955b72e3-f7ee-4171-b482-94856a84cbbc", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "25251984-e7cc-4cd5-af6e-f06fb81c44d0", "3584c3bf-93dc-4461-b8d6-80d089455fe4", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b0fbf23-eac5-4909-8d73-ea1baa6bec5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25251984-e7cc-4cd5-af6e-f06fb81c44d0");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "Address_Id",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "957f167d-3071-4eb6-bb9e-d6b8a0dfa892", "955b0d9c-7155-4ad1-b642-28b525033930", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "996c8aad-5f1c-4c8d-9e3c-98c7372a9c18", "9a91d567-0cfe-43ac-ac20-93331ec176d4", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Address_Id",
                table: "Employees",
                column: "Address_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Addresses_Address_Id",
                table: "Employees",
                column: "Address_Id",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
