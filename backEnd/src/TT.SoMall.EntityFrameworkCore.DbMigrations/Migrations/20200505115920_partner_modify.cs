using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class partner_modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "HeadImageUrl",
                "Mall_Partners");

            migrationBuilder.DropColumn(
                "Nickname",
                "Mall_Partners");

            migrationBuilder.DropColumn(
                "UpdateDate",
                "Mall_Partners");

            migrationBuilder.DropColumn(
                "openid",
                "Mall_PartnerDetails");

            migrationBuilder.DropColumn(
                "unionid",
                "Mall_PartnerDetails");

            migrationBuilder.DropColumn(
                "PhoneBackup",
                "Account_RealNameInfos");

            migrationBuilder.AlterColumn<string>(
                "Phone",
                "Mall_Partners",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                "LocationLabel",
                "Mall_Partners",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "LocationAddress",
                "Mall_Partners",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                "HeadImgUrl",
                "Mall_Partners",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "LocationType",
                "Mall_Partners",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                "PhoneBackup",
                "Mall_Partners",
                maxLength: 16,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "HeadImgUrl",
                "Mall_Partners");

            migrationBuilder.DropColumn(
                "LocationType",
                "Mall_Partners");

            migrationBuilder.DropColumn(
                "PhoneBackup",
                "Mall_Partners");

            migrationBuilder.AlterColumn<string>(
                "Phone",
                "Mall_Partners",
                "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                "LocationLabel",
                "Mall_Partners",
                "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "LocationAddress",
                "Mall_Partners",
                "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                "HeadImageUrl",
                "Mall_Partners",
                "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "Nickname",
                "Mall_Partners",
                "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                "UpdateDate",
                "Mall_Partners",
                "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                "openid",
                "Mall_PartnerDetails",
                "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "unionid",
                "Mall_PartnerDetails",
                "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "PhoneBackup",
                "Account_RealNameInfos",
                "nvarchar(64)",
                maxLength: 64,
                nullable: true);
        }
    }
}