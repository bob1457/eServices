using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations.AspNetIdentity.AspNetIdentityDb
{
    public partial class CustomizedUsersIdentityDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02f5989c-86a9-41d2-b911-f61278743ca2", "AQAAAAEAACcQAAAAEL8qLtUtHTvT+tx+z5OZzbXiNC5zF0hHtfZkshM6Hm6ITFGJyGw5KD8jjnk9IxxaiA==", "bc1a3532-5be2-47b8-93c0-94aa4aedc25a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6e7e6a6-f906-4768-a044-cc9b6a75b7a7", "AQAAAAEAACcQAAAAEL4sjwIaaCYSHaekKV8/MC9URHQ+peoasxwUf7m0CS7TPkBcAgrp+3cJl0hT53URLQ==", "d1026a71-4b44-4a41-972a-744f402651c8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0076419-303f-4939-a76f-6b7f95565c7c", "AQAAAAEAACcQAAAAEMZRDQpPm25luuIw5bYGFZFdomLn8WO6PITE5kO1E5ePhyn8RJcSC5OlgWmBu4xfLA==", "a2078aa0-5c79-4dc1-a4b4-3065a534db8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa775390-cbc9-456c-a608-524a077dead6", "AQAAAAEAACcQAAAAELnSQMhmsJHJtbH3BxxZEp3MExeSZ6uHnCnpp5oa3mAnV2Jqn4vy+I1O0dUKzoT0Jw==", "6d5df826-fb5e-4193-b30a-dc406ec15b5a" });
        }
    }
}
