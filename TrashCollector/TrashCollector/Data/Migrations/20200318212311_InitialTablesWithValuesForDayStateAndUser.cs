using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class InitialTablesWithValuesForDayStateAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f88343e2-9bb9-4707-814e-073eb0c69c67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffa98516-d48d-402a-b95e-87ee4f0c9695");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Balance_Due = table.Column<double>(nullable: false),
                    IdentityUser_Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_IdentityUser_Id",
                        column: x => x.IdentityUser_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street_Number_and_Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Zip_Code = table.Column<int>(nullable: false),
                    USStateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_USStates_USStateId",
                        column: x => x.USStateId,
                        principalTable: "USStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IdentityUser_Id = table.Column<string>(nullable: true),
                    Address_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Addresses_Address_Id",
                        column: x => x.Address_Id,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_IdentityUser_Id",
                        column: x => x.IdentityUser_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pickups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Id = table.Column<int>(nullable: false),
                    Address_Id = table.Column<int>(nullable: false),
                    Day_Id = table.Column<int>(nullable: false),
                    Start_Of_Pickup_Suspension = table.Column<DateTime>(nullable: false),
                    End_Of_Pickup_Suspension = table.Column<DateTime>(nullable: false),
                    Date_Of_Extra_Pickup = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pickups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pickups_Addresses_Address_Id",
                        column: x => x.Address_Id,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pickups_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pickups_Days_Day_Id",
                        column: x => x.Day_Id,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1415b566-1be8-4e18-888e-0f7cb4340736", "986c697a-66ac-4475-8369-b199d6c622c3", "Customer", "CUSTOMER" },
                    { "5a0c8c41-5d5d-437e-b917-4a1730ac5c19", "26760bb8-2322-4fc8-91b0-733a0f128df9", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "Days",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sunday" },
                    { 2, "Monday" },
                    { 3, "Tuesday" },
                    { 4, "Wednesday" },
                    { 5, "Thursday" },
                    { 6, "Friday" },
                    { 7, "Saturday" }
                });

            migrationBuilder.InsertData(
                table: "USStates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 35, "Ohio" },
                    { 34, "North Dakota" },
                    { 33, "North Carolina" },
                    { 32, "New York" },
                    { 27, "Nebraska" },
                    { 30, "New Jersey" },
                    { 29, "New Hampshire" },
                    { 28, "Nevada" },
                    { 36, "Oklahoma" },
                    { 31, "New Mexico" },
                    { 37, "Oregon" },
                    { 41, "South Dakota" },
                    { 39, "Rhode Island" },
                    { 40, "South Carolina" },
                    { 26, "Montana" },
                    { 42, "Tennessee" },
                    { 43, "Texas" },
                    { 44, "Utah" },
                    { 45, "Vermont" },
                    { 46, "Virginia" },
                    { 47, "Washington" },
                    { 48, "West Virginia" },
                    { 38, "Pennsylvania" },
                    { 25, "Missouri" },
                    { 21, "Massachusetts" },
                    { 23, "Minnesota" },
                    { 1, "Alabama" },
                    { 2, "Alaska" },
                    { 3, "Arizona" },
                    { 4, "Arkansas" },
                    { 5, "California" },
                    { 6, "Colorado" },
                    { 7, "Connecticut" },
                    { 8, "Delaware" },
                    { 9, "Florida" },
                    { 10, "Georgia" },
                    { 24, "Mississippi" },
                    { 11, "Hawaii" },
                    { 13, "Illinois" },
                    { 14, "Indiana" },
                    { 15, "Iowa" },
                    { 16, "Kansas" },
                    { 17, "Kentucky" },
                    { 18, "Louisiana" },
                    { 19, "Maine" },
                    { 20, "Maryland" },
                    { 49, "Wisconsin" },
                    { 22, "Michigan" },
                    { 12, "Idaho" },
                    { 50, "Wyoming" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_USStateId",
                table: "Addresses",
                column: "USStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdentityUser_Id",
                table: "Customers",
                column: "IdentityUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Address_Id",
                table: "Employees",
                column: "Address_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdentityUser_Id",
                table: "Employees",
                column: "IdentityUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pickups_Address_Id",
                table: "Pickups",
                column: "Address_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pickups_Customer_Id",
                table: "Pickups",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pickups_Day_Id",
                table: "Pickups",
                column: "Day_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Pickups");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "USStates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1415b566-1be8-4e18-888e-0f7cb4340736");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a0c8c41-5d5d-437e-b917-4a1730ac5c19");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f88343e2-9bb9-4707-814e-073eb0c69c67", "fd61ddd2-8850-4a17-a733-f0e9a00a8a2d", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ffa98516-d48d-402a-b95e-87ee4f0c9695", "a98f9371-3118-4341-9dd4-d4300bd9b822", "Employee", "EMPLOYEE" });
        }
    }
}
