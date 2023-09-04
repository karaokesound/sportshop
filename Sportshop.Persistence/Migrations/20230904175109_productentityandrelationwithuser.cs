using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sportshop.Persistence.Migrations
{
    public partial class productentityandrelationwithuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35618e63-775e-4e72-868d-5061bf04911c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("61e43f2f-5b6f-43a4-a398-5eac427fd0fb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("660ff93b-2f8e-4dbe-bed7-5436cbe33978"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9f285aad-92bc-45e8-b6fa-b6cde5dbc551"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cf0ba25f-583f-4fa0-bb10-bb39da96cc5c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d255ba35-a9b2-4322-93cd-0a4882be08a9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e56c1994-ed3f-4f2c-bd32-474a6673c2a0"));

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Seller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "City", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "RefreshToken", "TokenCreated", "TokenExpires", "Username" },
                values: new object[,]
                {
                    { new Guid("0fc10d5a-905a-435c-8e1f-f5d547dacbc1"), 0, "City5", "Leon", "Ziutkiewicz", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User5" },
                    { new Guid("2711a654-ae49-49a4-803a-2553e0b040bd"), 0, "City7", "", "", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User7" },
                    { new Guid("865c86ee-0511-4a2a-87d1-a503e07c51f5"), 0, "City2", "Andrzej", "Kowalski", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User2" },
                    { new Guid("ba89d110-2934-4d45-9075-3790ff507279"), 0, "City4", "Kamil", "Grabak", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User4" },
                    { new Guid("cfbfce84-fe95-4ab4-88ba-6a4bf52eb23d"), 0, "City6", "", "", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User6" },
                    { new Guid("d57ba5e6-6ca9-4a64-8cb1-4ea4eab6d0db"), 0, "City1", "Jan", "Nowak", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User1" },
                    { new Guid("e7be3653-4c8b-4b2e-af43-806bc0ae3332"), 0, "City3", "Piotr", "Kowalczyk", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0fc10d5a-905a-435c-8e1f-f5d547dacbc1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2711a654-ae49-49a4-803a-2553e0b040bd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("865c86ee-0511-4a2a-87d1-a503e07c51f5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ba89d110-2934-4d45-9075-3790ff507279"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cfbfce84-fe95-4ab4-88ba-6a4bf52eb23d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d57ba5e6-6ca9-4a64-8cb1-4ea4eab6d0db"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e7be3653-4c8b-4b2e-af43-806bc0ae3332"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "City", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "RefreshToken", "TokenCreated", "TokenExpires", "Username" },
                values: new object[,]
                {
                    { new Guid("35618e63-775e-4e72-868d-5061bf04911c"), 0, "City5", "Leon", "Ziutkiewicz", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User5" },
                    { new Guid("61e43f2f-5b6f-43a4-a398-5eac427fd0fb"), 0, "City1", "Jan", "Nowak", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User1" },
                    { new Guid("660ff93b-2f8e-4dbe-bed7-5436cbe33978"), 0, "City2", "Andrzej", "Kowalski", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User2" },
                    { new Guid("9f285aad-92bc-45e8-b6fa-b6cde5dbc551"), 0, "City6", "", "", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User6" },
                    { new Guid("cf0ba25f-583f-4fa0-bb10-bb39da96cc5c"), 0, "City4", "Kamil", "Grabak", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User4" },
                    { new Guid("d255ba35-a9b2-4322-93cd-0a4882be08a9"), 0, "City7", "", "", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User7" },
                    { new Guid("e56c1994-ed3f-4f2c-bd32-474a6673c2a0"), 0, "City3", "Piotr", "Kowalczyk", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User3" }
                });
        }
    }
}
