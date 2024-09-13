using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicClub.DbCore.Migrations
{
    /// <inheritdoc />
    public partial class Alias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Artists");
        }
    }
}
