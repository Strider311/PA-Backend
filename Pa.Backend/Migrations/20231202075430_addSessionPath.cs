using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pa.Backend.Migrations
{
    /// <inheritdoc />
    public partial class addSessionPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "session_path",
                table: "Sessions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "session_path",
                table: "Sessions");
        }
    }
}
