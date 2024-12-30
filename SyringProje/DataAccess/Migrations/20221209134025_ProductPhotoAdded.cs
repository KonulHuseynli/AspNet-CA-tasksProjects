using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ProductPhotoAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPhoto_Products_ProductId",
                table: "ProductPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPhoto",
                table: "ProductPhoto");

            migrationBuilder.RenameTable(
                name: "ProductPhoto",
                newName: "productphotos");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPhoto_ProductId",
                table: "productphotos",
                newName: "IX_productphotos_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productphotos",
                table: "productphotos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_productphotos_Products_ProductId",
                table: "productphotos",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productphotos_Products_ProductId",
                table: "productphotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productphotos",
                table: "productphotos");

            migrationBuilder.RenameTable(
                name: "productphotos",
                newName: "ProductPhoto");

            migrationBuilder.RenameIndex(
                name: "IX_productphotos_ProductId",
                table: "ProductPhoto",
                newName: "IX_ProductPhoto_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPhoto",
                table: "ProductPhoto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPhoto_Products_ProductId",
                table: "ProductPhoto",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
