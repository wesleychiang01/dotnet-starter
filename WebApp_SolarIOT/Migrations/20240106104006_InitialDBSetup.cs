using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_SolarIOT.Migrations
{
    /// <inheritdoc />
    public partial class InitialDBSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "parameters",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    latitude = table.Column<float>(type: "real", nullable: false),
                    longitude = table.Column<float>(type: "real", nullable: false),
                    accuracy = table.Column<float>(type: "real", nullable: false),
                    solar_volt = table.Column<float>(type: "real", nullable: false),
                    solar_amp = table.Column<float>(type: "real", nullable: false),
                    light_intensity = table.Column<float>(type: "real", nullable: false),
                    temperature = table.Column<float>(type: "real", nullable: false),
                    battery_volt = table.Column<float>(type: "real", nullable: false),
                    battery_amp = table.Column<float>(type: "real", nullable: false),
                    EventProcessedUtcTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameters", x => x.EventID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parameters");
        }
    }
}
