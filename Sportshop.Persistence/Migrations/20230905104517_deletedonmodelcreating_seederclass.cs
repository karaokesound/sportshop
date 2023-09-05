using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sportshop.Persistence.Migrations
{
    public partial class deletedonmodelcreating_seederclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
