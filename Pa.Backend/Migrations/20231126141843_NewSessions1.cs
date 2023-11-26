using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pa.Backend.Migrations
{
    /// <inheritdoc />
    public partial class NewSessions1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "session_id",
                table: "Images",
                newName: "SessionId");

            migrationBuilder.AlterColumn<string>(
                name: "fileName",
                table: "Images",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dtCreated",
                table: "Images",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "lstModified",
                table: "Images",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    sessionName = table.Column<string>(type: "text", nullable: false),
                    healthyPercentage = table.Column<float>(type: "real", nullable: false),
                    unhealthyPercentage = table.Column<float>(type: "real", nullable: false),
                    dtCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    lstModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_SessionId",
                table: "Images",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Sessions_SessionId",
                table: "Images",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Sessions_SessionId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Images_SessionId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "dtCreated",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "lstModified",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "Images",
                newName: "session_id");

            migrationBuilder.AlterColumn<string>(
                name: "fileName",
                table: "Images",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
