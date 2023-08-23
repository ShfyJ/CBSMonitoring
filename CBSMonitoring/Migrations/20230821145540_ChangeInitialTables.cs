using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInitialTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileModels_OrgMonitorings_Form1_1MonitoringId",
                table: "FileModels");

            migrationBuilder.DropForeignKey(
                name: "FK_FileModels_OrgMonitorings_Form2_1MonitoringId",
                table: "FileModels");

            migrationBuilder.DropForeignKey(
                name: "FK_FileModels_OrgMonitorings_Form2_2MonitoringId",
                table: "FileModels");

            migrationBuilder.DropForeignKey(
                name: "FK_FileModels_OrgMonitorings_Form2_3MonitoringId",
                table: "FileModels");

            migrationBuilder.DropForeignKey(
                name: "FK_FileModels_OrgMonitorings_Form2_4MonitoringId",
                table: "FileModels");

            migrationBuilder.DropForeignKey(
                name: "FK_FormItems_MonitoringForms_FormId",
                table: "FormItems");

            migrationBuilder.DropForeignKey(
                name: "FK_QIEmployees_OrgMonitorings_Form2_8MonitoringId",
                table: "QIEmployees");

            migrationBuilder.DropTable(
                name: "MonitoringForms");

            migrationBuilder.DropIndex(
                name: "IX_FileModels_Form1_1MonitoringId",
                table: "FileModels");

            migrationBuilder.DropIndex(
                name: "IX_FileModels_Form2_1MonitoringId",
                table: "FileModels");

            migrationBuilder.DropIndex(
                name: "IX_FileModels_Form2_2MonitoringId",
                table: "FileModels");

            migrationBuilder.DropIndex(
                name: "IX_FileModels_Form2_3MonitoringId",
                table: "FileModels");

            migrationBuilder.DropIndex(
                name: "IX_FileModels_Form2_4MonitoringId",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "DeadlineOfPlan",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "FrequencyOfPasswUpdateInWRooms",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "LinkedItemId",
                table: "FormItems");

            migrationBuilder.DropColumn(
                name: "ListIndex",
                table: "FormItems");

            migrationBuilder.DropColumn(
                name: "Form1_1MonitoringId",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "Form2_1MonitoringId",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "Form2_2MonitoringId",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "Form2_3MonitoringId",
                table: "FileModels");

            migrationBuilder.DropColumn(
                name: "Form2_4MonitoringId",
                table: "FileModels");

            migrationBuilder.RenameColumn(
                name: "Form2_8MonitoringId",
                table: "QIEmployees",
                newName: "Form2_8_1MonitoringId");

            migrationBuilder.RenameIndex(
                name: "IX_QIEmployees_Form2_8MonitoringId",
                table: "QIEmployees",
                newName: "IX_QIEmployees_Form2_8_1MonitoringId");

            migrationBuilder.RenameColumn(
                name: "WorkRoomsWithUPS",
                table: "OrgMonitorings",
                newName: "NumberOfWStWithSealedOuterCases");

            migrationBuilder.RenameColumn(
                name: "SectNumber",
                table: "OrgMonitorings",
                newName: "NumberOfWRsWithUPS");

            migrationBuilder.RenameColumn(
                name: "ReasonForAbsenceOfAgreement",
                table: "OrgMonitorings",
                newName: "NameOfToolsForACInStrucDiv");

            migrationBuilder.RenameColumn(
                name: "PresenceOfGasFireExtSystInRoomWithSEq",
                table: "OrgMonitorings",
                newName: "IsVideoCamAvailable");

            migrationBuilder.RenameColumn(
                name: "NumberOfWorkStWithSealedOuterCases",
                table: "OrgMonitorings",
                newName: "NumberOfWRsWithPasswProtection");

            migrationBuilder.RenameColumn(
                name: "NumberOfWRoomsWithPasswProtection",
                table: "OrgMonitorings",
                newName: "NumberOfWRsWithAntivirus");

            migrationBuilder.RenameColumn(
                name: "NumberOfWRoomsWithAntiM",
                table: "OrgMonitorings",
                newName: "NumberOfServersWithAntivirus");

            migrationBuilder.RenameColumn(
                name: "NumberOfServersWithAntiM",
                table: "OrgMonitorings",
                newName: "NumberOfSRsWithPasswProtection");

            migrationBuilder.RenameColumn(
                name: "NumberOfSRoomsWithPasswProtection",
                table: "OrgMonitorings",
                newName: "NumberOfRegAndRecords");

            migrationBuilder.RenameColumn(
                name: "NumberOfRegJournal",
                table: "OrgMonitorings",
                newName: "NumOfOrgsWithACToNetInStrucDiv");

            migrationBuilder.RenameColumn(
                name: "NumberOfOrgsWithAccesControlToNetwork",
                table: "OrgMonitorings",
                newName: "File_2_3_2Id");

            migrationBuilder.RenameColumn(
                name: "NameOfToolsForAccessControl",
                table: "OrgMonitorings",
                newName: "NameOfToolForACInCentre");

            migrationBuilder.RenameColumn(
                name: "NameOfToolForAccessControlInCentre",
                table: "OrgMonitorings",
                newName: "NameAndVersionOfAntivirus");

            migrationBuilder.RenameColumn(
                name: "NameAndVersionOfAntimalwareProgram",
                table: "OrgMonitorings",
                newName: "ListOfRegAndRecords");

            migrationBuilder.RenameColumn(
                name: "ListOfRegJournal",
                table: "OrgMonitorings",
                newName: "FrequncyOfPasswUpdateInSRs");

            migrationBuilder.RenameColumn(
                name: "IsUPSAvailableForWRooms",
                table: "OrgMonitorings",
                newName: "IsUPSForSEqAvailable");

            migrationBuilder.RenameColumn(
                name: "IsServerRoomAvailable",
                table: "OrgMonitorings",
                newName: "IsUPSAvailableForWRs");

            migrationBuilder.RenameColumn(
                name: "IsResponsiblePersonAssigned",
                table: "OrgMonitorings",
                newName: "IsTempSensorsAvailable");

            migrationBuilder.RenameColumn(
                name: "IsPasswProtectInWRooms",
                table: "OrgMonitorings",
                newName: "IsServerRoomOrDataCenterAvailable");

            migrationBuilder.RenameColumn(
                name: "IsPasswProtectInSRooms",
                table: "OrgMonitorings",
                newName: "IsSecAlarmsInCentreAvailable");

            migrationBuilder.RenameColumn(
                name: "IsListCommToEmps",
                table: "OrgMonitorings",
                newName: "IsSealedOuterCaseAvailable");

            migrationBuilder.RenameColumn(
                name: "IsListAvailable",
                table: "OrgMonitorings",
                newName: "IsSIEMAvailable");

            migrationBuilder.RenameColumn(
                name: "IsLicenseForAntiMAvailable",
                table: "OrgMonitorings",
                newName: "IsResponsiblePersonForISAssigned");

            migrationBuilder.RenameColumn(
                name: "IsExecuted",
                table: "OrgMonitorings",
                newName: "IsProtectionToolAvailable");

            migrationBuilder.RenameColumn(
                name: "IsDataCentreAvailable",
                table: "OrgMonitorings",
                newName: "IsPasswProtectInWRsAvailable");

            migrationBuilder.RenameColumn(
                name: "IsAgreementsAvailable",
                table: "OrgMonitorings",
                newName: "IsPasswProtectInSRsAvailable");

            migrationBuilder.RenameColumn(
                name: "IsActionPlanAgreedToEnsIC",
                table: "OrgMonitorings",
                newName: "IsLogsForSRAndDCEntrance");

            migrationBuilder.RenameColumn(
                name: "IsAccessControlToNetworkInStrucDivAvailable",
                table: "OrgMonitorings",
                newName: "IsListOfConfInfoProvidedToEmps");

            migrationBuilder.RenameColumn(
                name: "IsAccessControlToNetworkInCentreAvailable",
                table: "OrgMonitorings",
                newName: "IsListOfConfInfoAvailable");

            migrationBuilder.RenameColumn(
                name: "FrequncyOfPasswUpdateInSRooms",
                table: "OrgMonitorings",
                newName: "FrequencyOfPasswUpdateInWRs");

            migrationBuilder.RenameColumn(
                name: "DeadlineOfRealExec",
                table: "OrgMonitorings",
                newName: "IsLicenseForAntivirusAvailable");

            migrationBuilder.RenameColumn(
                name: "AvailablityOfUPSForSEq",
                table: "OrgMonitorings",
                newName: "IsIDPSAvailable");

            migrationBuilder.RenameColumn(
                name: "AvailablityOfTempSensors",
                table: "OrgMonitorings",
                newName: "IsGeneratorsAvailable");

            migrationBuilder.RenameColumn(
                name: "AvailablityOfLogsForServerRoomEntrance",
                table: "OrgMonitorings",
                newName: "IsGasFireExtSystAvailable");

            migrationBuilder.RenameColumn(
                name: "AvailablityOfGenerators",
                table: "OrgMonitorings",
                newName: "IsFirewallAvailable");

            migrationBuilder.RenameColumn(
                name: "AvailablityOfFalseFloorAndCeiling",
                table: "OrgMonitorings",
                newName: "IsFireAlarmSystAvailable");

            migrationBuilder.RenameColumn(
                name: "AvailablityOfAlternativePowerL",
                table: "OrgMonitorings",
                newName: "IsFalseFloorAndCeilingAvailable");

            migrationBuilder.RenameColumn(
                name: "AvailabilityOfVideoCamInServerRoom",
                table: "OrgMonitorings",
                newName: "IsEmpsQualificationImproved");

            migrationBuilder.RenameColumn(
                name: "AvailabilityOfSecAlarmsInCentre",
                table: "OrgMonitorings",
                newName: "IsDLPAvailable");

            migrationBuilder.RenameColumn(
                name: "AvailabilityOfFireAlarmSystInRoomWithSEq",
                table: "OrgMonitorings",
                newName: "IsCAndAnalysisToolAvailable");

            migrationBuilder.RenameColumn(
                name: "FormId",
                table: "FormItems",
                newName: "FormSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_FormItems_FormId",
                table: "FormItems",
                newName: "IX_FormItems_FormSectionId");

            migrationBuilder.AddColumn<bool>(
                name: "AreEmpsFamiliarWithISP",
                table: "OrgMonitorings",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AreInternalRegulationsAvailable",
                table: "OrgMonitorings",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AreRegsAndRecordsAvailable",
                table: "OrgMonitorings",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "File_1_1_1Id",
                table: "OrgMonitorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "File_1_1_2Id",
                table: "OrgMonitorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "File_1_1_3Id",
                table: "OrgMonitorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "File_2_1_1Id",
                table: "OrgMonitorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "File_2_3_1Id",
                table: "OrgMonitorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsACToNetInCentreAvailable",
                table: "OrgMonitorings",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsACToNetInStrucDivAvailable",
                table: "OrgMonitorings",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAgreementOnPrivacyAvailable",
                table: "OrgMonitorings",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAlternativePowerLAvailable",
                table: "OrgMonitorings",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAnitivirusAvailable",
                table: "OrgMonitorings",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "FormItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "QuestionBlocks",
                columns: table => new
                {
                    BlockId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BlockNumber = table.Column<string>(type: "text", nullable: false),
                    BlockName = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionBlocks", x => x.BlockId);
                });

            migrationBuilder.CreateTable(
                name: "FormSections",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    SectionName = table.Column<string>(type: "text", nullable: false),
                    SectionNumber = table.Column<string>(type: "text", nullable: false),
                    QuestionBlockId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormSections", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_FormSections_QuestionBlocks_QuestionBlockId",
                        column: x => x.QuestionBlockId,
                        principalTable: "QuestionBlocks",
                        principalColumn: "BlockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitorings_File_1_1_1Id",
                table: "OrgMonitorings",
                column: "File_1_1_1Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitorings_File_1_1_2Id",
                table: "OrgMonitorings",
                column: "File_1_1_2Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitorings_File_1_1_3Id",
                table: "OrgMonitorings",
                column: "File_1_1_3Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitorings_File_2_1_1Id",
                table: "OrgMonitorings",
                column: "File_2_1_1Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitorings_File_2_3_1Id",
                table: "OrgMonitorings",
                column: "File_2_3_1Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitorings_File_2_3_2Id",
                table: "OrgMonitorings",
                column: "File_2_3_2Id");

            migrationBuilder.CreateIndex(
                name: "IX_FormSections_QuestionBlockId",
                table: "FormSections",
                column: "QuestionBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_FormSections_SectionNumber",
                table: "FormSections",
                column: "SectionNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBlocks_BlockNumber",
                table: "QuestionBlocks",
                column: "BlockNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FormItems_FormSections_FormSectionId",
                table: "FormItems",
                column: "FormSectionId",
                principalTable: "FormSections",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_QIEmployees_OrgMonitorings_Form2_8_1MonitoringId",
                table: "QIEmployees",
                column: "Form2_8_1MonitoringId",
                principalTable: "OrgMonitorings",
                principalColumn: "MonitoringId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormItems_FormSections_FormSectionId",
                table: "FormItems");

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
                name: "FK_OrgMonitorings_FileModels_File_2_3_1Id",
                table: "OrgMonitorings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgMonitorings_FileModels_File_2_3_2Id",
                table: "OrgMonitorings");

            migrationBuilder.DropForeignKey(
                name: "FK_QIEmployees_OrgMonitorings_Form2_8_1MonitoringId",
                table: "QIEmployees");

            migrationBuilder.DropTable(
                name: "FormSections");

            migrationBuilder.DropTable(
                name: "QuestionBlocks");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitorings_File_1_1_1Id",
                table: "OrgMonitorings");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitorings_File_1_1_2Id",
                table: "OrgMonitorings");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitorings_File_1_1_3Id",
                table: "OrgMonitorings");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitorings_File_2_1_1Id",
                table: "OrgMonitorings");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitorings_File_2_3_1Id",
                table: "OrgMonitorings");

            migrationBuilder.DropIndex(
                name: "IX_OrgMonitorings_File_2_3_2Id",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "AreEmpsFamiliarWithISP",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "AreInternalRegulationsAvailable",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "AreRegsAndRecordsAvailable",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "File_1_1_1Id",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "File_1_1_2Id",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "File_1_1_3Id",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "File_2_1_1Id",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "File_2_3_1Id",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "IsACToNetInCentreAvailable",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "IsACToNetInStrucDivAvailable",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "IsAgreementOnPrivacyAvailable",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "IsAlternativePowerLAvailable",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "IsAnitivirusAvailable",
                table: "OrgMonitorings");

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "FormItems");

            migrationBuilder.RenameColumn(
                name: "Form2_8_1MonitoringId",
                table: "QIEmployees",
                newName: "Form2_8MonitoringId");

            migrationBuilder.RenameIndex(
                name: "IX_QIEmployees_Form2_8_1MonitoringId",
                table: "QIEmployees",
                newName: "IX_QIEmployees_Form2_8MonitoringId");

            migrationBuilder.RenameColumn(
                name: "NumberOfWStWithSealedOuterCases",
                table: "OrgMonitorings",
                newName: "WorkRoomsWithUPS");

            migrationBuilder.RenameColumn(
                name: "NumberOfWRsWithUPS",
                table: "OrgMonitorings",
                newName: "SectNumber");

            migrationBuilder.RenameColumn(
                name: "NumberOfWRsWithPasswProtection",
                table: "OrgMonitorings",
                newName: "NumberOfWorkStWithSealedOuterCases");

            migrationBuilder.RenameColumn(
                name: "NumberOfWRsWithAntivirus",
                table: "OrgMonitorings",
                newName: "NumberOfWRoomsWithPasswProtection");

            migrationBuilder.RenameColumn(
                name: "NumberOfServersWithAntivirus",
                table: "OrgMonitorings",
                newName: "NumberOfWRoomsWithAntiM");

            migrationBuilder.RenameColumn(
                name: "NumberOfSRsWithPasswProtection",
                table: "OrgMonitorings",
                newName: "NumberOfServersWithAntiM");

            migrationBuilder.RenameColumn(
                name: "NumberOfRegAndRecords",
                table: "OrgMonitorings",
                newName: "NumberOfSRoomsWithPasswProtection");

            migrationBuilder.RenameColumn(
                name: "NumOfOrgsWithACToNetInStrucDiv",
                table: "OrgMonitorings",
                newName: "NumberOfRegJournal");

            migrationBuilder.RenameColumn(
                name: "NameOfToolsForACInStrucDiv",
                table: "OrgMonitorings",
                newName: "ReasonForAbsenceOfAgreement");

            migrationBuilder.RenameColumn(
                name: "NameOfToolForACInCentre",
                table: "OrgMonitorings",
                newName: "NameOfToolsForAccessControl");

            migrationBuilder.RenameColumn(
                name: "NameAndVersionOfAntivirus",
                table: "OrgMonitorings",
                newName: "NameOfToolForAccessControlInCentre");

            migrationBuilder.RenameColumn(
                name: "ListOfRegAndRecords",
                table: "OrgMonitorings",
                newName: "NameAndVersionOfAntimalwareProgram");

            migrationBuilder.RenameColumn(
                name: "IsVideoCamAvailable",
                table: "OrgMonitorings",
                newName: "PresenceOfGasFireExtSystInRoomWithSEq");

            migrationBuilder.RenameColumn(
                name: "IsUPSForSEqAvailable",
                table: "OrgMonitorings",
                newName: "IsUPSAvailableForWRooms");

            migrationBuilder.RenameColumn(
                name: "IsUPSAvailableForWRs",
                table: "OrgMonitorings",
                newName: "IsServerRoomAvailable");

            migrationBuilder.RenameColumn(
                name: "IsTempSensorsAvailable",
                table: "OrgMonitorings",
                newName: "IsResponsiblePersonAssigned");

            migrationBuilder.RenameColumn(
                name: "IsServerRoomOrDataCenterAvailable",
                table: "OrgMonitorings",
                newName: "IsPasswProtectInWRooms");

            migrationBuilder.RenameColumn(
                name: "IsSecAlarmsInCentreAvailable",
                table: "OrgMonitorings",
                newName: "IsPasswProtectInSRooms");

            migrationBuilder.RenameColumn(
                name: "IsSealedOuterCaseAvailable",
                table: "OrgMonitorings",
                newName: "IsListCommToEmps");

            migrationBuilder.RenameColumn(
                name: "IsSIEMAvailable",
                table: "OrgMonitorings",
                newName: "IsListAvailable");

            migrationBuilder.RenameColumn(
                name: "IsResponsiblePersonForISAssigned",
                table: "OrgMonitorings",
                newName: "IsLicenseForAntiMAvailable");

            migrationBuilder.RenameColumn(
                name: "IsProtectionToolAvailable",
                table: "OrgMonitorings",
                newName: "IsExecuted");

            migrationBuilder.RenameColumn(
                name: "IsPasswProtectInWRsAvailable",
                table: "OrgMonitorings",
                newName: "IsDataCentreAvailable");

            migrationBuilder.RenameColumn(
                name: "IsPasswProtectInSRsAvailable",
                table: "OrgMonitorings",
                newName: "IsAgreementsAvailable");

            migrationBuilder.RenameColumn(
                name: "IsLogsForSRAndDCEntrance",
                table: "OrgMonitorings",
                newName: "IsActionPlanAgreedToEnsIC");

            migrationBuilder.RenameColumn(
                name: "IsListOfConfInfoProvidedToEmps",
                table: "OrgMonitorings",
                newName: "IsAccessControlToNetworkInStrucDivAvailable");

            migrationBuilder.RenameColumn(
                name: "IsListOfConfInfoAvailable",
                table: "OrgMonitorings",
                newName: "IsAccessControlToNetworkInCentreAvailable");

            migrationBuilder.RenameColumn(
                name: "IsLicenseForAntivirusAvailable",
                table: "OrgMonitorings",
                newName: "DeadlineOfRealExec");

            migrationBuilder.RenameColumn(
                name: "IsIDPSAvailable",
                table: "OrgMonitorings",
                newName: "AvailablityOfUPSForSEq");

            migrationBuilder.RenameColumn(
                name: "IsGeneratorsAvailable",
                table: "OrgMonitorings",
                newName: "AvailablityOfTempSensors");

            migrationBuilder.RenameColumn(
                name: "IsGasFireExtSystAvailable",
                table: "OrgMonitorings",
                newName: "AvailablityOfLogsForServerRoomEntrance");

            migrationBuilder.RenameColumn(
                name: "IsFirewallAvailable",
                table: "OrgMonitorings",
                newName: "AvailablityOfGenerators");

            migrationBuilder.RenameColumn(
                name: "IsFireAlarmSystAvailable",
                table: "OrgMonitorings",
                newName: "AvailablityOfFalseFloorAndCeiling");

            migrationBuilder.RenameColumn(
                name: "IsFalseFloorAndCeilingAvailable",
                table: "OrgMonitorings",
                newName: "AvailablityOfAlternativePowerL");

            migrationBuilder.RenameColumn(
                name: "IsEmpsQualificationImproved",
                table: "OrgMonitorings",
                newName: "AvailabilityOfVideoCamInServerRoom");

            migrationBuilder.RenameColumn(
                name: "IsDLPAvailable",
                table: "OrgMonitorings",
                newName: "AvailabilityOfSecAlarmsInCentre");

            migrationBuilder.RenameColumn(
                name: "IsCAndAnalysisToolAvailable",
                table: "OrgMonitorings",
                newName: "AvailabilityOfFireAlarmSystInRoomWithSEq");

            migrationBuilder.RenameColumn(
                name: "FrequncyOfPasswUpdateInSRs",
                table: "OrgMonitorings",
                newName: "ListOfRegJournal");

            migrationBuilder.RenameColumn(
                name: "FrequencyOfPasswUpdateInWRs",
                table: "OrgMonitorings",
                newName: "FrequncyOfPasswUpdateInSRooms");

            migrationBuilder.RenameColumn(
                name: "File_2_3_2Id",
                table: "OrgMonitorings",
                newName: "NumberOfOrgsWithAccesControlToNetwork");

            migrationBuilder.RenameColumn(
                name: "FormSectionId",
                table: "FormItems",
                newName: "FormId");

            migrationBuilder.RenameIndex(
                name: "IX_FormItems_FormSectionId",
                table: "FormItems",
                newName: "IX_FormItems_FormId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeadlineOfPlan",
                table: "OrgMonitorings",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrequencyOfPasswUpdateInWRooms",
                table: "OrgMonitorings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LinkedItemId",
                table: "FormItems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListIndex",
                table: "FormItems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Form1_1MonitoringId",
                table: "FileModels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Form2_1MonitoringId",
                table: "FileModels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Form2_2MonitoringId",
                table: "FileModels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Form2_3MonitoringId",
                table: "FileModels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Form2_4MonitoringId",
                table: "FileModels",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MonitoringForms",
                columns: table => new
                {
                    FormId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FormName = table.Column<string>(type: "text", nullable: true),
                    FormNumber = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoringForms", x => x.FormId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileModels_Form1_1MonitoringId",
                table: "FileModels",
                column: "Form1_1MonitoringId");

            migrationBuilder.CreateIndex(
                name: "IX_FileModels_Form2_1MonitoringId",
                table: "FileModels",
                column: "Form2_1MonitoringId");

            migrationBuilder.CreateIndex(
                name: "IX_FileModels_Form2_2MonitoringId",
                table: "FileModels",
                column: "Form2_2MonitoringId");

            migrationBuilder.CreateIndex(
                name: "IX_FileModels_Form2_3MonitoringId",
                table: "FileModels",
                column: "Form2_3MonitoringId");

            migrationBuilder.CreateIndex(
                name: "IX_FileModels_Form2_4MonitoringId",
                table: "FileModels",
                column: "Form2_4MonitoringId");

            migrationBuilder.CreateIndex(
                name: "IX_MonitoringForms_FormNumber",
                table: "MonitoringForms",
                column: "FormNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FileModels_OrgMonitorings_Form1_1MonitoringId",
                table: "FileModels",
                column: "Form1_1MonitoringId",
                principalTable: "OrgMonitorings",
                principalColumn: "MonitoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileModels_OrgMonitorings_Form2_1MonitoringId",
                table: "FileModels",
                column: "Form2_1MonitoringId",
                principalTable: "OrgMonitorings",
                principalColumn: "MonitoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileModels_OrgMonitorings_Form2_2MonitoringId",
                table: "FileModels",
                column: "Form2_2MonitoringId",
                principalTable: "OrgMonitorings",
                principalColumn: "MonitoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileModels_OrgMonitorings_Form2_3MonitoringId",
                table: "FileModels",
                column: "Form2_3MonitoringId",
                principalTable: "OrgMonitorings",
                principalColumn: "MonitoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileModels_OrgMonitorings_Form2_4MonitoringId",
                table: "FileModels",
                column: "Form2_4MonitoringId",
                principalTable: "OrgMonitorings",
                principalColumn: "MonitoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormItems_MonitoringForms_FormId",
                table: "FormItems",
                column: "FormId",
                principalTable: "MonitoringForms",
                principalColumn: "FormId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QIEmployees_OrgMonitorings_Form2_8MonitoringId",
                table: "QIEmployees",
                column: "Form2_8MonitoringId",
                principalTable: "OrgMonitorings",
                principalColumn: "MonitoringId");
        }
    }
}
