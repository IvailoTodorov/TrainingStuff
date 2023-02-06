using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatForumApp.Data.Migrations
{
    public partial class ModelsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Replies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Replies",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Replies_UserId",
                table: "Replies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_AspNetUsers_UserId",
                table: "Replies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_AspNetUsers_UserId",
                table: "Replies");

            migrationBuilder.DropIndex(
                name: "IX_Replies_UserId",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Comments");
        }
    }
}
