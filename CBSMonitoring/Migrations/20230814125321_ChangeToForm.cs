using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AgreedWithAuthBody",
                table: "OrgMonitorings",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "FileModels",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgreedWithAuthBody",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "FileModels");
        }
    }
}
