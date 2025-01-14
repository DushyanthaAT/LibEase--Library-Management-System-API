using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibEaseAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "9350fc2a-c547-4d34-9ac6-64bfeb14e5b4", 0, "70e169f2-5fcc-4b30-9f5f-df13990452a7", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEO46fhfYyxSTGtmP4xM+CV5S4rNaTHn9tLQJdzqoklBhOJ8WnoZPXCE5jLIXEsRfjg==", null, false, "72fe6c2f-3607-4965-a132-f7028eb92fa9", false, new Guid("00000000-0000-0000-0000-000000000000"), "admin@example.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9350fc2a-c547-4d34-9ac6-64bfeb14e5b4");
        }
    }
}
