using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pa.Backend.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "session_path",
                table: "Sessions");

            migrationBuilder.AddColumn<string>(
                name: "image_path",
                table: "Metrics",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "file_path",
                table: "Images",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image_path",
                table: "Metrics");

            migrationBuilder.DropColumn(
                name: "file_path",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "session_path",
                table: "Sessions",
                type: "text",
                nullable: true);
        }
    }
}
