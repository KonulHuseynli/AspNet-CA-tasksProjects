using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace front_to_back.Migrations
{
    public partial class FeaturedWorkComponentAndPhotosAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "featuredWorkComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_featuredWorkComponent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeaturedWorkComponentPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    FeaturedWorkComponentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturedWorkComponentPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeaturedWorkComponentPhotos_featuredWorkComponent_FeaturedWorkComponentId",
                        column: x => x.FeaturedWorkComponentId,
                        principalTable: "featuredWorkComponent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedWorkComponentPhotos_FeaturedWorkComponentId",
                table: "FeaturedWorkComponentPhotos",
                column: "FeaturedWorkComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeaturedWorkComponentPhotos");

            migrationBuilder.DropTable(
                name: "featuredWorkComponent");
        }
    }
}
