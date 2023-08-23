using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class AddForm1_5_3ToMonitoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfEmplFamWithAgreements",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "PercentageOfEmpFamWithAgreements",
                table: "OrgMonitorings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfEmplFamWithAgreements",
                table: "OrgMonitorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PercentageOfEmpFamWithAgreements",
                table: "OrgMonitorings",
                type: "real",
                nullable: true);
        }
    }
}
