using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicClub.DbCore.Migrations
{
    /// <inheritdoc />
    public partial class CascadeImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acts_Images_ImageId",
                table: "Acts");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Images_ImageId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Lineups_Images_ImageId",
                table: "Lineups");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Images_ImageId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Performances_Images_ImageId",
                table: "Performances");

            migrationBuilder.AddForeignKey(
                name: "FK_Acts_Images_ImageId",
                table: "Acts",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Images_ImageId",
                table: "Artists",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Lineups_Images_ImageId",
                table: "Lineups",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Images_ImageId",
                table: "People",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Performances_Images_ImageId",
                table: "Performances",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acts_Images_ImageId",
                table: "Acts");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Images_ImageId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Lineups_Images_ImageId",
                table: "Lineups");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Images_ImageId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Performances_Images_ImageId",
                table: "Performances");

            migrationBuilder.AddForeignKey(
                name: "FK_Acts_Images_ImageId",
                table: "Acts",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Images_ImageId",
                table: "Artists",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lineups_Images_ImageId",
                table: "Lineups",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Images_ImageId",
                table: "People",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Performances_Images_ImageId",
                table: "Performances",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}
