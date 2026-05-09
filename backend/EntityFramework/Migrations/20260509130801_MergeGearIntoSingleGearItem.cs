using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class MergeGearIntoSingleGearItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BelayDevices");

            migrationBuilder.DropTable(
                name: "Carabiners");

            migrationBuilder.DropTable(
                name: "Crashpads");

            migrationBuilder.DropTable(
                name: "Harnesses");

            migrationBuilder.DropTable(
                name: "Helmets");

            migrationBuilder.DropTable(
                name: "Quickdraws");

            migrationBuilder.DropTable(
                name: "Ropes");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Users",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "Users",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "MemberType",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GearItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ToughTag = table.Column<int>(type: "integer", nullable: true),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<int>(type: "integer", nullable: true),
                    DateOfPurchase = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ManufacturerExpiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastInspection = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    NextInspection = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    InspectedBy = table.Column<int>(type: "integer", nullable: true),
                    LentTo = table.Column<int>(type: "integer", nullable: true),
                    LentBy = table.Column<int>(type: "integer", nullable: true),
                    LentDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ReturnedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    StorageLocation = table.Column<int>(type: "integer", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: true),
                    Sex = table.Column<int>(type: "integer", nullable: true),
                    Length = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logbook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GearItemId = table.Column<int>(type: "integer", nullable: false),
                    LentTo = table.Column<int>(type: "integer", nullable: false),
                    LentBy = table.Column<int>(type: "integer", nullable: false),
                    LentDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ReturnedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logbook", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GearItems");

            migrationBuilder.DropTable(
                name: "Logbook");

            migrationBuilder.DropColumn(
                name: "MemberType",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Users",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "SecondName");

            migrationBuilder.CreateTable(
                name: "BelayDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    DateOfPurchase = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    InspectedBy = table.Column<int>(type: "integer", nullable: true),
                    LastInspection = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LentBy = table.Column<int>(type: "integer", nullable: true),
                    LentTo = table.Column<int>(type: "integer", nullable: true),
                    ManufacturerExpiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Model = table.Column<int>(type: "integer", nullable: true),
                    NextInspection = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ReturnedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    StorageLocation = table.Column<int>(type: "integer", nullable: false),
                    ToughTag = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BelayDevices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carabiners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    DateOfPurchase = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    InspectedBy = table.Column<int>(type: "integer", nullable: true),
                    LastInspection = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LentBy = table.Column<int>(type: "integer", nullable: true),
                    LentTo = table.Column<int>(type: "integer", nullable: true),
                    ManufacturerExpiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Model = table.Column<int>(type: "integer", nullable: true),
                    NextInspection = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ReturnedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    StorageLocation = table.Column<int>(type: "integer", nullable: false),
                    ToughTag = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carabiners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Crashpads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    DateOfPurchase = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    InspectedBy = table.Column<int>(type: "integer", nullable: true),
                    LastInspection = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LentBy = table.Column<int>(type: "integer", nullable: true),
                    LentTo = table.Column<int>(type: "integer", nullable: true),
                    ManufacturerExpiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Model = table.Column<int>(type: "integer", nullable: true),
                    NextInspection = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ReturnedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    StorageLocation = table.Column<int>(type: "integer", nullable: false),
                    ToughTag = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crashpads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Harnesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    DateOfPurchase = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    InspectedBy = table.Column<int>(type: "integer", nullable: true),
                    LastInspection = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LentBy = table.Column<int>(type: "integer", nullable: true),
                    LentTo = table.Column<int>(type: "integer", nullable: true),
                    ManufacturerExpiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Model = table.Column<int>(type: "integer", nullable: true),
                    NextInspection = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ReturnedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Sex = table.Column<int>(type: "integer", nullable: true),
                    Size = table.Column<int>(type: "integer", nullable: true),
                    StorageLocation = table.Column<int>(type: "integer", nullable: false),
                    ToughTag = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harnesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Helmets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    DateOfPurchase = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    InspectedBy = table.Column<int>(type: "integer", nullable: true),
                    LastInspection = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LentBy = table.Column<int>(type: "integer", nullable: true),
                    LentTo = table.Column<int>(type: "integer", nullable: true),
                    ManufacturerExpiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Model = table.Column<int>(type: "integer", nullable: true),
                    NextInspection = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ReturnedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Size = table.Column<int>(type: "integer", nullable: true),
                    StorageLocation = table.Column<int>(type: "integer", nullable: false),
                    ToughTag = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helmets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quickdraws",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    DateOfPurchase = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    InspectedBy = table.Column<int>(type: "integer", nullable: true),
                    LastInspection = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LentBy = table.Column<int>(type: "integer", nullable: true),
                    LentTo = table.Column<int>(type: "integer", nullable: true),
                    ManufacturerExpiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Model = table.Column<int>(type: "integer", nullable: true),
                    NextInspection = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ReturnedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    StorageLocation = table.Column<int>(type: "integer", nullable: false),
                    ToughTag = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quickdraws", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ropes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    DateOfPurchase = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    InspectedBy = table.Column<int>(type: "integer", nullable: true),
                    LastInspection = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Length = table.Column<int>(type: "integer", nullable: true),
                    LentBy = table.Column<int>(type: "integer", nullable: true),
                    LentTo = table.Column<int>(type: "integer", nullable: true),
                    ManufacturerExpiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Model = table.Column<int>(type: "integer", nullable: true),
                    NextInspection = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ReturnedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    StorageLocation = table.Column<int>(type: "integer", nullable: false),
                    ToughTag = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ropes", x => x.Id);
                });
        }
    }
}
