using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSpaceWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CompositKeySpaceAmenity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SpaceAmenities",
                table: "SpaceAmenities");

            migrationBuilder.DropIndex(
                name: "IX_SpaceAmenities_SpaceId",
                table: "SpaceAmenities");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SpaceAmenities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpaceAmenities",
                table: "SpaceAmenities",
                columns: new[] { "SpaceId", "AmenityId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SpaceAmenities",
                table: "SpaceAmenities");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SpaceAmenities",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpaceAmenities",
                table: "SpaceAmenities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceAmenities_SpaceId",
                table: "SpaceAmenities",
                column: "SpaceId");
        }
    }
}
