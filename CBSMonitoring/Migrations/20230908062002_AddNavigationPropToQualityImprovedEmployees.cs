using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class AddNavigationPropToQualityImprovedEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QIEmployees_OrgMonitoringReports_Form2_8_1MonitoringId",
                table: "QIEmployees");

            migrationBuilder.DropIndex(
                name: "IX_QIEmployees_Form2_8_1MonitoringId",
                table: "QIEmployees");

            migrationBuilder.DropColumn(
                name: "Form2_8_1MonitoringId",
                table: "QIEmployees");

            migrationBuilder.DropColumn(
                name: "QualifImpEmpIds",
                table: "OrgMonitoringReports");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Form2_8_1MonitoringId",
                table: "QIEmployees",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int[]>(
                name: "QualifImpEmpIds",
                table: "OrgMonitoringReports",
                type: "integer[]",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QIEmployees_Form2_8_1MonitoringId",
                table: "QIEmployees",
                column: "Form2_8_1MonitoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_QIEmployees_OrgMonitoringReports_Form2_8_1MonitoringId",
                table: "QIEmployees",
                column: "Form2_8_1MonitoringId",
                principalTable: "OrgMonitoringReports",
                principalColumn: "MonitoringId");
        }
    }
}
