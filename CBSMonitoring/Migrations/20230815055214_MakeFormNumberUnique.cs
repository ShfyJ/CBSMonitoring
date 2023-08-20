using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class MakeFormNumberUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MonitoringForms_FormNumber",
                table: "MonitoringForms",
                column: "FormNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MonitoringForms_FormNumber",
                table: "MonitoringForms");
        }
    }
}
