using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class update_order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Mall_ProductOrderItems");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Mall_ProductOrderItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "Num",
                table: "Mall_ProductOrderItems",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "SkuCoverImageUrl",
                table: "Mall_ProductOrderItems",
                maxLength: 255,
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "AddressLocationAddress",
                table: "Mall_ProductOrders",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Mall_ProductOrderItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Mall_ProductOrderItems");

            migrationBuilder.DropColumn(
                name: "Num",
                table: "Mall_ProductOrderItems");

            migrationBuilder.DropColumn(
                name: "SkuCoverImageUrl",
                table: "Mall_ProductOrderItems");

            migrationBuilder.AddColumn<double>(
                name: "Count",
                table: "Mall_ProductOrderItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
            
            migrationBuilder.DropColumn(
                name: "AddressLocationAddress",
                table: "Mall_ProductOrders");
            
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Mall_ProductOrderItems");
        }
    }
}