using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddStorageLocationToGear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StorageLocation",
                table: "Ropes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StorageLocation",
                table: "Quickdraws",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StorageLocation",
                table: "Helmets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StorageLocation",
                table: "Harnesses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StorageLocation",
                table: "Crashpads",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StorageLocation",
                table: "Carabiners",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StorageLocation",
                table: "BelayDevices",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StorageLocation",
                table: "Ropes");

            migrationBuilder.DropColumn(
                name: "StorageLocation",
                table: "Quickdraws");

            migrationBuilder.DropColumn(
                name: "StorageLocation",
                table: "Helmets");

            migrationBuilder.DropColumn(
                name: "StorageLocation",
                table: "Harnesses");

            migrationBuilder.DropColumn(
                name: "StorageLocation",
                table: "Crashpads");

            migrationBuilder.DropColumn(
                name: "StorageLocation",
                table: "Carabiners");

            migrationBuilder.DropColumn(
                name: "StorageLocation",
                table: "BelayDevices");
        }
    }
}
