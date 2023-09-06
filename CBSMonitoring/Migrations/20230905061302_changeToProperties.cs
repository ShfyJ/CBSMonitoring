using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class changeToProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsObjectsClasified",
                table: "OrgMonitoringReports",
                newName: "IsObjectsClassified");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsObjectsClassified",
                table: "OrgMonitoringReports",
                newName: "IsObjectsClasified");
        }
    }
}
