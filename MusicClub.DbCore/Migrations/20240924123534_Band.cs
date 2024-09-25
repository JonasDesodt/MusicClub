using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicClub.DbCore.Migrations
{
    /// <inheritdoc />
    public partial class Band : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BandnameId",
                table: "Performances",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Acts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Acts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bandnames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    BandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bandnames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bandnames_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bandnames_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Performances_BandnameId",
                table: "Performances",
                column: "BandnameId");

            migrationBuilder.CreateIndex(
                name: "IX_Bandnames_BandId",
                table: "Bandnames",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_Bandnames_ImageId",
                table: "Bandnames",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Performances_Bandnames_BandnameId",
                table: "Performances",
                column: "BandnameId",
                principalTable: "Bandnames",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performances_Bandnames_BandnameId",
                table: "Performances");

            migrationBuilder.DropTable(
                name: "Bandnames");

            migrationBuilder.DropTable(
                name: "Bands");

            migrationBuilder.DropIndex(
                name: "IX_Performances_BandnameId",
                table: "Performances");

            migrationBuilder.DropColumn(
                name: "BandnameId",
                table: "Performances");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Acts");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Acts");
        }
    }
}
