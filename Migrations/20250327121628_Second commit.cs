using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlrightAPI.Migrations
{
    /// <inheritdoc />
    public partial class Secondcommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Students",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "FirstName");
        }
    }
}
