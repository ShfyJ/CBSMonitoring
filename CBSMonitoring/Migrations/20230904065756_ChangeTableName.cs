using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitorings_FileModels_File_1_1_1Id",
                table: "OrgMonitorings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitorings_FileModels_File_1_1_2Id",
                table: "OrgMonitorings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitorings_FileModels_File_1_1_3Id",
                table: "OrgMonitorings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitorings_FileModels_File_2_1_1Id",
                table: "OrgMonitorings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitorings_FileModels_File_2_2_1Id",
                table: "OrgMonitorings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitorings_FileModels_File_2_3_1Id",
                table: "OrgMonitorings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitorings_FileModels_File_2_3_2Id",
                table: "OrgMonitorings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitorings_Organizations_OrganizationId",
                table: "OrgMonitorings");

            migrationBuilder.DropForeignKey(
                name: "FK_QIEmployees_OrgMonitorings_Form2_8_1MonitoringId",
                table: "QIEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_QIEmployees_OrgMonitorings_OrgMonitoringId",
                table: "QIEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_timelyExecutionOfPlans_OrgMonitorings_Form2_2_2MonitoringId",
                table: "timelyExecutionOfPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_timelyExecutionOfPlans_OrgMonitorings_OrgMonitoringId",
                table: "timelyExecutionOfPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_timelyExecutionOfPlans",
                table: "timelyExecutionOfPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrgMonitorings",
                table: "OrgMonitorings");

            migrationBuilder.RenameTable(
                name: "timelyExecutionOfPlans",
                newName: "TimelyExecutionOfPlans");

            migrationBuilder.RenameTable(
                name: "OrgMonitorings",
                newName: "OrgMonitoringReports");

            migrationBuilder.RenameIndex(
                name: "IX_timelyExecutionOfPlans_OrgMonitoringId",
                table: "TimelyExecutionOfPlans",
                newName: "IX_TimelyExecutionOfPlans_OrgMonitoringId");

            migrationBuilder.RenameIndex(
                name: "IX_timelyExecutionOfPlans_Form2_2_2MonitoringId",
                table: "TimelyExecutionOfPlans",
                newName: "IX_TimelyExecutionOfPlans_Form2_2_2MonitoringId");

            migrationBuilder.RenameIndex(
                name: "IX_OrgMonitorings_OrganizationId",
                table: "OrgMonitoringReports",
                newName: "IX_OrgMonitoringReports_OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_OrgMonitorings_File_2_3_2Id",
                table: "OrgMonitoringReports",
                newName: "IX_OrgMonitoringReports_File_2_3_2Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrgMonitorings_File_2_3_1Id",
                table: "OrgMonitoringReports",
                newName: "IX_OrgMonitoringReports_File_2_3_1Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrgMonitorings_File_2_2_1Id",
                table: "OrgMonitoringReports",
                newName: "IX_OrgMonitoringReports_File_2_2_1Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrgMonitorings_File_2_1_1Id",
                table: "OrgMonitoringReports",
                newName: "IX_OrgMonitoringReports_File_2_1_1Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrgMonitorings_File_1_1_3Id",
                table: "OrgMonitoringReports",
                newName: "IX_OrgMonitoringReports_File_1_1_3Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrgMonitorings_File_1_1_2Id",
                table: "OrgMonitoringReports",
                newName: "IX_OrgMonitoringReports_File_1_1_2Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrgMonitorings_File_1_1_1Id",
                table: "OrgMonitoringReports",
                newName: "IX_OrgMonitoringReports_File_1_1_1Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimelyExecutionOfPlans",
                table: "TimelyExecutionOfPlans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrgMonitoringReports",
                table: "OrgMonitoringReports",
                column: "MonitoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgMonitoringReports_FileModels_File_1_1_1Id",
                table: "OrgMonitoringReports",
                column: "File_1_1_1Id",
                principalTable: "FileModels",
                principalColumn: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgMonitoringReports_FileModels_File_1_1_2Id",
                table: "OrgMonitoringReports",
                column: "File_1_1_2Id",
                principalTable: "FileModels",
                principalColumn: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgMonitoringReports_FileModels_File_1_1_3Id",
                table: "OrgMonitoringReports",
                column: "File_1_1_3Id",
                principalTable: "FileModels",
                principalColumn: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgMonitoringReports_FileModels_File_2_1_1Id",
                table: "OrgMonitoringReports",
                column: "File_2_1_1Id",
                principalTable: "FileModels",
                principalColumn: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgMonitoringReports_FileModels_File_2_2_1Id",
                table: "OrgMonitoringReports",
                column: "File_2_2_1Id",
                principalTable: "FileModels",
                principalColumn: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgMonitoringReports_FileModels_File_2_3_1Id",
                table: "OrgMonitoringReports",
                column: "File_2_3_1Id",
                principalTable: "FileModels",
                principalColumn: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgMonitoringReports_FileModels_File_2_3_2Id",
                table: "OrgMonitoringReports",
                column: "File_2_3_2Id",
                principalTable: "FileModels",
                principalColumn: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgMonitoringReports_Organizations_OrganizationId",
                table: "OrgMonitoringReports",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QIEmployees_OrgMonitoringReports_Form2_8_1MonitoringId",
                table: "QIEmployees",
                column: "Form2_8_1MonitoringId",
                principalTable: "OrgMonitoringReports",
                principalColumn: "MonitoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_QIEmployees_OrgMonitoringReports_OrgMonitoringId",
                table: "QIEmployees",
                column: "OrgMonitoringId",
                principalTable: "OrgMonitoringReports",
                principalColumn: "MonitoringId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimelyExecutionOfPlans_OrgMonitoringReports_Form2_2_2Monito~",
                table: "TimelyExecutionOfPlans",
                column: "Form2_2_2MonitoringId",
                principalTable: "OrgMonitoringReports",
                principalColumn: "MonitoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimelyExecutionOfPlans_OrgMonitoringReports_OrgMonitoringId",
                table: "TimelyExecutionOfPlans",
                column: "OrgMonitoringId",
                principalTable: "OrgMonitoringReports",
                principalColumn: "MonitoringId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitoringReports_FileModels_File_1_1_1Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitoringReports_FileModels_File_1_1_2Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitoringReports_FileModels_File_1_1_3Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitoringReports_FileModels_File_2_1_1Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitoringReports_FileModels_File_2_2_1Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitoringReports_FileModels_File_2_3_1Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitoringReports_FileModels_File_2_3_2Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitoringReports_Organizations_OrganizationId",
                table: "OrgMonitoringReports");

            migrationBuilder.DropForeignKey(
                name: "FK_QIEmployees_OrgMonitoringReports_Form2_8_1MonitoringId",
                table: "QIEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_QIEmployees_OrgMonitoringReports_OrgMonitoringId",
                table: "QIEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_TimelyExecutionOfPlans_OrgMonitoringReports_Form2_2_2Monito~",
                table: "TimelyExecutionOfPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_TimelyExecutionOfPlans_OrgMonitoringReports_OrgMonitoringId",
                table: "TimelyExecutionOfPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimelyExecutionOfPlans",
                table: "TimelyExecutionOfPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrgMonitoringReports",
                table: "OrgMonitoringReports");

            migrationBuilder.RenameTable(
                name: "TimelyExecutionOfPlans",
                newName: "timelyExecutionOfPlans");

            migrationBuilder.RenameTable(
                name: "OrgMonitoringReports",
                newName: "OrgMonitorings");

            migrationBuilder.RenameIndex(
                name: "IX_TimelyExecutionOfPlans_OrgMonitoringId",
                table: "timelyExecutionOfPlans",
                newName: "IX_timelyExecutionOfPlans_OrgMonitoringId");

            migrationBuilder.RenameIndex(
                name: "IX_TimelyExecutionOfPlans_Form2_2_2MonitoringId",
                table: "timelyExecutionOfPlans",
                newName: "IX_timelyExecutionOfPlans_Form2_2_2MonitoringId");

            migrationBuilder.RenameIndex(
                name: "IX_OrgMonitoringReports_OrganizationId",
                table: "OrgMonitorings",
                newName: "IX_OrgMonitorings_OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_OrgMonitoringReports_File_2_3_2Id",
                table: "OrgMonitorings",
                newName: "IX_OrgMonitorings_File_2_3_2Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrgMonitoringReports_File_2_3_1Id",
                table: "OrgMonitorings",
                newName: "IX_OrgMonitorings_File_2_3_1Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrgMonitoringReports_File_2_2_1Id",
                table: "OrgMonitorings",
                newName: "IX_OrgMonitorings_File_2_2_1Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrgMonitoringReports_File_2_1_1Id",
                table: "OrgMonitorings",
                newName: "IX_OrgMonitorings_File_2_1_1Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrgMonitoringReports_File_1_1_3Id",
                table: "OrgMonitorings",
                newName: "IX_OrgMonitorings_File_1_1_3Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrgMonitoringReports_File_1_1_2Id",
                table: "OrgMonitorings",
                newName: "IX_OrgMonitorings_File_1_1_2Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrgMonitoringReports_File_1_1_1Id",
                table: "OrgMonitorings",
                newName: "IX_OrgMonitorings_File_1_1_1Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_timelyExecutionOfPlans",
                table: "timelyExecutionOfPlans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrgMonitorings",
                table: "OrgMonitorings",
                column: "MonitoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgMonitorings_FileModels_File_1_1_1Id",
                table: "OrgMonitorings",
                column: "File_1_1_1Id",
                principalTable: "FileModels",
                principalColumn: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgMonitorings_FileModels_File_1_1_2Id",
                table: "OrgMonitorings",
                column: "File_1_1_2Id",
                principalTable: "FileModels",
                principalColumn: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgMonitorings_FileModels_File_1_1_3Id",
                table: "OrgMonitorings",
                column: "File_1_1_3Id",
                principalTable: "FileModels",
                principalColumn: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgMonitorings_FileModels_File_2_1_1Id",
                table: "OrgMonitorings",
                column: "File_2_1_1Id",
                principalTable: "FileModels",
                principalColumn: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgMonitorings_FileModels_File_2_2_1Id",
                table: "OrgMonitorings",
                column: "File_2_2_1Id",
                principalTable: "FileModels",
                principalColumn: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgMonitorings_FileModels_File_2_3_1Id",
                table: "OrgMonitorings",
                column: "File_2_3_1Id",
                principalTable: "FileModels",
                principalColumn: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgMonitorings_FileModels_File_2_3_2Id",
                table: "OrgMonitorings",
                column: "File_2_3_2Id",
                principalTable: "FileModels",
                principalColumn: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgMonitorings_Organizations_OrganizationId",
                table: "OrgMonitorings",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QIEmployees_OrgMonitorings_Form2_8_1MonitoringId",
                table: "QIEmployees",
                column: "Form2_8_1MonitoringId",
                principalTable: "OrgMonitorings",
                principalColumn: "MonitoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_QIEmployees_OrgMonitorings_OrgMonitoringId",
                table: "QIEmployees",
                column: "OrgMonitoringId",
                principalTable: "OrgMonitorings",
                principalColumn: "MonitoringId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_timelyExecutionOfPlans_OrgMonitorings_Form2_2_2MonitoringId",
                table: "timelyExecutionOfPlans",
                column: "Form2_2_2MonitoringId",
                principalTable: "OrgMonitorings",
                principalColumn: "MonitoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_timelyExecutionOfPlans_OrgMonitorings_OrgMonitoringId",
                table: "timelyExecutionOfPlans",
                column: "OrgMonitoringId",
                principalTable: "OrgMonitorings",
                principalColumn: "MonitoringId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
