using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class partner_modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadImageUrl",
                table: "Mall_Partners");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "Mall_Partners");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Mall_Partners");

            migrationBuilder.DropColumn(
                name: "openid",
                table: "Mall_PartnerDetails");

            migrationBuilder.DropColumn(
                name: "unionid",
                table: "Mall_PartnerDetails");

            migrationBuilder.DropColumn(
                name: "PhoneBackup",
                table: "Account_RealNameInfos");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Mall_Partners",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "LocationLabel",
                table: "Mall_Partners",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LocationAddress",
                table: "Mall_Partners",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeadImgUrl",
                table: "Mall_Partners",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationType",
                table: "Mall_Partners",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneBackup",
                table: "Mall_Partners",
                maxLength: 16,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadImgUrl",
                table: "Mall_Partners");

            migrationBuilder.DropColumn(
                name: "LocationType",
                table: "Mall_Partners");

            migrationBuilder.DropColumn(
                name: "PhoneBackup",
                table: "Mall_Partners");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Mall_Partners",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "LocationLabel",
                table: "Mall_Partners",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LocationAddress",
                table: "Mall_Partners",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeadImageUrl",
                table: "Mall_Partners",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "Mall_Partners",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Mall_Partners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "openid",
                table: "Mall_PartnerDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "unionid",
                table: "Mall_PartnerDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneBackup",
                table: "Account_RealNameInfos",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);
        }
    }
}
