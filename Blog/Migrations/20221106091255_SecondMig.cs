﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class SecondMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "SubComments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MainComments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubComments_UserId",
                table: "SubComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MainComments_UserId",
                table: "MainComments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainComments_AspNetUsers_UserId",
                table: "MainComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubComments_AspNetUsers_UserId",
                table: "SubComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainComments_AspNetUsers_UserId",
                table: "MainComments");

            migrationBuilder.DropForeignKey(
                name: "FK_SubComments_AspNetUsers_UserId",
                table: "SubComments");

            migrationBuilder.DropIndex(
                name: "IX_SubComments_UserId",
                table: "SubComments");

            migrationBuilder.DropIndex(
                name: "IX_MainComments_UserId",
                table: "MainComments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SubComments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MainComments");
        }
    }
}
