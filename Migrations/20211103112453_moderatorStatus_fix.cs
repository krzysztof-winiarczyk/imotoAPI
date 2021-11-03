using Microsoft.EntityFrameworkCore.Migrations;

namespace imotoAPI.Migrations
{
    public partial class moderatorStatus_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Editable",
                table: "ModeratorStatuses",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Editable",
                table: "ModeratorStatuses");
        }
    }
}
