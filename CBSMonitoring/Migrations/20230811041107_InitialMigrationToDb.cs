using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonitoringForms",
                columns: table => new
                {
                    FormId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FormNumber = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoringForms", x => x.FormId);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationName = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    ListIndex = table.Column<int>(type: "integer", nullable: true),
                    LinkedItemId = table.Column<int>(type: "integer", nullable: true),
                    SelectOptions = table.Column<string[]>(type: "text[]", nullable: true),
                    ItemLabel = table.Column<string>(type: "text", nullable: true),
                    ItemName = table.Column<string>(type: "text", nullable: true),
                    ItemType = table.Column<string>(type: "text", nullable: true),
                    FormId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_FormItems_MonitoringForms_FormId",
                        column: x => x.FormId,
                        principalTable: "MonitoringForms",
                        principalColumn: "FormId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrgMonitorings",
                columns: table => new
                {
                    MonitoringId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationId = table.Column<int>(type: "integer", nullable: false),
                    QuaterIndex = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    HasPolicy = table.Column<bool>(type: "boolean", nullable: true),
                    IsReviewedByCBS = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfEmployees = table.Column<int>(type: "integer", nullable: true),
                    PercentageOfEmpFamiliarWithPolicy = table.Column<float>(type: "real", nullable: true),
                    IsAuditConducted = table.Column<bool>(type: "boolean", nullable: true),
                    HasISPRevised = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfRevision = table.Column<int>(type: "integer", nullable: true),
                    YearOfRevisions = table.Column<int>(type: "integer", nullable: true),
                    NumberOfRegDocs = table.Column<int>(type: "integer", nullable: true),
                    ListOfRegDocs = table.Column<string>(type: "text", nullable: true),
                    NumberOfRegJournal = table.Column<int>(type: "integer", nullable: true),
                    ListOfRegJournal = table.Column<string>(type: "text", nullable: true),
                    IsListAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    ConfidentialDocNumber = table.Column<string>(type: "text", nullable: true),
                    ConfidentialDocDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsComissionPresent = table.Column<bool>(type: "boolean", nullable: true),
                    ComissionDocNumber = table.Column<string>(type: "text", nullable: true),
                    ComissionDocDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsListOfOfficialAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    OfficialsDocNumber = table.Column<string>(type: "text", nullable: true),
                    OfficialsDocDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsListCommToEmps = table.Column<bool>(type: "boolean", nullable: true),
                    IsAgreementsAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    IsRelevantClausesAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfEmplFamWithAgreements = table.Column<int>(type: "integer", nullable: true),
                    PercentageOfEmpFamWithAgreements = table.Column<float>(type: "real", nullable: true),
                    IsActionPlanAvailableToEnsIC = table.Column<bool>(type: "boolean", nullable: true),
                    ReasonForAbsenceOfPlan = table.Column<string>(type: "text", nullable: true),
                    IsActionPlanAgreedToEnsIC = table.Column<bool>(type: "boolean", nullable: true),
                    ReasonForAbsenceOfAgreement = table.Column<string>(type: "text", nullable: true),
                    IsObjectsAudited = table.Column<bool>(type: "boolean", nullable: true),
                    AuditedObjectsNames = table.Column<string>(type: "text", nullable: true),
                    OrgNameMadeAudit = table.Column<string>(type: "text", nullable: true),
                    AuditPeriod = table.Column<string>(type: "text", nullable: true),
                    NumberOfAuditConc = table.Column<string>(type: "text", nullable: true),
                    AuditConcDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsShortcomingDetected = table.Column<bool>(type: "boolean", nullable: true),
                    Form2_10_IsShortcomingsEliminated = table.Column<bool>(type: "boolean", nullable: true),
                    IsEntranceSecurityAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfObjWithSecurity = table.Column<int>(type: "integer", nullable: true),
                    IsACSAvialble = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfObjInACS = table.Column<int>(type: "integer", nullable: true),
                    IsCheckInOutLogAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfPointsInLog = table.Column<int>(type: "integer", nullable: true),
                    IsSurveillanceCamerasAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfVideoCamsInCentre = table.Column<int>(type: "integer", nullable: true),
                    NumberOfStructObjsWithCams = table.Column<int>(type: "integer", nullable: true),
                    NumberOfVideoCamsInTerritorialObjs = table.Column<int>(type: "integer", nullable: true),
                    AvailabilityOfSecAlarmsInCentre = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfRoomsMonitoredByAlarms = table.Column<int>(type: "integer", nullable: true),
                    NumberOfTerritObjsWithAlarms = table.Column<int>(type: "integer", nullable: true),
                    IsServerRoomAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfServerRoom = table.Column<int>(type: "integer", nullable: true),
                    IsDataCentreAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfDataCentre = table.Column<int>(type: "integer", nullable: true),
                    NumberOfSRandDCWithMetalDoor = table.Column<int>(type: "integer", nullable: true),
                    NumberOfSRandDCWithWithSystemControl = table.Column<int>(type: "integer", nullable: true),
                    IsCoolingSystemAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    IsAntiFireEquipAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    IsPlanForPreventiveMaintAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    AvailabilityOfVideoCamInServerRoom = table.Column<bool>(type: "boolean", nullable: true),
                    AvailablityOfFalseFloorAndCeiling = table.Column<bool>(type: "boolean", nullable: true),
                    AvailablityOfTempSensors = table.Column<bool>(type: "boolean", nullable: true),
                    AvailablityOfLogsForServerRoomEntrance = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfServersWithSealedOuterCases = table.Column<int>(type: "integer", nullable: true),
                    NumberOfWorkStWithSealedOuterCases = table.Column<int>(type: "integer", nullable: true),
                    IsLogsForIncidentsAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfObjWithIncidentLog = table.Column<int>(type: "integer", nullable: true),
                    IsDepISAndHeadNotified = table.Column<bool>(type: "boolean", nullable: true),
                    IsIncidentsInvestigated = table.Column<bool>(type: "boolean", nullable: true),
                    IsAnyIncidentResoluted = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfIncidents = table.Column<int>(type: "integer", nullable: true),
                    NumOfIncidentsInStructOrg = table.Column<int>(type: "integer", nullable: true),
                    NumOfIncidentsInSubObjects = table.Column<int>(type: "integer", nullable: true),
                    NumOfIncidentsInvestigated = table.Column<int>(type: "integer", nullable: true),
                    NumOFIncidentsResoluted = table.Column<int>(type: "integer", nullable: true),
                    IsBackupMeasuresProvided = table.Column<bool>(type: "boolean", nullable: true),
                    NumOfISBackupProvided = table.Column<int>(type: "integer", nullable: true),
                    NumOfConfidentialInfo = table.Column<int>(type: "integer", nullable: true),
                    BackupFrequency = table.Column<string>(type: "text", nullable: true),
                    NumOfServersSoftRedundancyMeasured = table.Column<int>(type: "integer", nullable: true),
                    IsApprovedScheduleForBackupAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    NumOfServersWithLicensedOS = table.Column<int>(type: "integer", nullable: true),
                    NumOfServersWithUpdatingOs = table.Column<int>(type: "integer", nullable: true),
                    NumOfWRoomswihLicensedOS = table.Column<int>(type: "integer", nullable: true),
                    IsPlannedPrevWorkAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    FrequencyOfPrevMaintanence = table.Column<string>(type: "text", nullable: true),
                    IsRecoveryPlansAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    AvailabilityOfFireAlarmSystInRoomWithSEq = table.Column<bool>(type: "boolean", nullable: true),
                    PresenceOfGasFireExtSystInRoomWithSEq = table.Column<bool>(type: "boolean", nullable: true),
                    AvailablityOfUPSForSEq = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfServersWithUPS = table.Column<int>(type: "integer", nullable: true),
                    IsUPSAvailableForWRooms = table.Column<bool>(type: "boolean", nullable: true),
                    WorkRoomsWithUPS = table.Column<int>(type: "integer", nullable: true),
                    AvailablityOfAlternativePowerL = table.Column<bool>(type: "boolean", nullable: true),
                    AvailablityOfGenerators = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfGenerators = table.Column<int>(type: "integer", nullable: true),
                    IsLogsOfCarriersOfConfInfAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    SectNumber = table.Column<int>(type: "integer", nullable: true),
                    DeadlineOfPlan = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsExecuted = table.Column<bool>(type: "boolean", nullable: true),
                    DeadlineOfRealExec = table.Column<bool>(type: "boolean", nullable: true),
                    IsListOfProtectedObjAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    IsObjectsClasified = table.Column<bool>(type: "boolean", nullable: true),
                    IsISystemAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    IsISystemResourcesAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    IsISecDivisionPresent = table.Column<bool>(type: "boolean", nullable: true),
                    ISsecDivisionName = table.Column<string>(type: "text", nullable: true),
                    IsDevisionPositionPresent = table.Column<bool>(type: "boolean", nullable: true),
                    SectionHeadFullName = table.Column<string>(type: "text", nullable: true),
                    PositionOfSectionHead = table.Column<string>(type: "text", nullable: true),
                    PhoneNumOfSectionHead = table.Column<string>(type: "text", nullable: true),
                    EmailOfSectionHead = table.Column<string>(type: "text", nullable: true),
                    NumberOfISEmployees = table.Column<int>(type: "integer", nullable: true),
                    IsOrganizationInvolvedInOutsourcingOfIS = table.Column<bool>(type: "boolean", nullable: true),
                    NameOfOutSourcingOrg = table.Column<string>(type: "text", nullable: true),
                    ContractNumberOfOutsoucingOrg = table.Column<string>(type: "text", nullable: true),
                    ContractDateOfOutsoucingOrg = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ListOfServicesOfOutsourcingOrg = table.Column<string>(type: "text", nullable: true),
                    IsResponsiblePersonAssigned = table.Column<bool>(type: "boolean", nullable: true),
                    FullNameOfRespPerSon = table.Column<string>(type: "text", nullable: true),
                    PositionOfRespPerson = table.Column<string>(type: "text", nullable: true),
                    TelNumOfRespPerson = table.Column<string>(type: "text", nullable: true),
                    EmailOfRespPerson = table.Column<string>(type: "text", nullable: true),
                    IsRespPersonAvailableForSecIssues = table.Column<bool>(type: "boolean", nullable: true),
                    FullNameOfRespPersonForSecIssues = table.Column<string>(type: "text", nullable: true),
                    PositionOfRespPersonForSecIssues = table.Column<string>(type: "text", nullable: true),
                    TelNumberOfRespPersonForSecIssues = table.Column<string>(type: "text", nullable: true),
                    EmailOfRespPersonForSecIssues = table.Column<string>(type: "text", nullable: true),
                    IsInstructionPresent = table.Column<bool>(type: "boolean", nullable: true),
                    PositionInstructionCount = table.Column<int>(type: "integer", nullable: true),
                    NumberOfEmpsQualificaitonImproved = table.Column<int>(type: "integer", nullable: true),
                    QualifImpEmpIds = table.Column<int[]>(type: "integer[]", nullable: true),
                    WebAddress = table.Column<string>(type: "text", nullable: true),
                    ExpertizingPeriod = table.Column<string>(type: "text", nullable: true),
                    ExpertConclusionNumber = table.Column<string>(type: "text", nullable: true),
                    ExpertConclusionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    HasShortcomings = table.Column<bool>(type: "boolean", nullable: true),
                    IsShortcomingsEliminated = table.Column<bool>(type: "boolean", nullable: true),
                    IsPasswProtectInWRooms = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfWRoomsWithPasswProtection = table.Column<int>(type: "integer", nullable: true),
                    FrequencyOfPasswUpdateInWRooms = table.Column<string>(type: "text", nullable: true),
                    IsPasswProtectInSRooms = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfSRoomsWithPasswProtection = table.Column<int>(type: "integer", nullable: true),
                    FrequncyOfPasswUpdateInSRooms = table.Column<string>(type: "text", nullable: true),
                    NameAndVersionOfDLP = table.Column<string>(type: "text", nullable: true),
                    IsLicenceOfDLPAvaliable = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfWorkRoomsWithDLP = table.Column<int>(type: "integer", nullable: true),
                    NameAndVersionOfSIEM = table.Column<string>(type: "text", nullable: true),
                    IsLicenseForSIEMAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    NameAndVersionOfCAndSAnalysisTool = table.Column<string>(type: "text", nullable: true),
                    PurposeOfCAndSAnalysisTools = table.Column<string>(type: "text", nullable: true),
                    NumberOfCAndSAnalysisTools = table.Column<string>(type: "text", nullable: true),
                    NameOfProtectionTool = table.Column<string>(type: "text", nullable: true),
                    PurposeOfProtectionTool = table.Column<string>(type: "text", nullable: true),
                    NumberOfProtectionTool = table.Column<int>(type: "integer", nullable: true),
                    IsAccessControlToNetworkInCentreAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    NameOfToolForAccessControlInCentre = table.Column<string>(type: "text", nullable: true),
                    IsAccessControlToNetworkInStrucDivAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfOrgsWithAccesControlToNetwork = table.Column<int>(type: "integer", nullable: true),
                    NameOfToolsForAccessControl = table.Column<string>(type: "text", nullable: true),
                    IsAccessControlSystemAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfISWithACS = table.Column<int>(type: "integer", nullable: true),
                    NumberOfISWithOnlyPassw = table.Column<int>(type: "integer", nullable: true),
                    NumberOfISWithCryptKeys = table.Column<int>(type: "integer", nullable: true),
                    NumberOfISWithConfInfUsingACS = table.Column<int>(type: "integer", nullable: true),
                    NumberOfISWithConfInfWithOnlyPassw = table.Column<int>(type: "integer", nullable: true),
                    NumberOfISWithConfInfWithCryptKeys = table.Column<int>(type: "integer", nullable: true),
                    NameOfACMTool = table.Column<string>(type: "text", nullable: true),
                    UserIDsInAccess = table.Column<string>(type: "text", nullable: true),
                    IsAccessEventsAndLogsRecorded = table.Column<bool>(type: "boolean", nullable: true),
                    FrequencyOfIDsChange = table.Column<string>(type: "text", nullable: true),
                    NameAndVersionOfAntimalwareProgram = table.Column<string>(type: "text", nullable: true),
                    IsLicenseForAntiMAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfServersWithAntiM = table.Column<int>(type: "integer", nullable: true),
                    NumberOfWRoomsWithAntiM = table.Column<int>(type: "integer", nullable: true),
                    NameAndVersionOfFirewall = table.Column<string>(type: "text", nullable: true),
                    IsLicenceForFireWallAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    NameAndVersionOfIDPS = table.Column<string>(type: "text", nullable: true),
                    IsLicenseForIDPSAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    IsEXATAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfSystemsWithEXAT = table.Column<int>(type: "integer", nullable: true),
                    IsHUMOAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    NumberOfsystemsWithHUMO = table.Column<int>(type: "integer", nullable: true),
                    IsVPNUsed = table.Column<bool>(type: "boolean", nullable: true),
                    PurposeAndScopeOfVPNConnections = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgMonitorings", x => x.MonitoringId);
                    table.ForeignKey(
                        name: "FK_OrgMonitorings_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileModels",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Extension = table.Column<string>(type: "text", nullable: true),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    SystemPath = table.Column<string>(type: "text", nullable: true),
                    BasePath = table.Column<string>(type: "text", nullable: true),
                    DocNumber = table.Column<string>(type: "text", nullable: true),
                    DocDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Form1_1MonitoringId = table.Column<int>(type: "integer", nullable: true),
                    Form2_1MonitoringId = table.Column<int>(type: "integer", nullable: true),
                    Form2_2MonitoringId = table.Column<int>(type: "integer", nullable: true),
                    Form2_3MonitoringId = table.Column<int>(type: "integer", nullable: true),
                    Form2_4MonitoringId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileModels", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_FileModels_OrgMonitorings_Form1_1MonitoringId",
                        column: x => x.Form1_1MonitoringId,
                        principalTable: "OrgMonitorings",
                        principalColumn: "MonitoringId");
                    table.ForeignKey(
                        name: "FK_FileModels_OrgMonitorings_Form2_1MonitoringId",
                        column: x => x.Form2_1MonitoringId,
                        principalTable: "OrgMonitorings",
                        principalColumn: "MonitoringId");
                    table.ForeignKey(
                        name: "FK_FileModels_OrgMonitorings_Form2_2MonitoringId",
                        column: x => x.Form2_2MonitoringId,
                        principalTable: "OrgMonitorings",
                        principalColumn: "MonitoringId");
                    table.ForeignKey(
                        name: "FK_FileModels_OrgMonitorings_Form2_3MonitoringId",
                        column: x => x.Form2_3MonitoringId,
                        principalTable: "OrgMonitorings",
                        principalColumn: "MonitoringId");
                    table.ForeignKey(
                        name: "FK_FileModels_OrgMonitorings_Form2_4MonitoringId",
                        column: x => x.Form2_4MonitoringId,
                        principalTable: "OrgMonitorings",
                        principalColumn: "MonitoringId");
                });

            migrationBuilder.CreateTable(
                name: "QIEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
                    CourseName = table.Column<string>(type: "text", nullable: false),
                    EducationPeriod = table.Column<string>(type: "text", nullable: false),
                    CourseConductedOrgName = table.Column<string>(type: "text", nullable: false),
                    CertificateFileId = table.Column<int>(type: "integer", nullable: false),
                    Form2_8MonitoringId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QIEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QIEmployees_FileModels_CertificateFileId",
                        column: x => x.CertificateFileId,
                        principalTable: "FileModels",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QIEmployees_OrgMonitorings_Form2_8MonitoringId",
                        column: x => x.Form2_8MonitoringId,
                        principalTable: "OrgMonitorings",
                        principalColumn: "MonitoringId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

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
                name: "IX_FormItems_FormId",
                table: "FormItems",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgMonitorings_OrganizationId",
                table: "OrgMonitorings",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_QIEmployees_CertificateFileId",
                table: "QIEmployees",
                column: "CertificateFileId");

            migrationBuilder.CreateIndex(
                name: "IX_QIEmployees_Form2_8MonitoringId",
                table: "QIEmployees",
                column: "Form2_8MonitoringId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FormItems");

            migrationBuilder.DropTable(
                name: "QIEmployees");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MonitoringForms");

            migrationBuilder.DropTable(
                name: "FileModels");

            migrationBuilder.DropTable(
                name: "OrgMonitorings");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
