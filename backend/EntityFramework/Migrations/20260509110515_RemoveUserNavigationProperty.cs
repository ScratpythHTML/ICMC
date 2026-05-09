using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserNavigationProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BelayDevices_Users_UserCID",
                table: "BelayDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_Carabiners_Users_UserCID",
                table: "Carabiners");

            migrationBuilder.DropForeignKey(
                name: "FK_Crashpads_Users_UserCID",
                table: "Crashpads");

            migrationBuilder.DropForeignKey(
                name: "FK_Harnesses_Users_UserCID",
                table: "Harnesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Helmets_Users_UserCID",
                table: "Helmets");

            migrationBuilder.DropForeignKey(
                name: "FK_Quickdraws_Users_UserCID",
                table: "Quickdraws");

            migrationBuilder.DropForeignKey(
                name: "FK_Ropes_Users_UserCID",
                table: "Ropes");

            migrationBuilder.DropIndex(
                name: "IX_Ropes_UserCID",
                table: "Ropes");

            migrationBuilder.DropIndex(
                name: "IX_Quickdraws_UserCID",
                table: "Quickdraws");

            migrationBuilder.DropIndex(
                name: "IX_Helmets_UserCID",
                table: "Helmets");

            migrationBuilder.DropIndex(
                name: "IX_Harnesses_UserCID",
                table: "Harnesses");

            migrationBuilder.DropIndex(
                name: "IX_Crashpads_UserCID",
                table: "Crashpads");

            migrationBuilder.DropIndex(
                name: "IX_Carabiners_UserCID",
                table: "Carabiners");

            migrationBuilder.DropIndex(
                name: "IX_BelayDevices_UserCID",
                table: "BelayDevices");

            migrationBuilder.DropColumn(
                name: "UserCID",
                table: "Ropes");

            migrationBuilder.DropColumn(
                name: "UserCID",
                table: "Quickdraws");

            migrationBuilder.DropColumn(
                name: "UserCID",
                table: "Helmets");

            migrationBuilder.DropColumn(
                name: "UserCID",
                table: "Harnesses");

            migrationBuilder.DropColumn(
                name: "UserCID",
                table: "Crashpads");

            migrationBuilder.DropColumn(
                name: "UserCID",
                table: "Carabiners");

            migrationBuilder.DropColumn(
                name: "UserCID",
                table: "BelayDevices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserCID",
                table: "Ropes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCID",
                table: "Quickdraws",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCID",
                table: "Helmets",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCID",
                table: "Harnesses",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCID",
                table: "Crashpads",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCID",
                table: "Carabiners",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCID",
                table: "BelayDevices",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ropes_UserCID",
                table: "Ropes",
                column: "UserCID");

            migrationBuilder.CreateIndex(
                name: "IX_Quickdraws_UserCID",
                table: "Quickdraws",
                column: "UserCID");

            migrationBuilder.CreateIndex(
                name: "IX_Helmets_UserCID",
                table: "Helmets",
                column: "UserCID");

            migrationBuilder.CreateIndex(
                name: "IX_Harnesses_UserCID",
                table: "Harnesses",
                column: "UserCID");

            migrationBuilder.CreateIndex(
                name: "IX_Crashpads_UserCID",
                table: "Crashpads",
                column: "UserCID");

            migrationBuilder.CreateIndex(
                name: "IX_Carabiners_UserCID",
                table: "Carabiners",
                column: "UserCID");

            migrationBuilder.CreateIndex(
                name: "IX_BelayDevices_UserCID",
                table: "BelayDevices",
                column: "UserCID");

            migrationBuilder.AddForeignKey(
                name: "FK_BelayDevices_Users_UserCID",
                table: "BelayDevices",
                column: "UserCID",
                principalTable: "Users",
                principalColumn: "CID");

            migrationBuilder.AddForeignKey(
                name: "FK_Carabiners_Users_UserCID",
                table: "Carabiners",
                column: "UserCID",
                principalTable: "Users",
                principalColumn: "CID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crashpads_Users_UserCID",
                table: "Crashpads",
                column: "UserCID",
                principalTable: "Users",
                principalColumn: "CID");

            migrationBuilder.AddForeignKey(
                name: "FK_Harnesses_Users_UserCID",
                table: "Harnesses",
                column: "UserCID",
                principalTable: "Users",
                principalColumn: "CID");

            migrationBuilder.AddForeignKey(
                name: "FK_Helmets_Users_UserCID",
                table: "Helmets",
                column: "UserCID",
                principalTable: "Users",
                principalColumn: "CID");

            migrationBuilder.AddForeignKey(
                name: "FK_Quickdraws_Users_UserCID",
                table: "Quickdraws",
                column: "UserCID",
                principalTable: "Users",
                principalColumn: "CID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ropes_Users_UserCID",
                table: "Ropes",
                column: "UserCID",
                principalTable: "Users",
                principalColumn: "CID");
        }
    }
}
