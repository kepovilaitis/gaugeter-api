﻿// <auto-generated />
using System;
using Gaugeter.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gaugeter.Api.Migrations
{
    [DbContext(typeof(GaugeterDbContext))]
    [Migration("20190502105414_addedJobs")]
    partial class addedJobs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gaugeter.Api.Authentication.Models.Data.ActiveToken", b =>
                {
                    b.Property<string>("Token")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<string>("RefreshToken");

                    b.Property<string>("UserId");

                    b.HasKey("Token");

                    b.ToTable("ActiveToken");
                });

            modelBuilder.Entity("Gaugeter.Api.Devices.Models.Data.Device", b =>
                {
                    b.Property<string>("BluetoothAddress")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(18);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("BluetoothAddress");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("Gaugeter.Api.Jobs.Models.Data.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("DateCreated");

                    b.Property<long>("DateUpdated");

                    b.Property<string>("DeviceBluetoothAddress");

                    b.Property<int>("State");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DeviceBluetoothAddress");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("Gaugeter.Api.Jobs.Models.Data.TelemData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Charge");

                    b.Property<int?>("JobId");

                    b.Property<float>("OilPressure");

                    b.Property<float>("OilTemperature");

                    b.Property<float>("WaterTemperature");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("TelemData");
                });

            modelBuilder.Entity("Gaugeter.Api.Users.Models.Data.User", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20);

                    b.Property<string>("Description");

                    b.Property<int>("MeasurementSystem");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Gaugeter.Api.Users.Models.Data.UserDevice", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("BluetoothAddress");

                    b.HasKey("UserId", "BluetoothAddress");

                    b.HasIndex("BluetoothAddress");

                    b.ToTable("UserDevice");
                });

            modelBuilder.Entity("Gaugeter.Api.Jobs.Models.Data.Job", b =>
                {
                    b.HasOne("Gaugeter.Api.Devices.Models.Data.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceBluetoothAddress");
                });

            modelBuilder.Entity("Gaugeter.Api.Jobs.Models.Data.TelemData", b =>
                {
                    b.HasOne("Gaugeter.Api.Jobs.Models.Data.Job")
                        .WithMany("Telem")
                        .HasForeignKey("JobId");
                });

            modelBuilder.Entity("Gaugeter.Api.Users.Models.Data.UserDevice", b =>
                {
                    b.HasOne("Gaugeter.Api.Devices.Models.Data.Device", "Device")
                        .WithMany("Users")
                        .HasForeignKey("BluetoothAddress")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Gaugeter.Api.Users.Models.Data.User", "User")
                        .WithMany("Devices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
