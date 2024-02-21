using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RootRevise.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationUserToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "IssueId",
                keyValue: 1,
                columns: new[] { "DateReported", "DueDate" },
                values: new object[] { new DateTime(2024, 2, 21, 7, 14, 21, 795, DateTimeKind.Local).AddTicks(8014), new DateTime(2024, 3, 2, 7, 14, 21, 795, DateTimeKind.Local).AddTicks(8114) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "IssueId",
                keyValue: 1,
                columns: new[] { "DateReported", "DueDate" },
                values: new object[] { new DateTime(2024, 2, 19, 19, 23, 42, 684, DateTimeKind.Local).AddTicks(1117), new DateTime(2024, 2, 29, 19, 23, 42, 684, DateTimeKind.Local).AddTicks(1175) });
        }
    }
}
