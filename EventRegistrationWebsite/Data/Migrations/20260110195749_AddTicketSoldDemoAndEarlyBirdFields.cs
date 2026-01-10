using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventRegistrationWebsite.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketSoldDemoAndEarlyBirdFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DemoViewsOverride",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EarlyBirdEndsOn",
                table: "Events",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EarlyBirdPrice",
                table: "Events",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketsSold",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DemoViewsOverride",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EarlyBirdEndsOn",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EarlyBirdPrice",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TicketsSold",
                table: "Events");
        }
    }
}
