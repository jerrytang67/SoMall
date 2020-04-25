using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class appProductCategory_modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "Mall_AppProductCategory");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Mall_AppProductCategory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Mall_AppProductCategory");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Mall_AppProductCategory");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "Mall_AppProductCategory");
            migrationBuilder.AddColumn<string>(
                name: "AppName",
                table: "Weixin_WechatUserinfos",
                maxLength: 32,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "Mall_AppProductCategory",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Mall_AppProductCategory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Mall_AppProductCategory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Mall_AppProductCategory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "Mall_AppProductCategory",
                type: "uniqueidentifier",
                nullable: true);
            
            migrationBuilder.DropColumn(
                name: "AppName",
                table: "Weixin_WechatUserinfos");
        }
    }
}
