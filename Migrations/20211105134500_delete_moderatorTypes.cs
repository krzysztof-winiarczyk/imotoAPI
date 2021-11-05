using Microsoft.EntityFrameworkCore.Migrations;

namespace imotoAPI.Migrations
{
    public partial class delete_moderatorTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moderators_ModeratorTypes_TypeId",
                table: "Moderators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModeratorTypes",
                table: "ModeratorTypes");

            migrationBuilder.RenameTable(
                name: "ModeratorTypes",
                newName: "ModeratorType");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ModeratorType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ModeratorType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModeratorType",
                table: "ModeratorType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Moderators_ModeratorType_TypeId",
                table: "Moderators",
                column: "TypeId",
                principalTable: "ModeratorType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moderators_ModeratorType_TypeId",
                table: "Moderators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModeratorType",
                table: "ModeratorType");

            migrationBuilder.RenameTable(
                name: "ModeratorType",
                newName: "ModeratorTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ModeratorTypes",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ModeratorTypes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModeratorTypes",
                table: "ModeratorTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Moderators_ModeratorTypes_TypeId",
                table: "Moderators",
                column: "TypeId",
                principalTable: "ModeratorTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
