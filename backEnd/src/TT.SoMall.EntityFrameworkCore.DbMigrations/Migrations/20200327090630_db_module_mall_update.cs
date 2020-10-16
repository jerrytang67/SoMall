using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class db_module_mall_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ShopId",
                table: "Mall_ProductSpu",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Mall_ProductSpu",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShopId",
                table: "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShopId",
                table: "Mall_ProductCategory",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Mall_ProductCategory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Mall_ProductSku");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Mall_ProductSku");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Mall_ProductCategory");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Mall_ProductCategory");
        }
    }
}
