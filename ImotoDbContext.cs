﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Entities
{
    public class ImotoDbContext : DbContext
    {
        private string _connectionString =
            "Server=DESKTOP-B44JBKM;Database=imotoDb;Trusted_Connection=True;";

        public DbSet<Annoucement> Annoucements { get; set; }
        public DbSet<Annoucement_CarEquipment> Annoucement_CarEquipments { get; set; }
        public DbSet<Annoucement_CarStatus> Annoucement_CarStatuses { get; set; }
        public DbSet<AnnoucementStatus> AnnoucementStatuses { get; set; }
        public DbSet<CarBodywork> CarBodyworks { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarClass> CarClasses { get; set; }
        public DbSet<CarColor> CarColors { get; set; }
        public DbSet<CarCountry> CarCountries { get; set; }
        public DbSet<CarDrive> CarDrives { get; set; }
        public DbSet<CarEquipment> CarEquipment { get; set; }
        public DbSet<CarFuel> CarFuels { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarStatus> CarStatuses { get; set; }
        public DbSet<CarTransmission> CarTransmissions { get; set; }
        public DbSet<CarYear> CarYears { get; set; }
        public DbSet<EnterpriseUser> EnterpriseUsers { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<ModeratorType> ModeratorTypes { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PrivateUser> PrivateUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<WatchedAnnoucement> WatchedAnnoucements { get; set; }
        public DbSet<WatchedUser> WatchedUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User
            setFieldsOfUser(modelBuilder);
            setFieldsOfPrivateUser(modelBuilder);
            setFieldsOfEnterpriseUser(modelBuilder);
            setFieldsOfPhone(modelBuilder);
            setFieldsOfUserType(modelBuilder);
            setFieldsOfWatchedUser(modelBuilder);

            //Moderator
            setFieldsOfModerator(modelBuilder);
            setFieldsOfModeratorType(modelBuilder);

            //Car
            setFieldsOfCarTransmission(modelBuilder);
            setFieldsOfCarDrive(modelBuilder);
            setFieldsOfCarFuel(modelBuilder);
            setFieldsOfCarCountry(modelBuilder);
            setFieldsOfCarBodywork(modelBuilder);
            setFieldsOfCarColor(modelBuilder);
            setFieldsOfCarClass(modelBuilder);
            setFieldsOfCarBrand(modelBuilder);
            setFieldsOfCarModel(modelBuilder);
            setFieldsOfCarEquipment(modelBuilder);
            setFieldsOfCarStatus(modelBuilder);

            //Annoucement
            setFieldsOfAnnoucement(modelBuilder);
            setFieldsOfAnnoucementStatus(modelBuilder);
            setFieldsOfAnnoucement_CarStatus(modelBuilder);
            setFieldsOfWatchedAnnoucement(modelBuilder);
            
        }

        private static void setFieldsOfAnnoucement_CarStatus(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Annoucement_CarStatus>()
                .HasOne(e => e.Annoucement)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Annoucement_CarStatus>()
               .HasOne(e => e.CarStatus)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);
        }

        private static void setFieldsOfWatchedAnnoucement(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WatchedAnnoucement>()
                .Property(e => e.Date)
                .IsRequired();

            modelBuilder.Entity<WatchedAnnoucement>()
                .HasOne(e => e.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            
        }

        private static void setFieldsOfAnnoucement(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Annoucement>()
                            .Property(e => e.CarBrandSpare)
                            .HasMaxLength(45);

            modelBuilder.Entity<Annoucement>()
                .Property(e => e.CarModelSpare)
                .HasMaxLength(45);

            modelBuilder.Entity<Annoucement>()
                .Property(e => e.CarColorSpare)
                .HasMaxLength(45);

            modelBuilder.Entity<Annoucement>()
                .Property(e => e.CarTransmissionSpare)
                .HasMaxLength(45);

            modelBuilder.Entity<Annoucement>()
                .Property(e => e.Description)
                .HasMaxLength(511);
        }

        private static void setFieldsOfCarStatus(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarStatus>()
                            .Property(e => e.Name)
                            .IsRequired()
                            .HasMaxLength(45);

            modelBuilder.Entity<CarStatus>()
               .Property(e => e.Description)
               .HasMaxLength(255);
        }

        private static void setFieldsOfCarEquipment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarEquipment>()
                            .Property(e => e.Name)
                            .IsRequired()
                            .HasMaxLength(255);

            modelBuilder.Entity<CarEquipment>()
               .Property(e => e.Description)
               .HasMaxLength(255);
        }

        private static void setFieldsOfCarModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>()
                            .Property(e => e.Name)
                            .IsRequired()
                            .HasMaxLength(45);
        }

        private static void setFieldsOfCarBrand(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarBrand>()
                            .Property(e => e.Name)
                            .IsRequired()
                            .HasMaxLength(45);
        }

        private static void setFieldsOfCarClass(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarClass>()
                           .Property(e => e.Name)
                           .IsRequired()
                           .HasMaxLength(3);

            modelBuilder.Entity<CarClass>()
               .Property(e => e.Name)
               .HasMaxLength(255);
        }

        private static void setFieldsOfCarColor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarBodywork>()
                           .Property(e => e.Name)
                           .IsRequired()
                           .HasMaxLength(45);
        }

        private static void setFieldsOfCarBodywork(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarBodywork>()
                           .Property(e => e.Name)
                           .IsRequired()
                           .HasMaxLength(45);

            modelBuilder.Entity<CarBodywork>()
               .Property(e => e.Link)
               .HasMaxLength(255);
        }

        private static void setFieldsOfCarCountry(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarCountry>()
               .Property(e => e.Name)
               .IsRequired()
               .HasMaxLength(255);

            modelBuilder.Entity<CarCountry>()
               .Property(e => e.Acronym)
               .IsRequired()
               .HasMaxLength(10);
        }

        private static void setFieldsOfCarFuel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarFuel>()
                           .Property(e => e.Name)
                           .IsRequired()
                           .HasMaxLength(45);
        }

        private static void setFieldsOfCarDrive(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarDrive>()
                            .Property(e => e.Name)
                            .IsRequired()
                            .HasMaxLength(45);

            modelBuilder.Entity<CarDrive>()
                .Property(e => e.Acronym)
                .HasMaxLength(45);
        }

        private static void setFieldsOfAnnoucementStatus(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnnoucementStatus>()
                            .Property(e => e.Name)
                            .IsRequired()
                            .HasMaxLength(45);

            modelBuilder.Entity<AnnoucementStatus>()
                .Property(e => e.Name)
                .HasMaxLength(255);
        }

        private static void setFieldsOfCarTransmission(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarTransmission>()
                            .Property(e => e.Name)
                            .IsRequired()
                            .HasMaxLength(45);

            modelBuilder.Entity<CarTransmission>()
               .Property(e => e.Description)
               .HasMaxLength(255);
        }

        private static void setFieldsOfModeratorType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModeratorType>()
                            .Property(e => e.Name)
                            .IsRequired()
                            .HasMaxLength(45);

            modelBuilder.Entity<ModeratorType>()
                .Property(e => e.Description)
                .HasMaxLength(255);
        }

        private static void setFieldsOfModerator(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moderator>()
                            .Property(e => e.Login)
                            .IsRequired()
                            .HasMaxLength(45);

            modelBuilder.Entity<Moderator>()
                .Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Moderator>()
                .Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Moderator>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(45);

            modelBuilder.Entity<Moderator>()
                .Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);
        }

        private static void setFieldsOfWatchedUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WatchedUser>()
                .Property(e => e.DateOfStart)
                .IsRequired();

            modelBuilder.Entity<WatchedUser>()
                .HasOne(e => e.Follower)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WatchedUser>()
                .HasOne(e => e.Watched)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void setFieldsOfUserType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserType>()
                            .Property(e => e.Name)
                            .IsRequired()
                            .HasMaxLength(45);

            modelBuilder.Entity<UserType>()
                .Property(e => e.Description)
                .HasMaxLength(255);
        }

        private static void setFieldsOfPhone(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>()
                            .Property(e => e.Number)
                            .IsRequired()
                            .HasMaxLength(11);

            modelBuilder.Entity<Phone>()
                .Property(e => e.Name)
                .HasMaxLength(100);
        }

        private static void setFieldsOfEnterpriseUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnterpriseUser>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<EnterpriseUser>()
                .Property(e => e.City)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<EnterpriseUser>()
                .Property(e => e.Street)
                .HasMaxLength(100);

            modelBuilder.Entity<EnterpriseUser>()
                .Property(e => e.HouseNumber)
                .IsRequired()
                .HasMaxLength(4);

            modelBuilder.Entity<EnterpriseUser>()
                .Property(e => e.ApartmentNumber)
                .HasMaxLength(4);

            modelBuilder.Entity<EnterpriseUser>()
                .Property(e => e.PostalCode)
                .IsRequired()
                .HasMaxLength(5);

            modelBuilder.Entity<EnterpriseUser>()
                .Property(e => e.WebAddress)
                .HasMaxLength(100);
        }

        private static void setFieldsOfPrivateUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrivateUser>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(45);

            modelBuilder.Entity<PrivateUser>()
                .Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(45);

            modelBuilder.Entity<PrivateUser>()
                .Property(e => e.City)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<PrivateUser>()
                .Property(e => e.Street)
                .HasMaxLength(100);

            modelBuilder.Entity<PrivateUser>()
                .Property(e => e.HouseNumber)
                .HasMaxLength(4);

            modelBuilder.Entity<PrivateUser>()
                .Property(e => e.ApartmentNumber)
                .HasMaxLength(4);

            modelBuilder.Entity<PrivateUser>()
                .Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);
        }

        private static void setFieldsOfUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                            .Property(e => e.Login)
                            .IsRequired()
                            .HasMaxLength(45);


            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);
        }

        protected override void OnConfiguring 
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}