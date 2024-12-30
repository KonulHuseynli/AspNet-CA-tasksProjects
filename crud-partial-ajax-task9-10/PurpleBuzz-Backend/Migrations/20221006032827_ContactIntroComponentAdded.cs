using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurpleBuzz_Backend.Migrations
{
    public partial class ContactIntroComponentAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_recentWorkComponents",
                table: "recentWorkComponents");

            migrationBuilder.RenameTable(
                name: "recentWorkComponents",
                newName: "RecentWorkComponents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecentWorkComponents",
                table: "RecentWorkComponents",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ContactIntroComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactIntroComponent", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactIntroComponent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecentWorkComponents",
                table: "RecentWorkComponents");

            migrationBuilder.RenameTable(
                name: "RecentWorkComponents",
                newName: "recentWorkComponents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_recentWorkComponents",
                table: "recentWorkComponents",
                column: "Id");
        }
    }
}
