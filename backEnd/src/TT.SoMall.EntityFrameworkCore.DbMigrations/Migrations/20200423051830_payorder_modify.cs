using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class payorder_modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "FromClient",
                "Mall_PayOrders");

            migrationBuilder.DropColumn(
                "OrderId",
                "Mall_PayOrders");

            migrationBuilder.AddColumn<Guid>(
                "PayOrderId",
                "Mall_ProductOrders",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                "OpenId",
                "Mall_PayOrders",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "MchId",
                "Mall_PayOrders",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "BillNo",
                "Mall_PayOrders",
                maxLength: 48,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(48)",
                oldMaxLength: 48,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                "AppName",
                "Mall_PayOrders",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                "ProviderKey",
                "App_Apps",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);
            migrationBuilder.AddColumn<string>(
                "BillNo",
                "Mall_ProductOrders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "PayOrderId",
                "Mall_ProductOrders");

            migrationBuilder.DropColumn(
                "AppName",
                "Mall_PayOrders");

            migrationBuilder.AlterColumn<string>(
                "OpenId",
                "Mall_PayOrders",
                "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                "MchId",
                "Mall_PayOrders",
                "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                "BillNo",
                "Mall_PayOrders",
                "nvarchar(48)",
                maxLength: 48,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 48);

            migrationBuilder.AddColumn<string>(
                "FromClient",
                "Mall_PayOrders",
                "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                "OrderId",
                "Mall_PayOrders",
                "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                "ProviderKey",
                "App_Apps",
                "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.DropColumn(
                "BillNo",
                "Mall_ProductOrders");
        }
    }
}