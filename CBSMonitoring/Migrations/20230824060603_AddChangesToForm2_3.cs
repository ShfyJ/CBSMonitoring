using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class AddChangesToForm2_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NamesOfISystems",
                table: "OrgMonitorings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamesOfSystemResources",
                table: "OrgMonitorings",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NamesOfISystems",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "NamesOfSystemResources",
                table: "OrgMonitorings");
        }
    }
}
