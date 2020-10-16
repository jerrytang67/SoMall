using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class appProductCategory_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                "IsGlobal",
                "Mall_ProductCategory",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                "RedirectUrl",
                "Mall_ProductCategory",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "Sort",
                "Mall_ProductCategory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                "Mall_AppProductCategory",
                table => new
                {
                    AppName = table.Column<string>(maxLength: 64, nullable: false),
                    ProductCategoryId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mall_AppProductCategory", x => new {x.AppName, x.ProductCategoryId});
                    table.ForeignKey(
                        "FK_Mall_AppProductCategory_Mall_ProductCategory_ProductCategoryId",
                        x => x.ProductCategoryId,
                        "Mall_ProductCategory",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Mall_AppProductCategory_ProductCategoryId",
                "Mall_AppProductCategory",
                "ProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Mall_AppProductCategory");

            migrationBuilder.DropColumn(
                "IsGlobal",
                "Mall_ProductCategory");

            migrationBuilder.DropColumn(
                "RedirectUrl",
                "Mall_ProductCategory");

            migrationBuilder.DropColumn(
                "Sort",
                "Mall_ProductCategory");
        }
    }
}