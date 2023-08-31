using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTableTimelyExecutionToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "OrgMonitoringId",
                table: "QIEmployees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "File_2_2_1Id",
                table: "OrgMonitorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDoneSects",
                table: "OrgMonitorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDoneSectsInTime",
                table: "OrgMonitorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSectsInActionPlan",
                table: "OrgMonitorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequired",
                table: "FormItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "timelyExecutionOfPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SectNameWithNumber = table.Column<string>(type: "text", nullable: true),
                    Doers = table.Column<string>(type: "text", nullable: true),
                    DeadlineOfPlan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    OrgMonitoringId = table.Column<int>(type: "integer", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    Form2_2_2MonitoringId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timelyExecutionOfPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_timelyExecutionOfPlans_OrgMonitorings_Form2_2_2MonitoringId",
                        column: x => x.Form2_2_2MonitoringId,
                        principalTable: "OrgMonitorings",
                        principalColumn: "MonitoringId");
                    table.ForeignKey(
                        name: "FK_timelyExecutionOfPlans_OrgMonitorings_OrgMonitoringId",
                        column: x => x.OrgMonitoringId,
                        principalTable: "OrgMonitorings",
                        principalColumn: "MonitoringId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QIEmployees_OrgMonitoringId",
                table: "QIEmployees",
                column: "OrgMonitoringId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitorings_File_2_2_1Id",
                table: "OrgMonitorings",
                column: "File_2_2_1Id");

            migrationBuilder.CreateIndex(
                name: "IX_timelyExecutionOfPlans_Form2_2_2MonitoringId",
                table: "timelyExecutionOfPlans",
                column: "Form2_2_2MonitoringId");

            migrationBuilder.CreateIndex(
                name: "IX_timelyExecutionOfPlans_OrgMonitoringId",
                table: "timelyExecutionOfPlans",
                column: "OrgMonitoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgMonitorings_FileModels_File_2_2_1Id",
                table: "OrgMonitorings",
                column: "File_2_2_1Id",
                principalTable: "FileModels",
                principalColumn: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_QIEmployees_OrgMonitorings_OrgMonitoringId",
                table: "QIEmployees",
                column: "OrgMonitoringId",
                principalTable: "OrgMonitorings",
                principalColumn: "MonitoringId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitorings_FileModels_File_2_2_1Id",
                table: "OrgMonitorings");

            migrationBuilder.DropForeignKey(
                name: "FK_QIEmployees_OrgMonitorings_OrgMonitoringId",
                table: "QIEmployees");

            migrationBuilder.DropTable(
                name: "timelyExecutionOfPlans");

            migrationBuilder.DropIndex(
                name: "IX_QIEmployees_OrgMonitoringId",
                table: "QIEmployees");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitorings_File_2_2_1Id",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "OrgMonitoringId",
                table: "QIEmployees");

            migrationBuilder.DropColumn(
                name: "File_2_2_1Id",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "NumberOfDoneSects",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "NumberOfDoneSectsInTime",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "NumberOfSectsInActionPlan",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "IsRequired",
                table: "FormItems");

            migrationBuilder.AddColumn<DateTime[]>(
                name: "DeadlineOfPlan",
                table: "OrgMonitorings",
                type: "timestamp without time zone[]",
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
    }
}
