using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventRegistrationWebsite.Migrations
{
    /// <inheritdoc />
    public partial class AddPackageCoverAndBadge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Badge",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverImagePath",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Badge",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "CoverImagePath",
                table: "Packages");
        }
    }
}
