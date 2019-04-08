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
    [Migration("20190408161049_initial")]
    partial class initial
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

                    b.Property<string>("UserId");

                    b.HasKey("BluetoothAddress");

                    b.HasIndex("UserId");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("Gaugeter.Api.Jobs.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeviceAddress");

                    b.Property<int>("Duration");

                    b.HasKey("Id");

                    b.ToTable("Job");
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

            modelBuilder.Entity("Gaugeter.Api.Devices.Models.Data.Device", b =>
                {
                    b.HasOne("Gaugeter.Api.Users.Models.Data.User")
                        .WithMany("Devices")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
