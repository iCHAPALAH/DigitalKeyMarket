using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalKeyMarket.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Lab4Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_UserId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Playgate_PlatformId",
                table: "Playgate");

            migrationBuilder.DropIndex(
                name: "IX_Item_GameId",
                table: "Item");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ExternalId",
                table: "User",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_ExternalId",
                table: "Role",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_Name",
                table: "Role",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_ExternalId",
                table: "Purchase",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_UserId_ItemId_Date",
                table: "Purchase",
                columns: new[] { "UserId", "ItemId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playgate_ExternalId",
                table: "Playgate",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playgate_PlatformId_ExternalId",
                table: "Playgate",
                columns: new[] { "PlatformId", "ExternalId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platform_ExternalId",
                table: "Platform",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platform_Name",
                table: "Platform",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marketplace_ExternalId",
                table: "Marketplace",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marketplace_Name",
                table: "Marketplace",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_ExternalId",
                table: "Item",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_GameId_PlaygateId_EditionId",
                table: "Item",
                columns: new[] { "GameId", "PlaygateId", "EditionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genre_ExternalId",
                table: "Genre",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genre_Name",
                table: "Genre",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_ExternalId",
                table: "Game",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_Name_ReleaseDate",
                table: "Game",
                columns: new[] { "Name", "ReleaseDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edition_ExternalId",
                table: "Edition",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edition_Name",
                table: "Edition",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Email",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ExternalId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Username",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Role_ExternalId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_Name",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_ExternalId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_UserId_ItemId_Date",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Playgate_ExternalId",
                table: "Playgate");

            migrationBuilder.DropIndex(
                name: "IX_Playgate_PlatformId_ExternalId",
                table: "Playgate");

            migrationBuilder.DropIndex(
                name: "IX_Platform_ExternalId",
                table: "Platform");

            migrationBuilder.DropIndex(
                name: "IX_Platform_Name",
                table: "Platform");

            migrationBuilder.DropIndex(
                name: "IX_Marketplace_ExternalId",
                table: "Marketplace");

            migrationBuilder.DropIndex(
                name: "IX_Marketplace_Name",
                table: "Marketplace");

            migrationBuilder.DropIndex(
                name: "IX_Item_ExternalId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_GameId_PlaygateId_EditionId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Genre_ExternalId",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Genre_Name",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Game_ExternalId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_Name_ReleaseDate",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Edition_ExternalId",
                table: "Edition");

            migrationBuilder.DropIndex(
                name: "IX_Edition_Name",
                table: "Edition");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "User");

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_Permission_Role_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permission_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_UserId",
                table: "Purchase",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Playgate_PlatformId",
                table: "Playgate",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_GameId",
                table: "Item",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_UsersId",
                table: "Permission",
                column: "UsersId");
        }
    }
}
