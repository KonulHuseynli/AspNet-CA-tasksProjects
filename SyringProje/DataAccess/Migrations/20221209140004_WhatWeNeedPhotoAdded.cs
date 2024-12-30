using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class WhatWeNeedPhotoAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WhatsWeDoBestPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    WhatNeedId = table.Column<int>(type: "int", nullable: false),
                    WhatWeDoBestId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatsWeDoBestPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhatsWeDoBestPhotos_WhatsWeDoBests_WhatWeDoBestId",
                        column: x => x.WhatWeDoBestId,
                        principalTable: "WhatsWeDoBests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WhatsWeDoBestPhotos_WhatWeDoBestId",
                table: "WhatsWeDoBestPhotos",
                column: "WhatWeDoBestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WhatsWeDoBestPhotos");
        }
    }
}
