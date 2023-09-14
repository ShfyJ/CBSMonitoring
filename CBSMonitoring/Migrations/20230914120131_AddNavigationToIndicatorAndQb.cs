using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class AddNavigationToIndicatorAndQb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdicatorId",
                table: "QuestionBlocks",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBlocks_IdicatorId",
                table: "QuestionBlocks",
                column: "IdicatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionBlocks_MonitoringIndicators_IdicatorId",
                table: "QuestionBlocks",
                column: "IdicatorId",
                principalTable: "MonitoringIndicators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionBlocks_MonitoringIndicators_IdicatorId",
                table: "QuestionBlocks");

            migrationBuilder.DropIndex(
                name: "IX_QuestionBlocks_IdicatorId",
                table: "QuestionBlocks");

            migrationBuilder.DropColumn(
                name: "IdicatorId",
                table: "QuestionBlocks");
        }
    }
}
