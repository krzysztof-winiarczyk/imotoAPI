using Microsoft.EntityFrameworkCore.Migrations;

namespace imotoAPI.Migrations
{
    public partial class add_capacity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Annoucements",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Annoucements");
        }
    }
}
