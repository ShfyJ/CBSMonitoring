using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToForms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsShortcomingsEliminated",
                table: "OrgMonitorings",
                newName: "IsShortcomingsOfWebsiteEliminated");

            migrationBuilder.RenameColumn(
                name: "Form2_10_IsShortcomingsEliminated",
                table: "OrgMonitorings",
                newName: "IsShortcomingsOfObjecttEliminated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsShortcomingsOfWebsiteEliminated",
                table: "OrgMonitorings",
                newName: "IsShortcomingsEliminated");

            migrationBuilder.RenameColumn(
                name: "IsShortcomingsOfObjecttEliminated",
                table: "OrgMonitorings",
                newName: "Form2_10_IsShortcomingsEliminated");
        }
    }
}
