using Microsoft.EntityFrameworkCore.Migrations;

namespace imotoAPI.Migrations
{
    public partial class add_annoucememntStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnnoucementStatusId",
                table: "Annoucements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnnoucementStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnoucementStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_AnnoucementStatusId",
                table: "Annoucements",
                column: "AnnoucementStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Annoucements_AnnoucementStatuses_AnnoucementStatusId",
                table: "Annoucements",
                column: "AnnoucementStatusId",
                principalTable: "AnnoucementStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annoucements_AnnoucementStatuses_AnnoucementStatusId",
                table: "Annoucements");

            migrationBuilder.DropTable(
                name: "AnnoucementStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Annoucements_AnnoucementStatusId",
                table: "Annoucements");

            migrationBuilder.DropColumn(
                name: "AnnoucementStatusId",
                table: "Annoucements");
        }
    }
}
