using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkSpaceWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 13, 12, 7, 978, DateTimeKind.Utc).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "ContactMessages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 13, 12, 7, 978, DateTimeKind.Utc).AddTicks(9501));

            migrationBuilder.InsertData(
                table: "MembershipPlans",
                columns: new[] { "Id", "Description", "DurationInDays", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Need a desk from time to time? Or a central spot to host meetings? We got ya!", 30, "Flex Desk", 300 },
                    { 2, "Bring your screens and get tucked in. This desk is yours and only yours!", 65, "Fixed Desk", 350 },
                    { 3, "A home for your business or a space to jam with your team? Room for 6!", 40, "Enterprise", 1800 },
                    { 4, "In town for a couple of days to meet your remote team? Book for up to 8 pax!", 7, "Meeting Room", 150 },
                    { 5, "Just you? €25/day gets you a desk and access to all our amenities.", 1, "Day Pass", 25 },
                    { 6, "Trying out Lisbon? €140 gets you access Monday through Sunday.", 7, "Week Pass", 140 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MembershipPlans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MembershipPlans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MembershipPlans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MembershipPlans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MembershipPlans",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MembershipPlans",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "ContactMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 12, 53, 49, 8, DateTimeKind.Utc).AddTicks(3302));

            migrationBuilder.UpdateData(
                table: "ContactMessages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 23, 12, 53, 49, 8, DateTimeKind.Utc).AddTicks(3306));
        }
    }
}
