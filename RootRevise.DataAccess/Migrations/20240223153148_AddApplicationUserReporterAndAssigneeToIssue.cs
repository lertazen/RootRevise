using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RootRevise.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationUserReporterAndAssigneeToIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReporterId",
                table: "Issues",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AssigneeId",
                table: "Issues",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "IssueId",
                keyValue: 1,
                columns: new[] { "AssigneeId", "DateReported", "DueDate", "ReporterId" },
                values: new object[] { "03f620cd-f77f-4b0c-a07d-74b8466c7920", new DateTime(2024, 2, 23, 10, 31, 46, 605, DateTimeKind.Local).AddTicks(5970), new DateTime(2024, 3, 4, 10, 31, 46, 605, DateTimeKind.Local).AddTicks(6022), "03f620cd-f77f-4b0c-a07d-74b8466c7920" });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_AssigneeId",
                table: "Issues",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_ReporterId",
                table: "Issues",
                column: "ReporterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_AspNetUsers_AssigneeId",
                table: "Issues",
                column: "AssigneeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_AspNetUsers_ReporterId",
                table: "Issues",
                column: "ReporterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_AspNetUsers_AssigneeId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_AspNetUsers_ReporterId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_AssigneeId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_ReporterId",
                table: "Issues");

            migrationBuilder.AlterColumn<int>(
                name: "ReporterId",
                table: "Issues",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "AssigneeId",
                table: "Issues",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "IssueId",
                keyValue: 1,
                columns: new[] { "AssigneeId", "DateReported", "DueDate", "ReporterId" },
                values: new object[] { 1, new DateTime(2024, 2, 21, 7, 14, 21, 795, DateTimeKind.Local).AddTicks(8014), new DateTime(2024, 3, 2, 7, 14, 21, 795, DateTimeKind.Local).AddTicks(8114), 1 });
        }
    }
}
