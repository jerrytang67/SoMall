using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class add_shop_module : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SoMall_ProductSpu",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "SoMall_ProductSpu",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SoMall_ProductSku",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "SoMall_ProductSku",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SoMall_ProductCategory",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "SoMall_ProductCategory",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SoMall_Shops",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    ShortName = table.Column<string>(maxLength: 16, nullable: false),
                    CoverImage = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoMall_Shops", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoMall_Shops");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SoMall_ProductSpu");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "SoMall_ProductSpu");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SoMall_ProductSku");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "SoMall_ProductSku");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SoMall_ProductCategory");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "SoMall_ProductCategory");
        }
    }
}
