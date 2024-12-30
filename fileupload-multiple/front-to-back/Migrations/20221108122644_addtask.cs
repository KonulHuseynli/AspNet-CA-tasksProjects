using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace front_to_back.Migrations
{
    public partial class addtask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeaturedWorkComponentPhotos_featuredWorkComponent_FeaturedWorkComponentId",
                table: "FeaturedWorkComponentPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_featuredWorkComponent",
                table: "featuredWorkComponent");

            migrationBuilder.RenameTable(
                name: "featuredWorkComponent",
                newName: "FeaturedWorkComponent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeaturedWorkComponent",
                table: "FeaturedWorkComponent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturedWorkComponentPhotos_FeaturedWorkComponent_FeaturedWorkComponentId",
                table: "FeaturedWorkComponentPhotos",
                column: "FeaturedWorkComponentId",
                principalTable: "FeaturedWorkComponent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeaturedWorkComponentPhotos_FeaturedWorkComponent_FeaturedWorkComponentId",
                table: "FeaturedWorkComponentPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeaturedWorkComponent",
                table: "FeaturedWorkComponent");

            migrationBuilder.RenameTable(
                name: "FeaturedWorkComponent",
                newName: "featuredWorkComponent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_featuredWorkComponent",
                table: "featuredWorkComponent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturedWorkComponentPhotos_featuredWorkComponent_FeaturedWorkComponentId",
                table: "FeaturedWorkComponentPhotos",
                column: "FeaturedWorkComponentId",
                principalTable: "featuredWorkComponent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
