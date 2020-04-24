using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class appProductCategory_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsGlobal",
                table: "Mall_ProductCategory",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RedirectUrl",
                table: "Mall_ProductCategory",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "Mall_ProductCategory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Mall_AppProductCategory",
                columns: table => new
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
                    table.PrimaryKey("PK_Mall_AppProductCategory", x => new { x.AppName, x.ProductCategoryId });
                    table.ForeignKey(
                        name: "FK_Mall_AppProductCategory_Mall_ProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "Mall_ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mall_AppProductCategory_ProductCategoryId",
                table: "Mall_AppProductCategory",
                column: "ProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mall_AppProductCategory");

            migrationBuilder.DropColumn(
                name: "IsGlobal",
                table: "Mall_ProductCategory");

            migrationBuilder.DropColumn(
                name: "RedirectUrl",
                table: "Mall_ProductCategory");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Mall_ProductCategory");
        }
    }
}
