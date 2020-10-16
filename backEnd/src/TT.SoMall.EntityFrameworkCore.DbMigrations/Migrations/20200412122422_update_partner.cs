using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class update_partner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Mall_PartnerDetails_Mall_Partners_PartnerId",
                "Mall_PartnerDetails");

            migrationBuilder.DropForeignKey(
                "FK_Mall_PartnerProducts_Mall_Partners_PartnerId",
                "Mall_PartnerProducts");

            migrationBuilder.DropPrimaryKey(
                "PK_Mall_Partners",
                "Mall_Partners");

            migrationBuilder.DropPrimaryKey(
                "PK_Mall_PartnerDetails",
                "Mall_PartnerDetails");

            migrationBuilder.DropColumn(
                "Id",
                "Mall_Partners");

            migrationBuilder.DropColumn(
                "PartnerId",
                "Mall_PartnerDetails");

            migrationBuilder.AddColumn<Guid>(
                "UserId",
                "Mall_Partners",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                "PartnerUserId",
                "Mall_PartnerDetails",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                "PK_Mall_Partners",
                "Mall_Partners",
                "UserId");

            migrationBuilder.AddPrimaryKey(
                "PK_Mall_PartnerDetails",
                "Mall_PartnerDetails",
                "PartnerUserId");

            migrationBuilder.AddForeignKey(
                "FK_Mall_PartnerDetails_Mall_Partners_PartnerUserId",
                "Mall_PartnerDetails",
                "PartnerUserId",
                "Mall_Partners",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Mall_PartnerProducts_Mall_Partners_PartnerId",
                "Mall_PartnerProducts",
                "PartnerId",
                "Mall_Partners",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Mall_PartnerDetails_Mall_Partners_PartnerUserId",
                "Mall_PartnerDetails");

            migrationBuilder.DropForeignKey(
                "FK_Mall_PartnerProducts_Mall_Partners_PartnerId",
                "Mall_PartnerProducts");

            migrationBuilder.DropPrimaryKey(
                "PK_Mall_Partners",
                "Mall_Partners");

            migrationBuilder.DropPrimaryKey(
                "PK_Mall_PartnerDetails",
                "Mall_PartnerDetails");

            migrationBuilder.DropColumn(
                "UserId",
                "Mall_Partners");

            migrationBuilder.DropColumn(
                "PartnerUserId",
                "Mall_PartnerDetails");

            migrationBuilder.AddColumn<Guid>(
                "Id",
                "Mall_Partners",
                "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                "PartnerId",
                "Mall_PartnerDetails",
                "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                "PK_Mall_Partners",
                "Mall_Partners",
                "Id");

            migrationBuilder.AddPrimaryKey(
                "PK_Mall_PartnerDetails",
                "Mall_PartnerDetails",
                "PartnerId");

            migrationBuilder.AddForeignKey(
                "FK_Mall_PartnerDetails_Mall_Partners_PartnerId",
                "Mall_PartnerDetails",
                "PartnerId",
                "Mall_Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Mall_PartnerProducts_Mall_Partners_PartnerId",
                "Mall_PartnerProducts",
                "PartnerId",
                "Mall_Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}