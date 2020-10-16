using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class mall_appProductSpu_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Mall_AppProductSpus",
                table => new
                {
                    AppName = table.Column<string>(maxLength: 64, nullable: false),
                    ProductSpuId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mall_AppProductSpus", x => new {x.AppName, x.ProductSpuId});
                    table.ForeignKey(
                        "FK_Mall_AppProductSpus_Mall_ProductSpu_ProductSpuId",
                        x => x.ProductSpuId,
                        "Mall_ProductSpu",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Mall_AppProductSpus_ProductSpuId",
                "Mall_AppProductSpus",
                "ProductSpuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Mall_AppProductSpus");
        }
    }
}