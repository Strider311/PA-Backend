using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pa.Backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDbModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Sessions_SessionId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_SessionId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "Images",
                newName: "session_id");

            migrationBuilder.AlterColumn<string>(
                name: "sessionName",
                table: "Sessions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "fileName",
                table: "Images",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "session_id",
                table: "Images",
                newName: "SessionId");

            migrationBuilder.AlterColumn<string>(
                name: "sessionName",
                table: "Sessions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fileName",
                table: "Images",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
    }
}