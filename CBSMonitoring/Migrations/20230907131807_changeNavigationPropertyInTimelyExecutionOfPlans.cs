using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class changeNavigationPropertyInTimelyExecutionOfPlans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimelyExecutionOfPlans_OrgMonitoringReports_Form2_2_2Monito~",
                table: "TimelyExecutionOfPlans");

            migrationBuilder.DropIndex(
                name: "IX_TimelyExecutionOfPlans_Form2_2_2MonitoringId",
                table: "TimelyExecutionOfPlans");

            migrationBuilder.DropColumn(
                name: "Form2_2_2MonitoringId",
                table: "TimelyExecutionOfPlans");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Form2_2_2MonitoringId",
                table: "TimelyExecutionOfPlans",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimelyExecutionOfPlans_Form2_2_2MonitoringId",
                table: "TimelyExecutionOfPlans",
                column: "Form2_2_2MonitoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimelyExecutionOfPlans_OrgMonitoringReports_Form2_2_2Monito~",
                table: "TimelyExecutionOfPlans",
                column: "Form2_2_2MonitoringId",
                principalTable: "OrgMonitoringReports",
                principalColumn: "MonitoringId");
        }
    }
}
