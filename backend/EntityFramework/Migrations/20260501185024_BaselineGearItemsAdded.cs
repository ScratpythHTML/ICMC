using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class BaselineGearItemsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Ropes",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateOfPurchase",
                table: "Ropes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InspectedBy",
                table: "Ropes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastInspection",
                table: "Ropes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "Ropes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ManufacturerExpiry",
                table: "Ropes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Model",
                table: "Ropes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NextInspection",
                table: "Ropes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToughTag",
                table: "Ropes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Ropes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Quickdraws",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateOfPurchase",
                table: "Quickdraws",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InspectedBy",
                table: "Quickdraws",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastInspection",
                table: "Quickdraws",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ManufacturerExpiry",
                table: "Quickdraws",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Model",
                table: "Quickdraws",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NextInspection",
                table: "Quickdraws",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToughTag",
                table: "Quickdraws",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Quickdraws",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Helmets",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateOfPurchase",
                table: "Helmets",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InspectedBy",
                table: "Helmets",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastInspection",
                table: "Helmets",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ManufacturerExpiry",
                table: "Helmets",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Model",
                table: "Helmets",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NextInspection",
                table: "Helmets",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Helmets",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToughTag",
                table: "Helmets",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Helmets",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Harnesses",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateOfPurchase",
                table: "Harnesses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InspectedBy",
                table: "Harnesses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastInspection",
                table: "Harnesses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ManufacturerExpiry",
                table: "Harnesses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Model",
                table: "Harnesses",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NextInspection",
                table: "Harnesses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "Harnesses",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Harnesses",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToughTag",
                table: "Harnesses",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Harnesses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Crashpads",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateOfPurchase",
                table: "Crashpads",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InspectedBy",
                table: "Crashpads",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastInspection",
                table: "Crashpads",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ManufacturerExpiry",
                table: "Crashpads",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Model",
                table: "Crashpads",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NextInspection",
                table: "Crashpads",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToughTag",
                table: "Crashpads",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Crashpads",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Carabiners",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateOfPurchase",
                table: "Carabiners",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InspectedBy",
                table: "Carabiners",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastInspection",
                table: "Carabiners",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ManufacturerExpiry",
                table: "Carabiners",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Model",
                table: "Carabiners",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NextInspection",
                table: "Carabiners",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToughTag",
                table: "Carabiners",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Carabiners",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "BelayDevices",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateOfPurchase",
                table: "BelayDevices",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InspectedBy",
                table: "BelayDevices",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastInspection",
                table: "BelayDevices",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ManufacturerExpiry",
                table: "BelayDevices",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Model",
                table: "BelayDevices",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NextInspection",
                table: "BelayDevices",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToughTag",
                table: "BelayDevices",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "BelayDevices",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CID = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    SecondName = table.Column<string>(type: "text", nullable: true),
                    UserEmail = table.Column<string>(type: "text", nullable: true),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ropes_UserId",
                table: "Ropes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Quickdraws_UserId",
                table: "Quickdraws",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Helmets_UserId",
                table: "Helmets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Harnesses_UserId",
                table: "Harnesses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Crashpads_UserId",
                table: "Crashpads",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carabiners_UserId",
                table: "Carabiners",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BelayDevices_UserId",
                table: "BelayDevices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BelayDevices_Users_UserId",
                table: "BelayDevices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carabiners_Users_UserId",
                table: "Carabiners",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crashpads_Users_UserId",
                table: "Crashpads",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Harnesses_Users_UserId",
                table: "Harnesses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Helmets_Users_UserId",
                table: "Helmets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quickdraws_Users_UserId",
                table: "Quickdraws",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ropes_Users_UserId",
                table: "Ropes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BelayDevices_Users_UserId",
                table: "BelayDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_Carabiners_Users_UserId",
                table: "Carabiners");

            migrationBuilder.DropForeignKey(
                name: "FK_Crashpads_Users_UserId",
                table: "Crashpads");

            migrationBuilder.DropForeignKey(
                name: "FK_Harnesses_Users_UserId",
                table: "Harnesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Helmets_Users_UserId",
                table: "Helmets");

            migrationBuilder.DropForeignKey(
                name: "FK_Quickdraws_Users_UserId",
                table: "Quickdraws");

            migrationBuilder.DropForeignKey(
                name: "FK_Ropes_Users_UserId",
                table: "Ropes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Ropes_UserId",
                table: "Ropes");

            migrationBuilder.DropIndex(
                name: "IX_Quickdraws_UserId",
                table: "Quickdraws");

            migrationBuilder.DropIndex(
                name: "IX_Helmets_UserId",
                table: "Helmets");

            migrationBuilder.DropIndex(
                name: "IX_Harnesses_UserId",
                table: "Harnesses");

            migrationBuilder.DropIndex(
                name: "IX_Crashpads_UserId",
                table: "Crashpads");

            migrationBuilder.DropIndex(
                name: "IX_Carabiners_UserId",
                table: "Carabiners");

            migrationBuilder.DropIndex(
                name: "IX_BelayDevices_UserId",
                table: "BelayDevices");

            migrationBuilder.DropColumn(
                name: "DateOfPurchase",
                table: "Ropes");

            migrationBuilder.DropColumn(
                name: "InspectedBy",
                table: "Ropes");

            migrationBuilder.DropColumn(
                name: "LastInspection",
                table: "Ropes");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Ropes");

            migrationBuilder.DropColumn(
                name: "ManufacturerExpiry",
                table: "Ropes");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Ropes");

            migrationBuilder.DropColumn(
                name: "NextInspection",
                table: "Ropes");

            migrationBuilder.DropColumn(
                name: "ToughTag",
                table: "Ropes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ropes");

            migrationBuilder.DropColumn(
                name: "DateOfPurchase",
                table: "Quickdraws");

            migrationBuilder.DropColumn(
                name: "InspectedBy",
                table: "Quickdraws");

            migrationBuilder.DropColumn(
                name: "LastInspection",
                table: "Quickdraws");

            migrationBuilder.DropColumn(
                name: "ManufacturerExpiry",
                table: "Quickdraws");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Quickdraws");

            migrationBuilder.DropColumn(
                name: "NextInspection",
                table: "Quickdraws");

            migrationBuilder.DropColumn(
                name: "ToughTag",
                table: "Quickdraws");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Quickdraws");

            migrationBuilder.DropColumn(
                name: "DateOfPurchase",
                table: "Helmets");

            migrationBuilder.DropColumn(
                name: "InspectedBy",
                table: "Helmets");

            migrationBuilder.DropColumn(
                name: "LastInspection",
                table: "Helmets");

            migrationBuilder.DropColumn(
                name: "ManufacturerExpiry",
                table: "Helmets");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Helmets");

            migrationBuilder.DropColumn(
                name: "NextInspection",
                table: "Helmets");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Helmets");

            migrationBuilder.DropColumn(
                name: "ToughTag",
                table: "Helmets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Helmets");

            migrationBuilder.DropColumn(
                name: "DateOfPurchase",
                table: "Harnesses");

            migrationBuilder.DropColumn(
                name: "InspectedBy",
                table: "Harnesses");

            migrationBuilder.DropColumn(
                name: "LastInspection",
                table: "Harnesses");

            migrationBuilder.DropColumn(
                name: "ManufacturerExpiry",
                table: "Harnesses");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Harnesses");

            migrationBuilder.DropColumn(
                name: "NextInspection",
                table: "Harnesses");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Harnesses");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Harnesses");

            migrationBuilder.DropColumn(
                name: "ToughTag",
                table: "Harnesses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Harnesses");

            migrationBuilder.DropColumn(
                name: "DateOfPurchase",
                table: "Crashpads");

            migrationBuilder.DropColumn(
                name: "InspectedBy",
                table: "Crashpads");

            migrationBuilder.DropColumn(
                name: "LastInspection",
                table: "Crashpads");

            migrationBuilder.DropColumn(
                name: "ManufacturerExpiry",
                table: "Crashpads");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Crashpads");

            migrationBuilder.DropColumn(
                name: "NextInspection",
                table: "Crashpads");

            migrationBuilder.DropColumn(
                name: "ToughTag",
                table: "Crashpads");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Crashpads");

            migrationBuilder.DropColumn(
                name: "DateOfPurchase",
                table: "Carabiners");

            migrationBuilder.DropColumn(
                name: "InspectedBy",
                table: "Carabiners");

            migrationBuilder.DropColumn(
                name: "LastInspection",
                table: "Carabiners");

            migrationBuilder.DropColumn(
                name: "ManufacturerExpiry",
                table: "Carabiners");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Carabiners");

            migrationBuilder.DropColumn(
                name: "NextInspection",
                table: "Carabiners");

            migrationBuilder.DropColumn(
                name: "ToughTag",
                table: "Carabiners");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Carabiners");

            migrationBuilder.DropColumn(
                name: "DateOfPurchase",
                table: "BelayDevices");

            migrationBuilder.DropColumn(
                name: "InspectedBy",
                table: "BelayDevices");

            migrationBuilder.DropColumn(
                name: "LastInspection",
                table: "BelayDevices");

            migrationBuilder.DropColumn(
                name: "ManufacturerExpiry",
                table: "BelayDevices");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "BelayDevices");

            migrationBuilder.DropColumn(
                name: "NextInspection",
                table: "BelayDevices");

            migrationBuilder.DropColumn(
                name: "ToughTag",
                table: "BelayDevices");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BelayDevices");

            migrationBuilder.AlterColumn<int>(
                name: "Brand",
                table: "Ropes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Brand",
                table: "Quickdraws",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Brand",
                table: "Helmets",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Brand",
                table: "Harnesses",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Brand",
                table: "Crashpads",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Brand",
                table: "Carabiners",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Brand",
                table: "BelayDevices",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
