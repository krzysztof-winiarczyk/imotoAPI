﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using imotoAPI.Entities;

namespace imotoAPI.Migrations
{
    [DbContext(typeof(ImotoDbContext))]
    [Migration("20211105134500_delete_moderatorTypes")]
    partial class delete_moderatorTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("imotoAPI.Entities.Annoucement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnnoucementStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("CarBodyworkId")
                        .HasColumnType("int");

                    b.Property<int?>("CarBrandId")
                        .HasColumnType("int");

                    b.Property<string>("CarBrandSpare")
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<int?>("CarClassId")
                        .HasColumnType("int");

                    b.Property<int?>("CarColorId")
                        .HasColumnType("int");

                    b.Property<string>("CarColorSpare")
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<int?>("CarCountryId")
                        .HasColumnType("int");

                    b.Property<int?>("CarDriveId")
                        .HasColumnType("int");

                    b.Property<int?>("CarFuelId")
                        .HasColumnType("int");

                    b.Property<int?>("CarModelId")
                        .HasColumnType("int");

                    b.Property<string>("CarModelSpare")
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<int?>("CarTransmissionId")
                        .HasColumnType("int");

                    b.Property<string>("CarTransmissionSpare")
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<int?>("CarYearId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(511)
                        .HasColumnType("nvarchar(511)");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("VoivodeshipId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnnoucementStatusId");

                    b.HasIndex("CarBodyworkId");

                    b.HasIndex("CarBrandId");

                    b.HasIndex("CarClassId");

                    b.HasIndex("CarColorId");

                    b.HasIndex("CarCountryId");

                    b.HasIndex("CarDriveId");

                    b.HasIndex("CarFuelId");

                    b.HasIndex("CarModelId");

                    b.HasIndex("CarTransmissionId");

                    b.HasIndex("CarYearId");

                    b.HasIndex("UserId");

                    b.HasIndex("VoivodeshipId");

                    b.ToTable("Annoucements");
                });

