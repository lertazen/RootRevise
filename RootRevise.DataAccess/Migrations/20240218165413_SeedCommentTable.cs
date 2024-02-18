using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RootRevise.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedCommentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_AuthorId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Issues_IssueId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_IssueId",
                table: "Comments",
                newName: "IX_Comments_IssueId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_AuthorId",
                table: "Comments",
                newName: "IX_Comments_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "AuthorId", "CommentText", "DateCreated", "DateUpdated", "IssueId" },
                values: new object[,]
                {
                    { 1, "5ac5ba6a-4033-4e1d-8f84-49efab12cee2", "This is the test comment #1", new DateTime(2024, 2, 18, 11, 54, 13, 79, DateTimeKind.Local).AddTicks(2016), null, 1 },
                    { 2, "5ac5ba6a-4033-4e1d-8f84-49efab12cee2", "This is the test comment #2", new DateTime(2024, 2, 18, 11, 54, 13, 79, DateTimeKind.Local).AddTicks(2021), null, 2 },
                    { 3, "5ac5ba6a-4033-4e1d-8f84-49efab12cee2", "This is the test comment #3", new DateTime(2024, 2, 18, 11, 54, 13, 79, DateTimeKind.Local).AddTicks(2023), null, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "IssueId",
                keyValue: 1,
                columns: new[] { "DateReported", "DueDate" },
                values: new object[] { new DateTime(2024, 2, 18, 11, 54, 13, 79, DateTimeKind.Local).AddTicks(1747), new DateTime(2024, 2, 28, 11, 54, 13, 79, DateTimeKind.Local).AddTicks(1806) });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Issues_IssueId",
                table: "Comments",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "IssueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Issues_IssueId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_IssueId",
                table: "Comment",
                newName: "IX_Comment_IssueId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AuthorId",
                table: "Comment",
                newName: "IX_Comment_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "CommentId");

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "IssueId",
                keyValue: 1,
                columns: new[] { "DateReported", "DueDate" },
                values: new object[] { new DateTime(2024, 2, 18, 10, 37, 34, 693, DateTimeKind.Local).AddTicks(5598), new DateTime(2024, 2, 28, 10, 37, 34, 693, DateTimeKind.Local).AddTicks(5649) });

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_AuthorId",
                table: "Comment",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Issues_IssueId",
                table: "Comment",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "IssueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
