using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class update_order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Count",
                "Mall_ProductOrderItems");

            migrationBuilder.AddColumn<decimal>(
                "Discount",
                "Mall_ProductOrderItems",
                "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                "Num",
                "Mall_ProductOrderItems",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                "SkuCoverImageUrl",
                "Mall_ProductOrderItems",
                maxLength: 255,
                nullable: true);
            migrationBuilder.AddColumn<string>(
                "AddressLocationAddress",
                "Mall_ProductOrders",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                "TenantId",
                "Mall_ProductOrderItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Discount",
                "Mall_ProductOrderItems");

            migrationBuilder.DropColumn(
                "Num",
                "Mall_ProductOrderItems");

            migrationBuilder.DropColumn(
                "SkuCoverImageUrl",
                "Mall_ProductOrderItems");

            migrationBuilder.AddColumn<double>(
                "Count",
                "Mall_ProductOrderItems",
                "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.DropColumn(
                "AddressLocationAddress",
                "Mall_ProductOrders");

            migrationBuilder.DropColumn(
                "TenantId",
                "Mall_ProductOrderItems");
        }
    }
}