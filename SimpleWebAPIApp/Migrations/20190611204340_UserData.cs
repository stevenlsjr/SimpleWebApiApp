using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleWebAPIApp.Migrations
{
    public partial class UserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPost_BlogUser_AuthorId",
                table: "BlogPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogUser",
                table: "BlogUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPost",
                table: "BlogPost");

            migrationBuilder.RenameTable(
                name: "BlogUser",
                newName: "BlogUsers");

            migrationBuilder.RenameTable(
                name: "BlogPost",
                newName: "BlogPosts");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPost_AuthorId",
                table: "BlogPosts",
                newName: "IX_BlogPosts_AuthorId");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "BlogUsers",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "BlogUsers",
                nullable: false,
                defaultValueSql: "now()");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "BlogUsers",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "BlogUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogUsers",
                table: "BlogUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPosts",
                table: "BlogPosts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_BlogUsers_AuthorId",
                table: "BlogPosts",
                column: "AuthorId",
                principalTable: "BlogUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_BlogUsers_AuthorId",
                table: "BlogPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogUsers",
                table: "BlogUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPosts",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "BlogUsers");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "BlogUsers");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "BlogUsers");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "BlogUsers");

            migrationBuilder.RenameTable(
                name: "BlogUsers",
                newName: "BlogUser");

            migrationBuilder.RenameTable(
                name: "BlogPosts",
                newName: "BlogPost");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPosts_AuthorId",
                table: "BlogPost",
                newName: "IX_BlogPost_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogUser",
                table: "BlogUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPost",
                table: "BlogPost",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPost_BlogUser_AuthorId",
                table: "BlogPost",
                column: "AuthorId",
                principalTable: "BlogUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
