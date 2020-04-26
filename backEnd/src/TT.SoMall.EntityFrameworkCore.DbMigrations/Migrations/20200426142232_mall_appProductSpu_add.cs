using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class mall_appProductSpu_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mall_AppProductSpus",
                columns: table => new
                {
                    AppName = table.Column<string>(maxLength: 64, nullable: false),
                    ProductSpuId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mall_AppProductSpus", x => new { x.AppName, x.ProductSpuId });
                    table.ForeignKey(
                        name: "FK_Mall_AppProductSpus_Mall_ProductSpu_ProductSpuId",
                        column: x => x.ProductSpuId,
                        principalTable: "Mall_ProductSpu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mall_AppProductSpus_ProductSpuId",
                table: "Mall_AppProductSpus",
                column: "ProductSpuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mall_AppProductSpus");
        }
    }
}
