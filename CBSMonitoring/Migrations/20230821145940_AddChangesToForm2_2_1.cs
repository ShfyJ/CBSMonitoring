using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class AddChangesToForm2_2_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime[]>(
                name: "DeadlineOfPlan",
                table: "OrgMonitorings",
                type: "timestamp with time zone[]",
                nullable: true);

            migrationBuilder.AddColumn<bool[]>(
                name: "DeadlineOfRealExec",
                table: "OrgMonitorings",
                type: "boolean[]",
                nullable: true);

            migrationBuilder.AddColumn<int[]>(
                name: "File_2_2_1Ids",
                table: "OrgMonitorings",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<bool[]>(
                name: "IsExecuted",
                table: "OrgMonitorings",
                type: "boolean[]",
                nullable: true);

            migrationBuilder.AddColumn<int[]>(
                name: "SectNumber",
                table: "OrgMonitorings",
                type: "integer[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeadlineOfPlan",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "DeadlineOfRealExec",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "File_2_2_1Ids",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "IsExecuted",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "SectNumber",
                table: "OrgMonitorings");
        }
    }
}
