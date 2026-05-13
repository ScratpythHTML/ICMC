using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class MoreFieldsToEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LentBy",
                table: "Logbook");

            migrationBuilder.DropColumn(
                name: "LentTo",
                table: "Logbook");

            migrationBuilder.DropColumn(
                name: "InspectedBy",
                table: "GearItems");

            migrationBuilder.DropColumn(
                name: "LentBy",
                table: "GearItems");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Users",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "LentTo",
                table: "GearItems",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<int>(
                name: "InspectedByUserId",
                table: "Logbook",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LentByUserId",
                table: "Logbook",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LentToUserId",
                table: "Logbook",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ToughTag",
                table: "GearItems",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ExpectedReturnDate",
                table: "GearItems",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InspectedByUserId",
                table: "GearItems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LentByUserId",
                table: "GearItems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LentToUserId",
                table: "GearItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logbook_GearItemId",
                table: "Logbook",
                column: "GearItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Logbook_InspectedByUserId",
                table: "Logbook",
                column: "InspectedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Logbook_LentByUserId",
                table: "Logbook",
                column: "LentByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Logbook_LentToUserId",
                table: "Logbook",
                column: "LentToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GearItems_InspectedByUserId",
                table: "GearItems",
                column: "InspectedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GearItems_LentByUserId",
                table: "GearItems",
                column: "LentByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GearItems_LentToUserId",
                table: "GearItems",
                column: "LentToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GearItems_Users_InspectedByUserId",
                table: "GearItems",
                column: "InspectedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GearItems_Users_LentByUserId",
                table: "GearItems",
                column: "LentByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GearItems_Users_LentToUserId",
                table: "GearItems",
                column: "LentToUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Logbook_GearItems_GearItemId",
                table: "Logbook",
                column: "GearItemId",
                principalTable: "GearItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logbook_Users_InspectedByUserId",
                table: "Logbook",
                column: "InspectedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Logbook_Users_LentByUserId",
                table: "Logbook",
                column: "LentByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Logbook_Users_LentToUserId",
                table: "Logbook",
                column: "LentToUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GearItems_Users_InspectedByUserId",
                table: "GearItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GearItems_Users_LentByUserId",
                table: "GearItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GearItems_Users_LentToUserId",
                table: "GearItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Logbook_GearItems_GearItemId",
                table: "Logbook");

            migrationBuilder.DropForeignKey(
                name: "FK_Logbook_Users_InspectedByUserId",
                table: "Logbook");

            migrationBuilder.DropForeignKey(
                name: "FK_Logbook_Users_LentByUserId",
                table: "Logbook");

            migrationBuilder.DropForeignKey(
                name: "FK_Logbook_Users_LentToUserId",
                table: "Logbook");

            migrationBuilder.DropIndex(
                name: "IX_Logbook_GearItemId",
                table: "Logbook");

            migrationBuilder.DropIndex(
                name: "IX_Logbook_InspectedByUserId",
                table: "Logbook");

            migrationBuilder.DropIndex(
                name: "IX_Logbook_LentByUserId",
                table: "Logbook");

            migrationBuilder.DropIndex(
                name: "IX_Logbook_LentToUserId",
                table: "Logbook");

            migrationBuilder.DropIndex(
                name: "IX_GearItems_InspectedByUserId",
                table: "GearItems");

            migrationBuilder.DropIndex(
                name: "IX_GearItems_LentByUserId",
                table: "GearItems");

            migrationBuilder.DropIndex(
                name: "IX_GearItems_LentToUserId",
                table: "GearItems");

            migrationBuilder.DropColumn(
                name: "InspectedByUserId",
                table: "Logbook");

            migrationBuilder.DropColumn(
                name: "LentByUserId",
                table: "Logbook");

            migrationBuilder.DropColumn(
                name: "LentToUserId",
                table: "Logbook");

            migrationBuilder.DropColumn(
                name: "ExpectedReturnDate",
                table: "GearItems");

            migrationBuilder.DropColumn(
                name: "InspectedByUserId",
                table: "GearItems");

            migrationBuilder.DropColumn(
                name: "LentByUserId",
                table: "GearItems");

            migrationBuilder.DropColumn(
                name: "LentToUserId",
                table: "GearItems");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "GearItems",
                newName: "LentTo");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LentBy",
                table: "Logbook",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LentTo",
                table: "Logbook",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ToughTag",
                table: "GearItems",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InspectedBy",
                table: "GearItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LentBy",
                table: "GearItems",
                type: "text",
                nullable: true);
        }
    }
}
