using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class BasketAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_AspNetUsers_UserId",
                table: "Basket");

            migrationBuilder.DropForeignKey(
                name: "FK_basketProducts_Basket_BasketId",
                table: "basketProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Basket",
                table: "Basket");

            migrationBuilder.RenameTable(
                name: "Basket",
                newName: "baskets");

            migrationBuilder.RenameIndex(
                name: "IX_Basket_UserId",
                table: "baskets",
                newName: "IX_baskets_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_baskets",
                table: "baskets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_basketProducts_baskets_BasketId",
                table: "basketProducts",
                column: "BasketId",
                principalTable: "baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_baskets_AspNetUsers_UserId",
                table: "baskets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_basketProducts_baskets_BasketId",
                table: "basketProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_baskets_AspNetUsers_UserId",
                table: "baskets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_baskets",
                table: "baskets");

            migrationBuilder.RenameTable(
                name: "baskets",
                newName: "Basket");

            migrationBuilder.RenameIndex(
                name: "IX_baskets_UserId",
                table: "Basket",
                newName: "IX_Basket_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Basket",
                table: "Basket",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_AspNetUsers_UserId",
                table: "Basket",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_basketProducts_Basket_BasketId",
                table: "basketProducts",
                column: "BasketId",
                principalTable: "Basket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