            modelBuilder.Entity("imotoAPI.Entities.AnnoucementStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("Editable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("AnnoucementStatuses");
                });

            modelBuilder.Entity("imotoAPI.Entities.Annoucement_CarEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnnoucementId")
                        .HasColumnType("int");

                    b.Property<int>("CarEquipmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnnoucementId");

                    b.HasIndex("CarEquipmentId");

                    b.ToTable("Annoucement_CarEquipments");
                });

            modelBuilder.Entity("imotoAPI.Entities.Annoucement_CarStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnnoucementId")
                        .HasColumnType("int");

                    b.Property<int>("CarStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnnoucementId");

                    b.HasIndex("CarStatusId");

                    b.ToTable("Annoucement_CarStatuses");
                });

            modelBuilder.Entity("imotoAPI.Entities.CarBodywork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Link")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("Id");

                    b.ToTable("CarBodyworks");
                });

            modelBuilder.Entity("imotoAPI.Entities.CarBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("Id");

                    b.ToTable("CarBrands");
                });

            modelBuilder.Entity("imotoAPI.Entities.CarClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("CarClasses");
                });

            modelBuilder.Entity("imotoAPI.Entities.CarColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarColors");
                });

            modelBuilder.Entity("imotoAPI.Entities.CarCountry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acronym")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("CarCountries");
                });

            modelBuilder.Entity("imotoAPI.Entities.CarDrive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acronym")
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("Id");

                    b.ToTable("CarDrives");
                });

            modelBuilder.Entity("imotoAPI.Entities.CarEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("CarEquipment");
                });

            modelBuilder.Entity("imotoAPI.Entities.CarFuel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("Id");

                    b.ToTable("CarFuels");
                });

            modelBuilder.Entity("imotoAPI.Entities.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarBrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("Id");

                    b.HasIndex("CarBrandId");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("imotoAPI.Entities.CarStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("Id");

                    b.ToTable("CarStatuses");
                });

            modelBuilder.Entity("imotoAPI.Entities.CarTransmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("Id");

                    b.ToTable("CarTransmissions");
                });

            modelBuilder.Entity("imotoAPI.Entities.CarYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("YearOfProduction")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CarYears");
                });

            modelBuilder.Entity("imotoAPI.Entities.Moderator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<int?>("ModeratorStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModeratorStatusId");

                    b.HasIndex("TypeId");

                    b.ToTable("Moderators");
                });

            modelBuilder.Entity("imotoAPI.Entities.ModeratorStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("Editable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ModeratorStatuses");
                });

            modelBuilder.Entity("imotoAPI.Entities.ModeratorType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ModeratorType");
                });

            modelBuilder.Entity("imotoAPI.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApartmentNumber")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HouseNumber")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Street")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Surname")
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<int?>("UserStatusId")
                        .HasColumnType("int");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.Property<string>("WebAddress")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("UserStatusId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("imotoAPI.Entities.UserStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("Editable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UserStatuses");
                });

            modelBuilder.Entity("imotoAPI.Entities.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("imotoAPI.Entities.Voivodeship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Voivodeships");
                });

            modelBuilder.Entity("imotoAPI.Entities.WatchedAnnoucement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnnoucementId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnnoucementId");

                    b.HasIndex("UserId");

                    b.ToTable("WatchedAnnoucements");
                });

            modelBuilder.Entity("imotoAPI.Entities.WatchedUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("FollowerId")
                        .HasColumnType("int");

                    b.Property<int>("WatchedId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FollowerId");

                    b.HasIndex("WatchedId");

                    b.ToTable("WatchedUsers");
                });

            modelBuilder.Entity("imotoAPI.Entities.Annoucement", b =>
                {
                    b.HasOne("imotoAPI.Entities.AnnoucementStatus", "AnnoucementStatus")
                        .WithMany()
                        .HasForeignKey("AnnoucementStatusId");

                    b.HasOne("imotoAPI.Entities.CarBodywork", "CarBodywork")
                        .WithMany()
                        .HasForeignKey("CarBodyworkId");

                    b.HasOne("imotoAPI.Entities.CarBrand", "CarBrand")
                        .WithMany()
                        .HasForeignKey("CarBrandId");

                    b.HasOne("imotoAPI.Entities.CarClass", "CarClass")
                        .WithMany()
                        .HasForeignKey("CarClassId");

                    b.HasOne("imotoAPI.Entities.CarColor", "CarColor")
                        .WithMany()
                        .HasForeignKey("CarColorId");

                    b.HasOne("imotoAPI.Entities.CarCountry", "CarCountry")
                        .WithMany()
                        .HasForeignKey("CarCountryId");

                    b.HasOne("imotoAPI.Entities.CarDrive", "CarDrive")
                        .WithMany()
                        .HasForeignKey("CarDriveId");

                    b.HasOne("imotoAPI.Entities.CarFuel", "CarFuel")
                        .WithMany()
                        .HasForeignKey("CarFuelId");

                    b.HasOne("imotoAPI.Entities.CarModel", "CarModel")
                        .WithMany()
                        .HasForeignKey("CarModelId");

                    b.HasOne("imotoAPI.Entities.CarTransmission", "CarTransmission")
                        .WithMany()
                        .HasForeignKey("CarTransmissionId");

                    b.HasOne("imotoAPI.Entities.CarYear", "CarYear")
                        .WithMany()
                        .HasForeignKey("CarYearId");

                    b.HasOne("imotoAPI.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("imotoAPI.Entities.Voivodeship", "Voivodeship")
                        .WithMany()
                        .HasForeignKey("VoivodeshipId");

                    b.Navigation("AnnoucementStatus");

                    b.Navigation("CarBodywork");

                    b.Navigation("CarBrand");

                    b.Navigation("CarClass");

                    b.Navigation("CarColor");

                    b.Navigation("CarCountry");

                    b.Navigation("CarDrive");

                    b.Navigation("CarFuel");

                    b.Navigation("CarModel");

                    b.Navigation("CarTransmission");

                    b.Navigation("CarYear");

                    b.Navigation("User");

                    b.Navigation("Voivodeship");
                });

            modelBuilder.Entity("imotoAPI.Entities.Annoucement_CarEquipment", b =>
                {
                    b.HasOne("imotoAPI.Entities.Annoucement", "Annoucement")
                        .WithMany()
                        .HasForeignKey("AnnoucementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("imotoAPI.Entities.CarEquipment", "CarEquipment")
                        .WithMany()
                        .HasForeignKey("CarEquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Annoucement");

                    b.Navigation("CarEquipment");
                });

            modelBuilder.Entity("imotoAPI.Entities.Annoucement_CarStatus", b =>
                {
                    b.HasOne("imotoAPI.Entities.Annoucement", "Annoucement")
                        .WithMany()
                        .HasForeignKey("AnnoucementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("imotoAPI.Entities.CarStatus", "CarStatus")
                        .WithMany()
                        .HasForeignKey("CarStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Annoucement");

                    b.Navigation("CarStatus");
                });

            modelBuilder.Entity("imotoAPI.Entities.CarModel", b =>
                {
                    b.HasOne("imotoAPI.Entities.CarBrand", "CarBrand")
                        .WithMany()
                        .HasForeignKey("CarBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarBrand");
                });

            modelBuilder.Entity("imotoAPI.Entities.Moderator", b =>
                {
                    b.HasOne("imotoAPI.Entities.ModeratorStatus", "ModeratorStatus")
                        .WithMany()
                        .HasForeignKey("ModeratorStatusId");

                    b.HasOne("imotoAPI.Entities.ModeratorType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModeratorStatus");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("imotoAPI.Entities.User", b =>
                {
                    b.HasOne("imotoAPI.Entities.UserStatus", "UserStatus")
                        .WithMany()
                        .HasForeignKey("UserStatusId");

                    b.HasOne("imotoAPI.Entities.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserStatus");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("imotoAPI.Entities.WatchedAnnoucement", b =>
                {
                    b.HasOne("imotoAPI.Entities.Annoucement", "Annoucement")
                        .WithMany()
                        .HasForeignKey("AnnoucementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("imotoAPI.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Annoucement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("imotoAPI.Entities.WatchedUser", b =>
                {
                    b.HasOne("imotoAPI.Entities.User", "Follower")
                        .WithMany()
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("imotoAPI.Entities.User", "Watched")
                        .WithMany()
                        .HasForeignKey("WatchedId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Follower");

                    b.Navigation("Watched");
                });
#pragma warning restore 612, 618
        }
    }
}
