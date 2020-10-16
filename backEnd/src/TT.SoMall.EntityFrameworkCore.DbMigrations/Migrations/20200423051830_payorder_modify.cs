using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class payorder_modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromClient",
                table: "Mall_PayOrders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Mall_PayOrders");

            migrationBuilder.AddColumn<Guid>(
                name: "PayOrderId",
                table: "Mall_ProductOrders",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OpenId",
                table: "Mall_PayOrders",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MchId",
                table: "Mall_PayOrders",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillNo",
                table: "Mall_PayOrders",
                maxLength: 48,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(48)",
                oldMaxLength: 48,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppName",
                table: "Mall_PayOrders",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "App_Apps",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);
            migrationBuilder.AddColumn<string>(
                name: "BillNo",
                table: "Mall_ProductOrders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayOrderId",
                table: "Mall_ProductOrders");

            migrationBuilder.DropColumn(
                name: "AppName",
                table: "Mall_PayOrders");

            migrationBuilder.AlterColumn<string>(
                name: "OpenId",
                table: "Mall_PayOrders",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "MchId",
                table: "Mall_PayOrders",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "BillNo",
                table: "Mall_PayOrders",
                type: "nvarchar(48)",
                maxLength: 48,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 48);

            migrationBuilder.AddColumn<string>(
                name: "FromClient",
                table: "Mall_PayOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Mall_PayOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "App_Apps",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2,
                oldNullable: true);
            
            migrationBuilder.DropColumn(
                name: "BillNo",
                table: "Mall_ProductOrders");
        }
    }
}
