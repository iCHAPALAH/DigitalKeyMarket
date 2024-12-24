using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalKeyMarket.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Lab5Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_user_roles_RoleId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "User",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Birthday",
                table: "User",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddForeignKey(
                name: "FK_User_user_roles_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "user_roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_user_roles_RoleId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Birthday",
                table: "User",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_user_roles_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "user_roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
