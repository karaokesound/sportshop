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
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Seller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "City", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "RefreshToken", "TokenCreated", "TokenExpires", "Username" },
                values: new object[,]
                {
                    { new Guid("22f6284c-bcc1-4005-8d9b-f7e8eab90990"), 0, "City4", "Kamil", "Grabak", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User4" },
                    { new Guid("548fdad9-cf3b-42ee-8cc1-b45753394eca"), 0, "City3", "Piotr", "Kowalczyk", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User3" },
                    { new Guid("62b72beb-414d-4ef1-b8dc-3b65306400e0"), 0, "City2", "Andrzej", "Kowalski", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User2" },
                    { new Guid("a60e9d9c-32c8-4dd8-bd94-6c77403a5d83"), 0, "City1", "Jan", "Nowak", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User1" },
                    { new Guid("cb4842bb-dc97-46ff-a0cd-887b6b1350e1"), 0, "City5", "Leon", "Ziutkiewicz", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User5" },
                    { new Guid("f413ff83-cb56-4953-b7e5-21db3dd99f3e"), 0, "City7", "", "", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User7" },
                    { new Guid("f8538c45-7772-4ef5-be9e-c067f3c69f92"), 0, "City6", "", "", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User6" }
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
                keyValue: new Guid("22f6284c-bcc1-4005-8d9b-f7e8eab90990"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("548fdad9-cf3b-42ee-8cc1-b45753394eca"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62b72beb-414d-4ef1-b8dc-3b65306400e0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a60e9d9c-32c8-4dd8-bd94-6c77403a5d83"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cb4842bb-dc97-46ff-a0cd-887b6b1350e1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f413ff83-cb56-4953-b7e5-21db3dd99f3e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f8538c45-7772-4ef5-be9e-c067f3c69f92"));

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
