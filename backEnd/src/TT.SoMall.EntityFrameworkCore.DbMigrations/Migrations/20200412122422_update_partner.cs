using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class update_partner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mall_PartnerDetails_Mall_Partners_PartnerId",
                table: "Mall_PartnerDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Mall_PartnerProducts_Mall_Partners_PartnerId",
                table: "Mall_PartnerProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mall_Partners",
                table: "Mall_Partners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mall_PartnerDetails",
                table: "Mall_PartnerDetails");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Mall_Partners");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "Mall_PartnerDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Mall_Partners",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PartnerUserId",
                table: "Mall_PartnerDetails",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mall_Partners",
                table: "Mall_Partners",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mall_PartnerDetails",
                table: "Mall_PartnerDetails",
                column: "PartnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mall_PartnerDetails_Mall_Partners_PartnerUserId",
                table: "Mall_PartnerDetails",
                column: "PartnerUserId",
                principalTable: "Mall_Partners",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mall_PartnerProducts_Mall_Partners_PartnerId",
                table: "Mall_PartnerProducts",
                column: "PartnerId",
                principalTable: "Mall_Partners",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mall_PartnerDetails_Mall_Partners_PartnerUserId",
                table: "Mall_PartnerDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Mall_PartnerProducts_Mall_Partners_PartnerId",
                table: "Mall_PartnerProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mall_Partners",
                table: "Mall_Partners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mall_PartnerDetails",
                table: "Mall_PartnerDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Mall_Partners");

            migrationBuilder.DropColumn(
                name: "PartnerUserId",
                table: "Mall_PartnerDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Mall_Partners",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PartnerId",
                table: "Mall_PartnerDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mall_Partners",
                table: "Mall_Partners",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mall_PartnerDetails",
                table: "Mall_PartnerDetails",
                column: "PartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mall_PartnerDetails_Mall_Partners_PartnerId",
                table: "Mall_PartnerDetails",
                column: "PartnerId",
                principalTable: "Mall_Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mall_PartnerProducts_Mall_Partners_PartnerId",
                table: "Mall_PartnerProducts",
                column: "PartnerId",
                principalTable: "Mall_Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
