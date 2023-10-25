using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAspnetUsersTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cbs_userClaims_AspNetUsers_UserId",
                table: "cbs_userClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_cbs_userLogins_AspNetUsers_UserId",
                table: "cbs_userLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_cbs_userRoles_AspNetUsers_UserId",
                table: "cbs_userRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_cbs_userTokens_AspNetUsers_UserId",
                table: "cbs_userTokens");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "cbs_users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                table: "cbs_users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                table: "cbs_users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "cbs_users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "cbs_users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "cbs_users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "cbs_users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "cbs_users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_cbs_users_OrganizationId",
                table: "cbs_users",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "cbs_users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cbs_userClaims_cbs_users_UserId",
                table: "cbs_userClaims",
                column: "UserId",
                principalTable: "cbs_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cbs_userLogins_cbs_users_UserId",
                table: "cbs_userLogins",
                column: "UserId",
                principalTable: "cbs_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cbs_userRoles_cbs_users_UserId",
                table: "cbs_userRoles",
                column: "UserId",
                principalTable: "cbs_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cbs_users_Organizations_OrganizationId",
                table: "cbs_users",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cbs_userTokens_cbs_users_UserId",
                table: "cbs_userTokens",
                column: "UserId",
                principalTable: "cbs_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cbs_userClaims_cbs_users_UserId",
                table: "cbs_userClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_cbs_userLogins_cbs_users_UserId",
                table: "cbs_userLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_cbs_userRoles_cbs_users_UserId",
                table: "cbs_userRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_cbs_users_Organizations_OrganizationId",
                table: "cbs_users");

            migrationBuilder.DropForeignKey(
                name: "FK_cbs_userTokens_cbs_users_UserId",
                table: "cbs_userTokens");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "cbs_users");

            migrationBuilder.DropIndex(
                name: "IX_cbs_users_OrganizationId",
                table: "cbs_users");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "cbs_users");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "cbs_users");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "cbs_users");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "cbs_users");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "cbs_users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                table: "cbs_users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                table: "cbs_users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "cbs_users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    OrganizationId = table.Column<int>(type: "integer", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    FullName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OrganizationId",
                table: "AspNetUsers",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cbs_userClaims_AspNetUsers_UserId",
                table: "cbs_userClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cbs_userLogins_AspNetUsers_UserId",
                table: "cbs_userLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cbs_userRoles_AspNetUsers_UserId",
                table: "cbs_userRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cbs_userTokens_AspNetUsers_UserId",
                table: "cbs_userTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
