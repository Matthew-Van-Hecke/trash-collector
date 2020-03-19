using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class AddedCustomerIdForeignKeyToAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1415b566-1be8-4e18-888e-0f7cb4340736");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a0c8c41-5d5d-437e-b917-4a1730ac5c19");

            migrationBuilder.AddColumn<int>(
                name: "Customer_Id",
                table: "Addresses",
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
                name: "IX_Addresses_Customer_Id",
                table: "Addresses",
                column: "Customer_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Customers_Customer_Id",
                table: "Addresses",
                column: "Customer_Id",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customers_Customer_Id",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_Customer_Id",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "957f167d-3071-4eb6-bb9e-d6b8a0dfa892");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "996c8aad-5f1c-4c8d-9e3c-98c7372a9c18");

            migrationBuilder.DropColumn(
                name: "Customer_Id",
                table: "Addresses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1415b566-1be8-4e18-888e-0f7cb4340736", "986c697a-66ac-4475-8369-b199d6c622c3", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5a0c8c41-5d5d-437e-b917-4a1730ac5c19", "26760bb8-2322-4fc8-91b0-733a0f128df9", "Employee", "EMPLOYEE" });
        }
    }
}
