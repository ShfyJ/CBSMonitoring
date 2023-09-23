using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBSMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class AddListNameToItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ListName",
                table: "FormItems",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListName",
                table: "FormItems");
        }
    }
}
