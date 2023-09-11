using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFileModelTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QIEmployees_CertificateFileId",
                table: "QIEmployees");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitoringReports_File_1_1_1Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitoringReports_File_1_1_2Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitoringReports_File_1_1_3Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitoringReports_File_2_1_1Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitoringReports_File_2_2_1Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitoringReports_File_2_3_1Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitoringReports_File_2_3_2Id",
                table: "OrgMonitoringReports");

            migrationBuilder.AddColumn<int>(
                name: "File_2_1_2Id",
                table: "OrgMonitoringReports",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActionPlanAgreedToEnsIC",
                table: "OrgMonitoringReports",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForAbsenceOfAgreement",
                table: "OrgMonitoringReports",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Form2_2_2Id",
                table: "FileModels",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QIEmployees_CertificateFileId",
                table: "QIEmployees",
                column: "CertificateFileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitoringReports_File_1_1_1Id",
                table: "OrgMonitoringReports",
                column: "File_1_1_1Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitoringReports_File_1_1_2Id",
                table: "OrgMonitoringReports",
                column: "File_1_1_2Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitoringReports_File_1_1_3Id",
                table: "OrgMonitoringReports",
                column: "File_1_1_3Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitoringReports_File_2_1_1Id",
                table: "OrgMonitoringReports",
                column: "File_2_1_1Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitoringReports_File_2_1_2Id",
                table: "OrgMonitoringReports",
                column: "File_2_1_2Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitoringReports_File_2_2_1Id",
                table: "OrgMonitoringReports",
                column: "File_2_2_1Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitoringReports_File_2_3_1Id",
                table: "OrgMonitoringReports",
                column: "File_2_3_1Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitoringReports_File_2_3_2Id",
                table: "OrgMonitoringReports",
                column: "File_2_3_2Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileModels_Form2_2_2Id",
                table: "FileModels",
                column: "Form2_2_2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FileModels_OrgMonitoringReports_Form2_2_2Id",
                table: "FileModels",
                column: "Form2_2_2Id",
                principalTable: "OrgMonitoringReports",
                principalColumn: "MonitoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgMonitoringReports_FileModels_File_2_1_2Id",
                table: "OrgMonitoringReports",
                column: "File_2_1_2Id",
                principalTable: "FileModels",
                principalColumn: "FileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileModels_OrgMonitoringReports_Form2_2_2Id",
                table: "FileModels");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitoringReports_FileModels_File_2_1_2Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropIndex(
                name: "IX_QIEmployees_CertificateFileId",
                table: "QIEmployees");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitoringReports_File_1_1_1Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitoringReports_File_1_1_2Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitoringReports_File_1_1_3Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitoringReports_File_2_1_1Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitoringReports_File_2_1_2Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitoringReports_File_2_2_1Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitoringReports_File_2_3_1Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitoringReports_File_2_3_2Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropIndex(
                name: "IX_FileModels_Form2_2_2Id",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "File_2_1_2Id",
                table: "OrgMonitoringReports");

            migrationBuilder.DropColumn(
                name: "IsActionPlanAgreedToEnsIC",
                table: "OrgMonitoringReports");

            migrationBuilder.DropColumn(
                name: "ReasonForAbsenceOfAgreement",
                table: "OrgMonitoringReports");

            migrationBuilder.DropColumn(
                name: "Form2_2_2Id",
                table: "FileModels");

            migrationBuilder.CreateIndex(
                name: "IX_QIEmployees_CertificateFileId",
                table: "QIEmployees",
                column: "CertificateFileId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitoringReports_File_1_1_1Id",
                table: "OrgMonitoringReports",
                column: "File_1_1_1Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitoringReports_File_1_1_2Id",
                table: "OrgMonitoringReports",
                column: "File_1_1_2Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitoringReports_File_1_1_3Id",
                table: "OrgMonitoringReports",
                column: "File_1_1_3Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitoringReports_File_2_1_1Id",
                table: "OrgMonitoringReports",
                column: "File_2_1_1Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitoringReports_File_2_2_1Id",
                table: "OrgMonitoringReports",
                column: "File_2_2_1Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitoringReports_File_2_3_1Id",
                table: "OrgMonitoringReports",
                column: "File_2_3_1Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitoringReports_File_2_3_2Id",
                table: "OrgMonitoringReports",
                column: "File_2_3_2Id");
        }
    }
}
