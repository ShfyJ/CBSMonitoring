using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class AddPropsToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CAToolType",
                table: "OrgMonitorings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirewallType",
                table: "OrgMonitorings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IDPSType",
                table: "OrgMonitorings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProtectionToolType",
                table: "OrgMonitorings",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CAToolType",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "FirewallType",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "IDPSType",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "ProtectionToolType",
                table: "OrgMonitorings");
        }
    }
}
