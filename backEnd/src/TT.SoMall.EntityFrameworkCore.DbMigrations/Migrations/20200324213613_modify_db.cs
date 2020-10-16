using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class modify_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                "TenantId",
                "Visitor_VisitorShops",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                "TenantId",
                "SoMall_Shops",
                nullable: true);


            migrationBuilder.DropForeignKey(
                "FK_Visitor_ShopForms_SoMall_Shops_ShopId",
                "Visitor_ShopForms");

            migrationBuilder.DropTable(
                "SoMall_ProductSku");

            migrationBuilder.DropTable(
                "SoMall_ProductSpu");

            migrationBuilder.DropTable(
                "SoMall_ProductCategory");

            migrationBuilder.DropColumn(
                "TenantId",
                "SoMall_Shops");

            migrationBuilder.AlterColumn<string>(
                "CoverImage",
                "SoMall_Shops",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                "HeadImgUrl",
                "AbpUsers",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "Nickname",
                "AbpUsers",
                maxLength: 64,
                nullable: true);

            migrationBuilder.CreateTable(
                "Mall_ProductCategory",
                table => new
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
                    Code = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Mall_ProductCategory", x => x.Id); });

            migrationBuilder.CreateTable(
                "Visitor_VisitorShops",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    ShortName = table.Column<string>(maxLength: 16, nullable: false),
                    LogoImage = table.Column<string>(maxLength: 255, nullable: false),
                    CoverImage = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Visitor_VisitorShops", x => x.Id); });

            migrationBuilder.CreateTable(
                "Mall_ProductSpu",
                table => new
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
                    CategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Code = table.Column<string>(maxLength: 32, nullable: true),
                    Desc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mall_ProductSpu", x => x.Id);
                    table.ForeignKey(
                        "FK_Mall_ProductSpu_Mall_ProductCategory_CategoryId",
                        x => x.CategoryId,
                        "Mall_ProductCategory",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Mall_ProductSku",
                table => new
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
                    SpuId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Code = table.Column<string>(maxLength: 32, nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mall_ProductSku", x => x.Id);
                    table.ForeignKey(
                        "FK_Mall_ProductSku_Mall_ProductSpu_SpuId",
                        x => x.SpuId,
                        "Mall_ProductSpu",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Mall_ProductSku_SpuId",
                "Mall_ProductSku",
                "SpuId");

            migrationBuilder.CreateIndex(
                "IX_Mall_ProductSpu_CategoryId",
                "Mall_ProductSpu",
                "CategoryId");

            migrationBuilder.AddForeignKey(
                "FK_Visitor_ShopForms_Visitor_VisitorShops_ShopId",
                "Visitor_ShopForms",
                "ShopId",
                "Visitor_VisitorShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "TenantId",
                "Visitor_VisitorShops");

            migrationBuilder.DropColumn(
                "TenantId",
                "SoMall_Shops");

            migrationBuilder.DropForeignKey(
                "FK_Visitor_ShopForms_Visitor_VisitorShops_ShopId",
                "Visitor_ShopForms");

            migrationBuilder.DropTable(
                "Mall_ProductSku");

            migrationBuilder.DropTable(
                "Visitor_VisitorShops");

            migrationBuilder.DropTable(
                "Mall_ProductSpu");

            migrationBuilder.DropTable(
                "Mall_ProductCategory");

            migrationBuilder.DropColumn(
                "HeadImgUrl",
                "AbpUsers");

            migrationBuilder.DropColumn(
                "Nickname",
                "AbpUsers");

            migrationBuilder.AlterColumn<string>(
                "CoverImage",
                "SoMall_Shops",
                "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                "TenantId",
                "SoMall_Shops",
                "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                "SoMall_ProductCategory",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Code = table.Column<string>("nvarchar(32)", maxLength: 32, nullable: true),
                    ConcurrencyStamp = table.Column<string>("nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                    CreatorId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>("nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>("bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    Name = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                    TenantId = table.Column<Guid>("uniqueidentifier", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_SoMall_ProductCategory", x => x.Id); });

            migrationBuilder.CreateTable(
                "SoMall_ProductSpu",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Code = table.Column<string>("nvarchar(32)", maxLength: 32, nullable: true),
                    ConcurrencyStamp = table.Column<string>("nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                    CreatorId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    Desc = table.Column<string>("nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>("nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>("bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    Name = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                    TenantId = table.Column<Guid>("uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoMall_ProductSpu", x => x.Id);
                    table.ForeignKey(
                        "FK_SoMall_ProductSpu_SoMall_ProductCategory_CategoryId",
                        x => x.CategoryId,
                        "SoMall_ProductCategory",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "SoMall_ProductSku",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Code = table.Column<string>("nvarchar(32)", maxLength: 32, nullable: true),
                    ConcurrencyStamp = table.Column<string>("nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                    CreatorId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>("nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>("bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    Name = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                    Price = table.Column<decimal>("decimal(18,2)", nullable: false),
                    SpuId = table.Column<Guid>("uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>("uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoMall_ProductSku", x => x.Id);
                    table.ForeignKey(
                        "FK_SoMall_ProductSku_SoMall_ProductSpu_SpuId",
                        x => x.SpuId,
                        "SoMall_ProductSpu",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_SoMall_ProductSku_SpuId",
                "SoMall_ProductSku",
                "SpuId");

            migrationBuilder.CreateIndex(
                "IX_SoMall_ProductSpu_CategoryId",
                "SoMall_ProductSpu",
                "CategoryId");

            migrationBuilder.AddForeignKey(
                "FK_Visitor_ShopForms_SoMall_Shops_ShopId",
                "Visitor_ShopForms",
                "ShopId",
                "SoMall_Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}