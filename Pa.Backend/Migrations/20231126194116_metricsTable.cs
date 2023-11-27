using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pa.Backend.Migrations
{
    /// <inheritdoc />
    public partial class metricsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "healthy_percent",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "unhealthy_percent",
                table: "Images");

            migrationBuilder.AddColumn<bool>(
                name: "is_analyzed",
                table: "Images",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_processed",
                table: "Images",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Metrics",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    index_type = table.Column<int>(type: "integer", nullable: false),
                    healthy_percent = table.Column<float>(type: "real", nullable: false),
                    unhealthy_percent = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metrics", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Metrics");

            migrationBuilder.DropColumn(
                name: "is_analyzed",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "is_processed",
                table: "Images");

            migrationBuilder.AddColumn<float>(
                name: "healthy_percent",
                table: "Images",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "unhealthy_percent",
                table: "Images",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}