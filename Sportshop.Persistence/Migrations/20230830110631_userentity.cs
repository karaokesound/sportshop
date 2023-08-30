using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sportshop.Persistence.Migrations
{
    public partial class userentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "City", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "RefreshToken", "TokenCreated", "TokenExpires", "Username" },
                values: new object[,]
                {
                    { new Guid("1f8495b1-0969-4dcf-b94a-2764d1978e69"), 25, "City5", "Leon", "Ziutkiewicz", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User5" },
                    { new Guid("55d80fe9-84a6-48f2-8007-44cfe1ced61e"), 22, "City2", "Andrzej", "Kowalski", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User2" },
                    { new Guid("5c802b03-58fe-4fa1-8c52-46d79b42d639"), 29, "City9", "Joanna", "Leśniewska", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User9" },
                    { new Guid("5e590b39-9711-46ce-aa92-1d3f5367a86a"), 27, "City7", "Andrzej", "Kipik", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User7" },
                    { new Guid("6aab6139-4995-4fd0-92f9-3a6c050c1471"), 30, "City10", "Weronika", "Kalinka", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User10" },
                    { new Guid("7a0b2dd0-a41f-4237-b63a-79a5a0603f53"), 21, "City1", "Jan", "Nowak", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User1" },
                    { new Guid("845d6324-6e38-4115-b5ca-1dcbd45f74fc"), 26, "City6", "Karol", "Strasburger", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User6" },
                    { new Guid("a098b00e-e251-464a-994d-c2250895f6ce"), 23, "City3", "Piotr", "Kowalczyk", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User3" },
                    { new Guid("be35196e-4804-4bcc-9e59-34df791b312f"), 32, "City12", "", "", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User12" },
                    { new Guid("cc2f769a-6e14-4780-b2cc-21a13eaafd38"), 24, "City4", "Kamil", "Grabak", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User4" },
                    { new Guid("df22440c-346e-42ea-adf2-222afa1b164d"), 31, "City11", "", "", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User11" },
                    { new Guid("f4c46df4-4a8a-4033-99bc-65544623d136"), 28, "City8", "Marzena", "Bogacz", null, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User8" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
