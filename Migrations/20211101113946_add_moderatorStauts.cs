using Microsoft.EntityFrameworkCore.Migrations;

namespace imotoAPI.Migrations
{
    public partial class add_moderatorStauts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModeratorStatusId",
                table: "Moderators",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ModeratorStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeratorStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moderators_ModeratorStatusId",
                table: "Moderators",
                column: "ModeratorStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moderators_ModeratorStatuses_ModeratorStatusId",
                table: "Moderators",
                column: "ModeratorStatusId",
                principalTable: "ModeratorStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moderators_ModeratorStatuses_ModeratorStatusId",
                table: "Moderators");

            migrationBuilder.DropTable(
                name: "ModeratorStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Moderators_ModeratorStatusId",
                table: "Moderators");

            migrationBuilder.DropColumn(
                name: "ModeratorStatusId",
                table: "Moderators");
        }
    }
}
