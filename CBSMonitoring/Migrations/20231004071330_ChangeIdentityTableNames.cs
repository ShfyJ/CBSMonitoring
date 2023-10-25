using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIdentityTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "cbs_userTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "cbs_userRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "cbs_userLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "cbs_userClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "cbs_roles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "cbs_userRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "cbs_userRoles",
                newName: "IX_cbs_userRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "cbs_userLogins",
                newName: "IX_cbs_userLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "cbs_userClaims",
                newName: "IX_cbs_userClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "cbs_userRoleClaims",
                newName: "IX_cbs_userRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cbs_userTokens",
                table: "cbs_userTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_cbs_userRoles",
                table: "cbs_userRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_cbs_userLogins",
                table: "cbs_userLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_cbs_userClaims",
                table: "cbs_userClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cbs_roles",
                table: "cbs_roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cbs_userRoleClaims",
                table: "cbs_userRoleClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "cbs_users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_cbs_users", x => x.Id);
                });

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
                name: "FK_cbs_userRoleClaims_cbs_roles_RoleId",
                table: "cbs_userRoleClaims",
                column: "RoleId",
                principalTable: "cbs_roles",
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
                name: "FK_cbs_userRoles_cbs_roles_RoleId",
                table: "cbs_userRoles",
                column: "RoleId",
                principalTable: "cbs_roles",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cbs_userClaims_AspNetUsers_UserId",
                table: "cbs_userClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_cbs_userLogins_AspNetUsers_UserId",
                table: "cbs_userLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_cbs_userRoleClaims_cbs_roles_RoleId",
                table: "cbs_userRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_cbs_userRoles_AspNetUsers_UserId",
                table: "cbs_userRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_cbs_userRoles_cbs_roles_RoleId",
                table: "cbs_userRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_cbs_userTokens_AspNetUsers_UserId",
                table: "cbs_userTokens");

            migrationBuilder.DropTable(
                name: "cbs_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cbs_userTokens",
                table: "cbs_userTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cbs_userRoles",
                table: "cbs_userRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cbs_userRoleClaims",
                table: "cbs_userRoleClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cbs_userLogins",
                table: "cbs_userLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cbs_userClaims",
                table: "cbs_userClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cbs_roles",
                table: "cbs_roles");

            migrationBuilder.RenameTable(
                name: "cbs_userTokens",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "cbs_userRoles",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "cbs_userRoleClaims",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "cbs_userLogins",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "cbs_userClaims",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "cbs_roles",
                newName: "AspNetRoles");

            migrationBuilder.RenameIndex(
                name: "IX_cbs_userRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_cbs_userRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_cbs_userLogins_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_cbs_userClaims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
