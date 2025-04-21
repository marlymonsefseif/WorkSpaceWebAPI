using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkSpaceWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvailableFrom = table.Column<TimeSpan>(type: "time", nullable: false),
                    AvailableTo = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    SpaceType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaces", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Spaces",
                columns: new[] { "Id", "AvailableFrom", "AvailableTo", "Capacity", "Description", "IsAvailable", "Name", "PricePerHour", "SpaceType" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 16, 0, 0, 0), 50, "Room To Study", true, "StudyRoom 1", 20m, 0 },
                    { 2, new TimeSpan(0, 9, 0, 0, 0), new TimeSpan(0, 17, 0, 0, 0), 30, "Lab for practice", true, "ITI Lab", 25m, 3 },
                    { 3, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 14, 0, 0, 0), 10, "Team meetings", false, "Meeting Room A", 15m, 1 },
                    { 4, new TimeSpan(0, 9, 0, 0, 0), new TimeSpan(0, 18, 0, 0, 0), 100, "Events and workshops", true, "Workshop Hall", 50m, 2 },
                    { 5, new TimeSpan(0, 7, 0, 0, 0), new TimeSpan(0, 22, 0, 0, 0), 20, "For focused study", true, "Silent Study Room", 10m, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spaces");
        }
    }
}
