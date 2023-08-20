using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class AddFormNameTOTableMonitoringForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormName",
                table: "MonitoringForms",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormName",
                table: "MonitoringForms");
        }
    }
}
