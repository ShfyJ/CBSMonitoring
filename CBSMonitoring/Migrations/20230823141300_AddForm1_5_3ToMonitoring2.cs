using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class AddForm1_5_3ToMonitoring2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEmployeesFamWithAgreements",
                table: "OrgMonitorings",
                type: "boolean",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEmployeesFamWithAgreements",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "NumberOfEmplFamWithAgreements",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "PercentageOfEmpFamWithAgreements",
                table: "OrgMonitorings");
        }
    }
}
