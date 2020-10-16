using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class db_module_mall_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                "ShopId",
                "Mall_ProductSpu",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                "TenantId",
                "Mall_ProductSpu",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                "ShopId",
                "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                "TenantId",
                "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                "ShopId",
                "Mall_ProductCategory",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                "TenantId",
                "Mall_ProductCategory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "ShopId",
                "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                "TenantId",
                "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                "ShopId",
                "Mall_ProductSku");

            migrationBuilder.DropColumn(
                "TenantId",
                "Mall_ProductSku");

            migrationBuilder.DropColumn(
                "ShopId",
                "Mall_ProductCategory");

            migrationBuilder.DropColumn(
                "TenantId",
                "Mall_ProductCategory");
        }
    }
}