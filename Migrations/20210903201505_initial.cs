using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace imotoAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnnoucementStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnoucementStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarBodyworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBodyworks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarCountries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Acronym = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCountries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarDrives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Acronym = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDrives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarFuels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarFuels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarTransmissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarTransmissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearOfProduction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnterpriseUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    WebAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModeratorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeratorTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrivateUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CarBrandId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModels_CarBrands_CarBrandId",
                        column: x => x.CarBrandId,
                        principalTable: "CarBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_EnterpriseUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "EnterpriseUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moderators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moderators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moderators_ModeratorTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ModeratorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Annoucements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CarClassId = table.Column<int>(type: "int", nullable: false),
                    CarBrandId = table.Column<int>(type: "int", nullable: false),
                    CarBrandSpare = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    CarModelId = table.Column<int>(type: "int", nullable: false),
                    CarModelSpare = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    CarColorId = table.Column<int>(type: "int", nullable: false),
                    CarColorSpare = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    CarBodyworkId = table.Column<int>(type: "int", nullable: false),
                    CarCountryId = table.Column<int>(type: "int", nullable: false),
                    CarYearId = table.Column<int>(type: "int", nullable: false),
                    CarFuelId = table.Column<int>(type: "int", nullable: false),
                    CarDriveId = table.Column<int>(type: "int", nullable: false),
                    CarTransmissionId = table.Column<int>(type: "int", nullable: false),
                    CarTransmissionSpare = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    CarStatusId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(511)", maxLength: 511, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annoucements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Annoucements_CarBodyworks_CarBodyworkId",
                        column: x => x.CarBodyworkId,
                        principalTable: "CarBodyworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annoucements_CarBrands_CarBrandId",
                        column: x => x.CarBrandId,
                        principalTable: "CarBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annoucements_CarClasses_CarClassId",
                        column: x => x.CarClassId,
                        principalTable: "CarClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annoucements_CarColors_CarColorId",
                        column: x => x.CarColorId,
                        principalTable: "CarColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annoucements_CarCountries_CarCountryId",
                        column: x => x.CarCountryId,
                        principalTable: "CarCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annoucements_CarDrives_CarDriveId",
                        column: x => x.CarDriveId,
                        principalTable: "CarDrives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annoucements_CarFuels_CarFuelId",
                        column: x => x.CarFuelId,
                        principalTable: "CarFuels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annoucements_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annoucements_CarStatuses_CarStatusId",
                        column: x => x.CarStatusId,
                        principalTable: "CarStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annoucements_CarTransmissions_CarTransmissionId",
                        column: x => x.CarTransmissionId,
                        principalTable: "CarTransmissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annoucements_CarYears_CarYearId",
                        column: x => x.CarYearId,
                        principalTable: "CarYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annoucements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WatchedUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FollowerId = table.Column<int>(type: "int", nullable: false),
                    WatchedId = table.Column<int>(type: "int", nullable: false),
                    DateOfStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WatchedUsers_Users_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WatchedUsers_Users_WatchedId",
                        column: x => x.WatchedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Annoucement_CarEquipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnoucementId = table.Column<int>(type: "int", nullable: false),
                    CarEquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annoucement_CarEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Annoucement_CarEquipments_Annoucements_AnnoucementId",
                        column: x => x.AnnoucementId,
                        principalTable: "Annoucements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annoucement_CarEquipments_CarEquipment_CarEquipmentId",
                        column: x => x.CarEquipmentId,
                        principalTable: "CarEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Annoucement_CarStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnoucementId = table.Column<int>(type: "int", nullable: false),
                    CarStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annoucement_CarStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Annoucement_CarStatuses_Annoucements_AnnoucementId",
                        column: x => x.AnnoucementId,
                        principalTable: "Annoucements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Annoucement_CarStatuses_CarStatuses_CarStatusId",
                        column: x => x.CarStatusId,
                        principalTable: "CarStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WatchedAnnoucements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AnnoucementId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchedAnnoucements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WatchedAnnoucements_Annoucements_AnnoucementId",
                        column: x => x.AnnoucementId,
                        principalTable: "Annoucements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WatchedAnnoucements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Annoucement_CarEquipments_AnnoucementId",
                table: "Annoucement_CarEquipments",
                column: "AnnoucementId");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucement_CarEquipments_CarEquipmentId",
                table: "Annoucement_CarEquipments",
                column: "CarEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucement_CarStatuses_AnnoucementId",
                table: "Annoucement_CarStatuses",
                column: "AnnoucementId");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucement_CarStatuses_CarStatusId",
                table: "Annoucement_CarStatuses",
                column: "CarStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_CarBodyworkId",
                table: "Annoucements",
                column: "CarBodyworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_CarBrandId",
                table: "Annoucements",
                column: "CarBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_CarClassId",
                table: "Annoucements",
                column: "CarClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_CarColorId",
                table: "Annoucements",
                column: "CarColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_CarCountryId",
                table: "Annoucements",
                column: "CarCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_CarDriveId",
                table: "Annoucements",
                column: "CarDriveId");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_CarFuelId",
                table: "Annoucements",
                column: "CarFuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_CarModelId",
                table: "Annoucements",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_CarStatusId",
                table: "Annoucements",
                column: "CarStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_CarTransmissionId",
                table: "Annoucements",
                column: "CarTransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_CarYearId",
                table: "Annoucements",
                column: "CarYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_UserId",
                table: "Annoucements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_CarBrandId",
                table: "CarModels",
                column: "CarBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Moderators_TypeId",
                table: "Moderators",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_UserId",
                table: "Phones",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchedAnnoucements_AnnoucementId",
                table: "WatchedAnnoucements",
                column: "AnnoucementId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchedAnnoucements_UserId",
                table: "WatchedAnnoucements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchedUsers_FollowerId",
                table: "WatchedUsers",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchedUsers_WatchedId",
                table: "WatchedUsers",
                column: "WatchedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annoucement_CarEquipments");

            migrationBuilder.DropTable(
                name: "Annoucement_CarStatuses");

            migrationBuilder.DropTable(
                name: "AnnoucementStatuses");

            migrationBuilder.DropTable(
                name: "Moderators");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "PrivateUsers");

            migrationBuilder.DropTable(
                name: "WatchedAnnoucements");

            migrationBuilder.DropTable(
                name: "WatchedUsers");

            migrationBuilder.DropTable(
                name: "CarEquipment");

            migrationBuilder.DropTable(
                name: "ModeratorTypes");

            migrationBuilder.DropTable(
                name: "EnterpriseUsers");

            migrationBuilder.DropTable(
                name: "Annoucements");

            migrationBuilder.DropTable(
                name: "CarBodyworks");

            migrationBuilder.DropTable(
                name: "CarClasses");

            migrationBuilder.DropTable(
                name: "CarColors");

            migrationBuilder.DropTable(
                name: "CarCountries");

            migrationBuilder.DropTable(
                name: "CarDrives");

            migrationBuilder.DropTable(
                name: "CarFuels");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "CarStatuses");

            migrationBuilder.DropTable(
                name: "CarTransmissions");

            migrationBuilder.DropTable(
                name: "CarYears");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CarBrands");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
