using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations.AspNetIdentity.AspNetIdentityDb
{
    public partial class UpdateAppUserIdentityDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "baa2f328-569d-4d08-9f6c-b84ef506fc37", "AQAAAAEAACcQAAAAEABh3VVY9lslC1i5G/2ajLzotWdQ0w2sanGH2hblE/OmU/BGPUjUiDTzvi1FxSxT+g==", "6db25c7a-025b-4054-9070-810b4dc8b050" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffd6f0d4-aff2-4fb5-93ba-d4963d882755", "AQAAAAEAACcQAAAAEIMK7RGHfb7SiSmiMDBJM14hiGWA4TsnW05T2MB7RpNf1UzcHhVssquLDzmCap9n2w==", "28cd8cc5-2afd-414a-9d2c-486b07099168" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

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
    }
}
