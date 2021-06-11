﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NationalParkSystem.Models;

namespace NationalParkSystem.Migrations
{
    [DbContext(typeof(NationalParkSystemContext))]
    partial class NationalParkSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("NationalParkSystem.Models.NationalPark", b =>
                {
                    b.Property<int>("NationalParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BusySeason")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Climate")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LatLong")
                        .IsRequired()
                        .HasMaxLength(22)
                        .HasColumnType("varchar(22) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("RvServices")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2) CHARACTER SET utf8mb4");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<byte[]>("Topo")
                        .HasColumnType("longblob");

                    b.Property<int>("Visits")
                        .HasColumnType("int");

                    b.HasKey("NationalParkId");

                    b.ToTable("NationalParks");

                    b.HasData(
                        new
                        {
                            NationalParkId = 1,
                            BusySeason = "summer",
                            Climate = "6a",
                            LatLong = "46.275181, -122.217252",
                            Name = "Mount St. Helens National Volcanic Monument",
                            RvServices = true,
                            State = "OR",
                            Status = "national monument",
                            Visits = 750000
                        },
                        new
                        {
                            NationalParkId = 2,
                            BusySeason = "spring, summer, fall",
                            Climate = "5b",
                            LatLong = "37.748980, -119.587107",
                            Name = "Yosemite National Park",
                            RvServices = true,
                            State = "CA",
                            Status = "national park",
                            Visits = 4586463
                        },
                        new
                        {
                            NationalParkId = 3,
                            BusySeason = "summer",
                            Climate = "6b",
                            LatLong = "39.811800, -77.2255080",
                            Name = "Gettysburg National Military Park",
                            RvServices = false,
                            State = "PA",
                            Status = "national military park",
                            Visits = 950000
                        },
                        new
                        {
                            NationalParkId = 4,
                            BusySeason = "all year",
                            Climate = "10a",
                            LatLong = "37.830945, -122.524451",
                            Name = "Golden Gate National Recreation Area",
                            RvServices = true,
                            State = "CA",
                            Status = "national recreation area",
                            Visits = 12400045
                        },
                        new
                        {
                            NationalParkId = 5,
                            BusySeason = "summer, fall",
                            Climate = "7a",
                            LatLong = "41.837530, -69.9725160",
                            Name = "Cape Cod National Seashore",
                            RvServices = false,
                            State = "MA",
                            Status = "national seashore",
                            Visits = 5230000
                        });
                });

            modelBuilder.Entity("NationalParkSystem.Models.StatePark", b =>
                {
                    b.Property<int>("StateParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BusySeason")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Climate")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LatLong")
                        .IsRequired()
                        .HasMaxLength(22)
                        .HasColumnType("varchar(22) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("RvServices")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2) CHARACTER SET utf8mb4");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<byte[]>("Topo")
                        .HasColumnType("longblob");

                    b.Property<int>("Visits")
                        .HasColumnType("int");

                    b.HasKey("StateParkId");

                    b.ToTable("StateParks");

                    b.HasData(
                        new
                        {
                            StateParkId = 1,
                            BusySeason = "summer",
                            Climate = "6a",
                            LatLong = "44.365863, -121.137339",
                            Name = "Smith Rock Monument",
                            RvServices = true,
                            State = "OR",
                            Status = "state monument",
                            Visits = 324000
                        },
                        new
                        {
                            StateParkId = 2,
                            BusySeason = "spring, summer, fall",
                            Climate = "5b",
                            LatLong = "41.796878, -124.081776",
                            Name = "Jedediah Smith Redwoods State Park",
                            RvServices = true,
                            State = "CA",
                            Status = "state park",
                            Visits = 23363
                        },
                        new
                        {
                            StateParkId = 3,
                            BusySeason = "summer",
                            Climate = "6b",
                            LatLong = "36.998951, -109.045179",
                            Name = "Four Corners Monument",
                            RvServices = false,
                            State = "AZ",
                            Status = "Navajo Nation monument",
                            Visits = 103000
                        },
                        new
                        {
                            StateParkId = 4,
                            BusySeason = "all year",
                            Climate = "10a",
                            LatLong = "29.470494, -103.957694",
                            Name = "Big Bend Ranch State Park",
                            RvServices = true,
                            State = "EW",
                            Status = "state park",
                            Visits = 1970045
                        },
                        new
                        {
                            StateParkId = 5,
                            BusySeason = "summer, fall",
                            Climate = "7a",
                            LatLong = "7.0864070, 171.3736030",
                            Name = "Marshall Islands War Memorial Park",
                            RvServices = false,
                            State = "EW",
                            Status = "war memorial",
                            Visits = 5230000
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
