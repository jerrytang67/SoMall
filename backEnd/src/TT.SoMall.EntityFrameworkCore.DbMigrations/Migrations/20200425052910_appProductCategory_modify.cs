using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class appProductCategory_modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "DeleterId",
                "Mall_AppProductCategory");

            migrationBuilder.DropColumn(
                "DeletionTime",
                "Mall_AppProductCategory");

            migrationBuilder.DropColumn(
                "IsDeleted",
                "Mall_AppProductCategory");

            migrationBuilder.DropColumn(
                "LastModificationTime",
                "Mall_AppProductCategory");

            migrationBuilder.DropColumn(
                "LastModifierId",
                "Mall_AppProductCategory");
            migrationBuilder.AddColumn<string>(
                "AppName",
                "Weixin_WechatUserinfos",
                maxLength: 32,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                "DeleterId",
                "Mall_AppProductCategory",
                "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                "DeletionTime",
                "Mall_AppProductCategory",
                "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                "IsDeleted",
                "Mall_AppProductCategory",
                "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                "LastModificationTime",
                "Mall_AppProductCategory",
                "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                "LastModifierId",
                "Mall_AppProductCategory",
                "uniqueidentifier",
                nullable: true);

            migrationBuilder.DropColumn(
                "AppName",
                "Weixin_WechatUserinfos");
        }
    }
}