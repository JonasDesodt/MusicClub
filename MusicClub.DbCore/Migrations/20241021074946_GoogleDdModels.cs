using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicClub.DbCore.Migrations
{
    /// <inheritdoc />
    public partial class GoogleDdModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Acts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GoogleEventId",
                table: "Acts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GoogleCalendars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoogleIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoogleCalendars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoogleEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoogleIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GoogleCalendarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoogleEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoogleEvents_GoogleCalendars_GoogleCalendarId",
                        column: x => x.GoogleCalendarId,
                        principalTable: "GoogleCalendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acts_GoogleEventId",
                table: "Acts",
                column: "GoogleEventId",
                unique: true,
                filter: "[GoogleEventId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GoogleEvents_GoogleCalendarId",
                table: "GoogleEvents",
                column: "GoogleCalendarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acts_GoogleEvents_GoogleEventId",
                table: "Acts",
                column: "GoogleEventId",
                principalTable: "GoogleEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acts_GoogleEvents_GoogleEventId",
                table: "Acts");

            migrationBuilder.DropTable(
                name: "GoogleEvents");

            migrationBuilder.DropTable(
                name: "GoogleCalendars");

            migrationBuilder.DropIndex(
                name: "IX_Acts_GoogleEventId",
                table: "Acts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Acts");

            migrationBuilder.DropColumn(
                name: "GoogleEventId",
                table: "Acts");
        }
    }
}
