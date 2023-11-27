using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pa.Backend.Migrations
{
    /// <inheritdoc />
    public partial class renameModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "unhealthyPercentage",
                table: "Sessions",
                newName: "unhealthy_percent");

            migrationBuilder.RenameColumn(
                name: "sessionName",
                table: "Sessions",
                newName: "session_name");

            migrationBuilder.RenameColumn(
                name: "lstModified",
                table: "Sessions",
                newName: "lst_modified");

            migrationBuilder.RenameColumn(
                name: "healthyPercentage",
                table: "Sessions",
                newName: "healthy_percent");

            migrationBuilder.RenameColumn(
                name: "dtCreated",
                table: "Sessions",
                newName: "dt_created");

            migrationBuilder.RenameColumn(
                name: "unhealthyPercentage",
                table: "Images",
                newName: "unhealthy_percent");

            migrationBuilder.RenameColumn(
                name: "lstModified",
                table: "Images",
                newName: "lst_modified");

            migrationBuilder.RenameColumn(
                name: "healthyPercentage",
                table: "Images",
                newName: "healthy_percent");

            migrationBuilder.RenameColumn(
                name: "fileName",
                table: "Images",
                newName: "file_name");

            migrationBuilder.RenameColumn(
                name: "dtCreated",
                table: "Images",
                newName: "dt_created");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "unhealthy_percent",
                table: "Sessions",
                newName: "unhealthyPercentage");

            migrationBuilder.RenameColumn(
                name: "session_name",
                table: "Sessions",
                newName: "sessionName");

            migrationBuilder.RenameColumn(
                name: "lst_modified",
                table: "Sessions",
                newName: "lstModified");

            migrationBuilder.RenameColumn(
                name: "healthy_percent",
                table: "Sessions",
                newName: "healthyPercentage");

            migrationBuilder.RenameColumn(
                name: "dt_created",
                table: "Sessions",
                newName: "dtCreated");

            migrationBuilder.RenameColumn(
                name: "unhealthy_percent",
                table: "Images",
                newName: "unhealthyPercentage");

            migrationBuilder.RenameColumn(
                name: "lst_modified",
                table: "Images",
                newName: "lstModified");

            migrationBuilder.RenameColumn(
                name: "healthy_percent",
                table: "Images",
                newName: "healthyPercentage");

            migrationBuilder.RenameColumn(
                name: "file_name",
                table: "Images",
                newName: "fileName");

            migrationBuilder.RenameColumn(
                name: "dt_created",
                table: "Images",
                newName: "dtCreated");
        }
    }
}