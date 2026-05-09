using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class IncludeLendingLogicAndCID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

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
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ropes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Quickdraws");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Helmets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Harnesses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Crashpads");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Carabiners");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BelayDevices");

            migrationBuilder.Sql("ALTER TABLE \"Users\" ALTER COLUMN \"CID\" TYPE integer USING \"CID\"::integer;");
            migrationBuilder.Sql("ALTER TABLE \"Ropes\" ALTER COLUMN \"InspectedBy\" TYPE integer USING NULL;");
            migrationBuilder.Sql("ALTER TABLE \"Quickdraws\" ALTER COLUMN \"InspectedBy\" TYPE integer USING NULL;");
            migrationBuilder.Sql("ALTER TABLE \"Helmets\" ALTER COLUMN \"InspectedBy\" TYPE integer USING NULL;");
            migrationBuilder.Sql("ALTER TABLE \"Harnesses\" ALTER COLUMN \"InspectedBy\" TYPE integer USING NULL;");
            migrationBuilder.Sql("ALTER TABLE \"Crashpads\" ALTER COLUMN \"InspectedBy\" TYPE integer USING NULL;");
            migrationBuilder.Sql("ALTER TABLE \"Carabiners\" ALTER COLUMN \"InspectedBy\" TYPE integer USING NULL;");
            migrationBuilder.Sql("ALTER TABLE \"BelayDevices\" ALTER COLUMN \"InspectedBy\" TYPE integer USING NULL;");

            migrationBuilder.AlterColumn<int>(
                name: "CID",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "InspectedBy",
                table: "Ropes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LentBy",
                table: "Ropes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LentTo",
                table: "Ropes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ReturnedDate",
                table: "Ropes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCID",
                table: "Ropes",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InspectedBy",
                table: "Quickdraws",
                type: "integer",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LentBy",
                table: "Quickdraws",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LentTo",
                table: "Quickdraws",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ReturnedDate",
                table: "Quickdraws",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCID",
                table: "Quickdraws",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InspectedBy",
                table: "Helmets",
                type: "integer",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LentBy",
                table: "Helmets",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LentTo",
                table: "Helmets",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ReturnedDate",
                table: "Helmets",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCID",
                table: "Helmets",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InspectedBy",
                table: "Harnesses",
                type: "integer",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LentBy",
                table: "Harnesses",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LentTo",
                table: "Harnesses",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ReturnedDate",
                table: "Harnesses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCID",
                table: "Harnesses",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InspectedBy",
                table: "Crashpads",
                type: "integer",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LentBy",
                table: "Crashpads",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LentTo",
                table: "Crashpads",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ReturnedDate",
                table: "Crashpads",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCID",
                table: "Crashpads",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InspectedBy",
                table: "Carabiners",
                type: "integer",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LentBy",
                table: "Carabiners",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LentTo",
                table: "Carabiners",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ReturnedDate",
                table: "Carabiners",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCID",
                table: "Carabiners",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InspectedBy",
                table: "BelayDevices",
                type: "integer",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LentBy",
                table: "BelayDevices",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LentTo",
                table: "BelayDevices",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ReturnedDate",
                table: "BelayDevices",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCID",
                table: "BelayDevices",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "CID");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

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
                name: "LentBy",
                table: "Ropes");

            migrationBuilder.DropColumn(
                name: "LentTo",
                table: "Ropes");

            migrationBuilder.DropColumn(
                name: "ReturnedDate",
                table: "Ropes");

            migrationBuilder.DropColumn(
                name: "UserCID",
                table: "Ropes");

            migrationBuilder.DropColumn(
                name: "LentBy",
                table: "Quickdraws");

            migrationBuilder.DropColumn(
                name: "LentTo",
                table: "Quickdraws");

            migrationBuilder.DropColumn(
                name: "ReturnedDate",
                table: "Quickdraws");

            migrationBuilder.DropColumn(
                name: "UserCID",
                table: "Quickdraws");

            migrationBuilder.DropColumn(
                name: "LentBy",
                table: "Helmets");

            migrationBuilder.DropColumn(
                name: "LentTo",
                table: "Helmets");

            migrationBuilder.DropColumn(
                name: "ReturnedDate",
                table: "Helmets");

            migrationBuilder.DropColumn(
                name: "UserCID",
                table: "Helmets");

            migrationBuilder.DropColumn(
                name: "LentBy",
                table: "Harnesses");

            migrationBuilder.DropColumn(
                name: "LentTo",
                table: "Harnesses");

            migrationBuilder.DropColumn(
                name: "ReturnedDate",
                table: "Harnesses");

            migrationBuilder.DropColumn(
                name: "UserCID",
                table: "Harnesses");

            migrationBuilder.DropColumn(
                name: "LentBy",
                table: "Crashpads");

            migrationBuilder.DropColumn(
                name: "LentTo",
                table: "Crashpads");

            migrationBuilder.DropColumn(
                name: "ReturnedDate",
                table: "Crashpads");

            migrationBuilder.DropColumn(
                name: "UserCID",
                table: "Crashpads");

            migrationBuilder.DropColumn(
                name: "LentBy",
                table: "Carabiners");

            migrationBuilder.DropColumn(
                name: "LentTo",
                table: "Carabiners");

            migrationBuilder.DropColumn(
                name: "ReturnedDate",
                table: "Carabiners");

            migrationBuilder.DropColumn(
                name: "UserCID",
                table: "Carabiners");

            migrationBuilder.DropColumn(
                name: "LentBy",
                table: "BelayDevices");

            migrationBuilder.DropColumn(
                name: "LentTo",
                table: "BelayDevices");

            migrationBuilder.DropColumn(
                name: "ReturnedDate",
                table: "BelayDevices");

            migrationBuilder.DropColumn(
                name: "UserCID",
                table: "BelayDevices");

            migrationBuilder.AlterColumn<string>(
                name: "CID",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.Sql("ALTER TABLE \"Ropes\" ALTER COLUMN \"InspectedBy\" TYPE uuid USING NULL;");
            migrationBuilder.Sql("ALTER TABLE \"Quickdraws\" ALTER COLUMN \"InspectedBy\" TYPE uuid USING NULL;");
            migrationBuilder.Sql("ALTER TABLE \"Helmets\" ALTER COLUMN \"InspectedBy\" TYPE uuid USING NULL;");
            migrationBuilder.Sql("ALTER TABLE \"Harnesses\" ALTER COLUMN \"InspectedBy\" TYPE uuid USING NULL;");
            migrationBuilder.Sql("ALTER TABLE \"Crashpads\" ALTER COLUMN \"InspectedBy\" TYPE uuid USING NULL;");
            migrationBuilder.Sql("ALTER TABLE \"Carabiners\" ALTER COLUMN \"InspectedBy\" TYPE uuid USING NULL;");
            migrationBuilder.Sql("ALTER TABLE \"BelayDevices\" ALTER COLUMN \"InspectedBy\" TYPE uuid USING NULL;");

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectedBy",
                table: "Ropes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Ropes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectedBy",
                table: "Quickdraws",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Quickdraws",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectedBy",
                table: "Helmets",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Helmets",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectedBy",
                table: "Harnesses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Harnesses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectedBy",
                table: "Crashpads",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Crashpads",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectedBy",
                table: "Carabiners",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Carabiners",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectedBy",
                table: "BelayDevices",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "BelayDevices",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

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
    }
}
