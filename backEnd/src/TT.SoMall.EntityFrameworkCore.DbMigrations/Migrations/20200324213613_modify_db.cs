using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class modify_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Visitor_VisitorShops",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "SoMall_Shops",
                nullable: true);
            
            
            migrationBuilder.DropForeignKey(
                name: "FK_Visitor_ShopForms_SoMall_Shops_ShopId",
                table: "Visitor_ShopForms");

            migrationBuilder.DropTable(
                name: "SoMall_ProductSku");

            migrationBuilder.DropTable(
                name: "SoMall_ProductSpu");

            migrationBuilder.DropTable(
                name: "SoMall_ProductCategory");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "SoMall_Shops");

            migrationBuilder.AlterColumn<string>(
                name: "CoverImage",
                table: "SoMall_Shops",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "HeadImgUrl",
                table: "AbpUsers",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "AbpUsers",
                maxLength: 64,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mall_ProductCategory",
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
                    Code = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mall_ProductCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitor_VisitorShops",
                columns: table => new
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
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitor_VisitorShops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mall_ProductSpu",
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
                    CategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Code = table.Column<string>(maxLength: 32, nullable: true),
                    Desc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mall_ProductSpu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mall_ProductSpu_Mall_ProductCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Mall_ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mall_ProductSku",
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
                    SpuId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Code = table.Column<string>(maxLength: 32, nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mall_ProductSku", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mall_ProductSku_Mall_ProductSpu_SpuId",
                        column: x => x.SpuId,
                        principalTable: "Mall_ProductSpu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mall_ProductSku_SpuId",
                table: "Mall_ProductSku",
                column: "SpuId");

            migrationBuilder.CreateIndex(
                name: "IX_Mall_ProductSpu_CategoryId",
                table: "Mall_ProductSpu",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitor_ShopForms_Visitor_VisitorShops_ShopId",
                table: "Visitor_ShopForms",
                column: "ShopId",
                principalTable: "Visitor_VisitorShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Visitor_VisitorShops");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "SoMall_Shops");
            
            migrationBuilder.DropForeignKey(
                name: "FK_Visitor_ShopForms_Visitor_VisitorShops_ShopId",
                table: "Visitor_ShopForms");

            migrationBuilder.DropTable(
                name: "Mall_ProductSku");

            migrationBuilder.DropTable(
                name: "Visitor_VisitorShops");

            migrationBuilder.DropTable(
                name: "Mall_ProductSpu");

            migrationBuilder.DropTable(
                name: "Mall_ProductCategory");

            migrationBuilder.DropColumn(
                name: "HeadImgUrl",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "AbpUsers");

            migrationBuilder.AlterColumn<string>(
                name: "CoverImage",
                table: "SoMall_Shops",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "SoMall_Shops",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SoMall_ProductCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoMall_ProductCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoMall_ProductSpu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoMall_ProductSpu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoMall_ProductSpu_SoMall_ProductCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SoMall_ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoMall_ProductSku",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoMall_ProductSku", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoMall_ProductSku_SoMall_ProductSpu_SpuId",
                        column: x => x.SpuId,
                        principalTable: "SoMall_ProductSpu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoMall_ProductSku_SpuId",
                table: "SoMall_ProductSku",
                column: "SpuId");

            migrationBuilder.CreateIndex(
                name: "IX_SoMall_ProductSpu_CategoryId",
                table: "SoMall_ProductSpu",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitor_ShopForms_SoMall_Shops_ShopId",
                table: "Visitor_ShopForms",
                column: "ShopId",
                principalTable: "SoMall_Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
