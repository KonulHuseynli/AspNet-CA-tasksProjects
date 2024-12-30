using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class HomeSliderPhotosAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_homeMainSlidersPhoto_homeMainSliders_HomeMainSliderId",
                table: "homeMainSlidersPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_homeMainSlidersPhoto",
                table: "homeMainSlidersPhoto");

            migrationBuilder.RenameTable(
                name: "homeMainSlidersPhoto",
                newName: "homeMainSliderPhotos");

            migrationBuilder.RenameIndex(
                name: "IX_homeMainSlidersPhoto_HomeMainSliderId",
                table: "homeMainSliderPhotos",
                newName: "IX_homeMainSliderPhotos_HomeMainSliderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_homeMainSliderPhotos",
                table: "homeMainSliderPhotos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_homeMainSliderPhotos_homeMainSliders_HomeMainSliderId",
                table: "homeMainSliderPhotos",
                column: "HomeMainSliderId",
                principalTable: "homeMainSliders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_homeMainSliderPhotos_homeMainSliders_HomeMainSliderId",
                table: "homeMainSliderPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_homeMainSliderPhotos",
                table: "homeMainSliderPhotos");

            migrationBuilder.RenameTable(
                name: "homeMainSliderPhotos",
                newName: "homeMainSlidersPhoto");

            migrationBuilder.RenameIndex(
                name: "IX_homeMainSliderPhotos_HomeMainSliderId",
                table: "homeMainSlidersPhoto",
                newName: "IX_homeMainSlidersPhoto_HomeMainSliderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_homeMainSlidersPhoto",
                table: "homeMainSlidersPhoto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_homeMainSlidersPhoto_homeMainSliders_HomeMainSliderId",
                table: "homeMainSlidersPhoto",
                column: "HomeMainSliderId",
                principalTable: "homeMainSliders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
