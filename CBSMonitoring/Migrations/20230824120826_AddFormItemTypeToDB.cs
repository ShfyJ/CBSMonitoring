using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class AddFormItemTypeToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "FormItems");

            migrationBuilder.AddColumn<int>(
                name: "ItemTypeId",
                table: "FormItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FormItemTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeName = table.Column<string>(type: "text", nullable: false),
                    TypeDescription = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormItemTypes", x => x.TypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormItems_ItemTypeId",
                table: "FormItems",
                column: "ItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormItems_FormItemTypes_ItemTypeId",
                table: "FormItems",
                column: "ItemTypeId",
                principalTable: "FormItemTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormItems_FormItemTypes_ItemTypeId",
                table: "FormItems");

            migrationBuilder.DropTable(
                name: "FormItemTypes");

            migrationBuilder.DropIndex(
                name: "IX_FormItems_ItemTypeId",
                table: "FormItems");

            migrationBuilder.DropColumn(
                name: "ItemTypeId",
                table: "FormItems");

            migrationBuilder.AddColumn<string>(
                name: "ItemType",
                table: "FormItems",
                type: "text",
                nullable: true);
        }
    }
}
