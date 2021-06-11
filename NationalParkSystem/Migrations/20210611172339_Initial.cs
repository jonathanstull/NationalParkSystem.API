using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NationalParkSystem.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NationalParks",
                columns: table => new
                {
                    NationalParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Status = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    LatLong = table.Column<string>(type: "varchar(22) CHARACTER SET utf8mb4", maxLength: 22, nullable: false),
                    State = table.Column<string>(type: "varchar(2) CHARACTER SET utf8mb4", maxLength: 2, nullable: false),
                    Visits = table.Column<int>(type: "int", nullable: false),
                    BusySeason = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Climate = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    RvServices = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Topo = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalParks", x => x.NationalParkId);
                });

            migrationBuilder.CreateTable(
                name: "StateParks",
                columns: table => new
                {
                    StateParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Status = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    LatLong = table.Column<string>(type: "varchar(22) CHARACTER SET utf8mb4", maxLength: 22, nullable: false),
                    State = table.Column<string>(type: "varchar(2) CHARACTER SET utf8mb4", maxLength: 2, nullable: false),
                    Visits = table.Column<int>(type: "int", nullable: false),
                    BusySeason = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Climate = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    RvServices = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Topo = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateParks", x => x.StateParkId);
                });

            migrationBuilder.InsertData(
                table: "NationalParks",
                columns: new[] { "NationalParkId", "BusySeason", "Climate", "LatLong", "Name", "RvServices", "State", "Status", "Topo", "Visits" },
                values: new object[,]
                {
                    { 1, "summer", "6a", "46.275181, -122.217252", "Mount St. Helens National Volcanic Monument", true, "OR", "national monument", null, 750000 },
                    { 2, "spring, summer, fall", "5b", "37.748980, -119.587107", "Yosemite National Park", true, "CA", "national park", null, 4586463 },
                    { 3, "summer", "6b", "39.811800, -77.2255080", "Gettysburg National Military Park", false, "PA", "national military park", null, 950000 },
                    { 4, "all year", "10a", "37.830945, -122.524451", "Golden Gate National Recreation Area", true, "CA", "national recreation area", null, 12400045 },
                    { 5, "summer, fall", "7a", "41.837530, -69.9725160", "Cape Cod National Seashore", false, "MA", "national seashore", null, 5230000 }
                });

            migrationBuilder.InsertData(
                table: "StateParks",
                columns: new[] { "StateParkId", "BusySeason", "Climate", "LatLong", "Name", "RvServices", "State", "Status", "Topo", "Visits" },
                values: new object[,]
                {
                    { 1, "summer", "6a", "44.365863, -121.137339", "Smith Rock Monument", true, "OR", "state monument", null, 324000 },
                    { 2, "spring, summer, fall", "5b", "41.796878, -124.081776", "Jedediah Smith Redwoods State Park", true, "CA", "state park", null, 23363 },
                    { 3, "summer", "6b", "36.998951, -109.045179", "Four Corners Monument", false, "AZ", "Navajo Nation monument", null, 103000 },
                    { 4, "all year", "10a", "29.470494, -103.957694", "Big Bend Ranch State Park", true, "EW", "state park", null, 1970045 },
                    { 5, "summer, fall", "7a", "7.0864070, 171.3736030", "Marshall Islands War Memorial Park", false, "EW", "war memorial", null, 5230000 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NationalParks");

            migrationBuilder.DropTable(
                name: "StateParks");
        }
    }
}
