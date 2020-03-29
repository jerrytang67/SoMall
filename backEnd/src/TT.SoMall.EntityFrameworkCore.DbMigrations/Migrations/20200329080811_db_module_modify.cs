using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class db_module_modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mall_ProductSpu_Mall_ProductCategory_CategoryId",
                table: "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Mall_ProductSpu");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Mall_ProductSpu",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateTimeEnd",
                table: "Mall_ProductSpu",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateTimeStart",
                table: "Mall_ProductSpu",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescCommon",
                table: "Mall_ProductSpu",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LimitBuyCount",
                table: "Mall_ProductSpu",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseNotesCommon",
                table: "Mall_ProductSpu",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoldCount",
                table: "Mall_ProductSpu",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrls",
                table: "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateTimeEnd",
                table: "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateTimeStart",
                table: "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LimitBuyCount",
                table: "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OriginPrice",
                table: "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseNotes",
                table: "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoldCount",
                table: "Mall_ProductSku",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockCount",
                table: "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VipPrice",
                table: "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoImageUrl",
                table: "Mall_ProductCategory",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Mall_MallShops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BussinessHours",
                table: "Mall_MallShops",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Mall_MallShops",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Mall_MallShops",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mall_ProductSpu_Mall_ProductCategory_CategoryId",
                table: "Mall_ProductSpu",
                column: "CategoryId",
                principalTable: "Mall_ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mall_ProductSpu_Mall_ProductCategory_CategoryId",
                table: "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                name: "DateTimeEnd",
                table: "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                name: "DateTimeStart",
                table: "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                name: "DescCommon",
                table: "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                name: "LimitBuyCount",
                table: "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                name: "PurchaseNotesCommon",
                table: "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                name: "SoldCount",
                table: "Mall_ProductSpu");

            migrationBuilder.DropColumn(
                name: "CoverImageUrls",
                table: "Mall_ProductSku");

            migrationBuilder.DropColumn(
                name: "DateTimeEnd",
                table: "Mall_ProductSku");

            migrationBuilder.DropColumn(
                name: "DateTimeStart",
                table: "Mall_ProductSku");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Mall_ProductSku");

            migrationBuilder.DropColumn(
                name: "LimitBuyCount",
                table: "Mall_ProductSku");

            migrationBuilder.DropColumn(
                name: "OriginPrice",
                table: "Mall_ProductSku");

            migrationBuilder.DropColumn(
                name: "PurchaseNotes",
                table: "Mall_ProductSku");

            migrationBuilder.DropColumn(
                name: "SoldCount",
                table: "Mall_ProductSku");

            migrationBuilder.DropColumn(
                name: "StockCount",
                table: "Mall_ProductSku");

            migrationBuilder.DropColumn(
                name: "VipPrice",
                table: "Mall_ProductSku");

            migrationBuilder.DropColumn(
                name: "LogoImageUrl",
                table: "Mall_ProductCategory");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Mall_MallShops");

            migrationBuilder.DropColumn(
                name: "BussinessHours",
                table: "Mall_MallShops");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Mall_MallShops");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Mall_MallShops");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Mall_ProductSpu",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Mall_ProductSpu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mall_ProductSpu_Mall_ProductCategory_CategoryId",
                table: "Mall_ProductSpu",
                column: "CategoryId",
                principalTable: "Mall_ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
