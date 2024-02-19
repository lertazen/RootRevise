using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RootRevise.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInitialComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 2, 19, 17, 39, 38, 832, DateTimeKind.Local).AddTicks(7419));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                columns: new[] { "DateCreated", "IssueId" },
                values: new object[] { new DateTime(2024, 2, 19, 17, 39, 38, 832, DateTimeKind.Local).AddTicks(7425), 1 });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                columns: new[] { "DateCreated", "IssueId" },
                values: new object[] { new DateTime(2024, 2, 19, 17, 39, 38, 832, DateTimeKind.Local).AddTicks(7427), 1 });

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "IssueId",
                keyValue: 1,
                columns: new[] { "DateReported", "DueDate" },
                values: new object[] { new DateTime(2024, 2, 19, 17, 39, 38, 832, DateTimeKind.Local).AddTicks(7020), new DateTime(2024, 2, 29, 17, 39, 38, 832, DateTimeKind.Local).AddTicks(7087) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "DateCreated", "IssueId" },
                values: new object[] { new DateTime(2024, 2, 18, 17, 3, 8, 242, DateTimeKind.Local).AddTicks(4623), 2 });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                columns: new[] { "DateCreated", "IssueId" },
                values: new object[] { new DateTime(2024, 2, 18, 17, 3, 8, 242, DateTimeKind.Local).AddTicks(4624), 3 });

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "IssueId",
                keyValue: 1,
                columns: new[] { "DateReported", "DueDate" },
                values: new object[] { new DateTime(2024, 2, 18, 17, 3, 8, 242, DateTimeKind.Local).AddTicks(4339), new DateTime(2024, 2, 28, 17, 3, 8, 242, DateTimeKind.Local).AddTicks(4393) });
        }
    }
}
