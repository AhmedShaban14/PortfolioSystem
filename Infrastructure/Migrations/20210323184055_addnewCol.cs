using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class addnewCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("e538d0e9-1d07-4e0e-89dd-0e1b38089495"));

            migrationBuilder.AddColumn<string>(
                name: "LinkUrl",
                table: "PortfolioItems",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "AddressId", "Avatar", "FullName", "Profile" },
                values: new object[] { new Guid("80186256-7b18-498d-ab79-10239b7e6ec9"), null, "avatar.jpg", "Hamada", "new Motion Graphicer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("80186256-7b18-498d-ab79-10239b7e6ec9"));

            migrationBuilder.DropColumn(
                name: "LinkUrl",
                table: "PortfolioItems");

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "AddressId", "Avatar", "FullName", "Profile" },
                values: new object[] { new Guid("e538d0e9-1d07-4e0e-89dd-0e1b38089495"), null, "avatar.jpg", "Hamada", "new Motion Graphicer" });
        }
    }
}
