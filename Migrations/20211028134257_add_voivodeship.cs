using Microsoft.EntityFrameworkCore.Migrations;

namespace imotoAPI.Migrations
{
    public partial class add_voivodeship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VoivodeshipId",
                table: "Annoucements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Voivodeships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voivodeships", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_VoivodeshipId",
                table: "Annoucements",
                column: "VoivodeshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Annoucements_Voivodeships_VoivodeshipId",
                table: "Annoucements",
                column: "VoivodeshipId",
                principalTable: "Voivodeships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annoucements_Voivodeships_VoivodeshipId",
                table: "Annoucements");

            migrationBuilder.DropTable(
                name: "Voivodeships");

            migrationBuilder.DropIndex(
                name: "IX_Annoucements_VoivodeshipId",
                table: "Annoucements");

            migrationBuilder.DropColumn(
                name: "VoivodeshipId",
                table: "Annoucements");
        }
    }
}
