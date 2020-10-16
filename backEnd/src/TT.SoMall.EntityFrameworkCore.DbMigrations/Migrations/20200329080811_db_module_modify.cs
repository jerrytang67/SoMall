using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class db_module_modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Mall_ProductSpu_Mall_ProductCategory_CategoryId",
                "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                "Desc",
                "Mall_ProductSpu");

            migrationBuilder.AlterColumn<string>(
                "Code",
                "Mall_ProductSpu",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                "DateTimeEnd",
                "Mall_ProductSpu",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                "DateTimeStart",
                "Mall_ProductSpu",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "DescCommon",
                "Mall_ProductSpu",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "LimitBuyCount",
                "Mall_ProductSpu",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "PurchaseNotesCommon",
                "Mall_ProductSpu",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "SoldCount",
                "Mall_ProductSpu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                "CoverImageUrls",
                "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                "DateTimeEnd",
                "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                "DateTimeStart",
                "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "Desc",
                "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "LimitBuyCount",
                "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                "OriginPrice",
                "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "PurchaseNotes",
                "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "SoldCount",
                "Mall_ProductSku",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "StockCount",
                "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                "VipPrice",
                "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "LogoImageUrl",
                "Mall_ProductCategory",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "Address",
                "Mall_MallShops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "BussinessHours",
                "Mall_MallShops",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                "Lat",
                "Mall_MallShops",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                "Lng",
                "Mall_MallShops",
                nullable: true);

            migrationBuilder.AddForeignKey(
                "FK_Mall_ProductSpu_Mall_ProductCategory_CategoryId",
                "Mall_ProductSpu",
                "CategoryId",
                "Mall_ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddColumn<string>(
                "Unit",
                "Mall_ProductSku",
                maxLength: 16,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Mall_ProductSpu_Mall_ProductCategory_CategoryId",
                "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                "DateTimeEnd",
                "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                "DateTimeStart",
                "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                "DescCommon",
                "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                "LimitBuyCount",
                "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                "PurchaseNotesCommon",
                "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                "SoldCount",
                "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                "CoverImageUrls",
                "Mall_ProductSku");

            migrationBuilder.DropColumn(
                "DateTimeEnd",
                "Mall_ProductSku");

            migrationBuilder.DropColumn(
                "DateTimeStart",
                "Mall_ProductSku");

            migrationBuilder.DropColumn(
                "Desc",
                "Mall_ProductSku");

            migrationBuilder.DropColumn(
                "LimitBuyCount",
                "Mall_ProductSku");

            migrationBuilder.DropColumn(
                "OriginPrice",
                "Mall_ProductSku");

            migrationBuilder.DropColumn(
                "PurchaseNotes",
                "Mall_ProductSku");

            migrationBuilder.DropColumn(
                "SoldCount",
                "Mall_ProductSku");

            migrationBuilder.DropColumn(
                "StockCount",
                "Mall_ProductSku");

            migrationBuilder.DropColumn(
                "VipPrice",
                "Mall_ProductSku");

            migrationBuilder.DropColumn(
                "LogoImageUrl",
                "Mall_ProductCategory");

            migrationBuilder.DropColumn(
                "Address",
                "Mall_MallShops");

            migrationBuilder.DropColumn(
                "BussinessHours",
                "Mall_MallShops");

            migrationBuilder.DropColumn(
                "Lat",
                "Mall_MallShops");

            migrationBuilder.DropColumn(
                "Lng",
                "Mall_MallShops");

            migrationBuilder.AlterColumn<string>(
                "Code",
                "Mall_ProductSpu",
                "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AddColumn<string>(
                "Desc",
                "Mall_ProductSpu",
                "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                "FK_Mall_ProductSpu_Mall_ProductCategory_CategoryId",
                "Mall_ProductSpu",
                "CategoryId",
                "Mall_ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.DropColumn(
                "Unit",
                "Mall_ProductSku");
        }
    }
}