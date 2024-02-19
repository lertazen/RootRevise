using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RootRevise.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 2, 18, 17, 3, 8, 242, DateTimeKind.Local).AddTicks(4617));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 2, 18, 17, 3, 8, 242, DateTimeKind.Local).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 2, 18, 17, 3, 8, 242, DateTimeKind.Local).AddTicks(4624));

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "IssueId",
                keyValue: 1,
                columns: new[] { "DateReported", "DueDate" },
                values: new object[] { new DateTime(2024, 2, 18, 17, 3, 8, 242, DateTimeKind.Local).AddTicks(4339), new DateTime(2024, 2, 28, 17, 3, 8, 242, DateTimeKind.Local).AddTicks(4393) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "Description",
                value: "This is a testing project");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 2, 18, 11, 54, 13, 79, DateTimeKind.Local).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 2, 18, 11, 54, 13, 79, DateTimeKind.Local).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 2, 18, 11, 54, 13, 79, DateTimeKind.Local).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "IssueId",
                keyValue: 1,
                columns: new[] { "DateReported", "DueDate" },
                values: new object[] { new DateTime(2024, 2, 18, 11, 54, 13, 79, DateTimeKind.Local).AddTicks(1747), new DateTime(2024, 2, 28, 11, 54, 13, 79, DateTimeKind.Local).AddTicks(1806) });
        }
    }
}
