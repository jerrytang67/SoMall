using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class mall_swiper_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Mall_NewsCategories",
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
                    ShopId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Mall_NewsCategories", x => x.Id); });

            migrationBuilder.CreateTable(
                "Mall_Swipers",
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
                    GroupName = table.Column<string>(maxLength: 64, nullable: false),
                    AppName = table.Column<string>(maxLength: 64, nullable: false),
                    CoverImageUrl = table.Column<string>(maxLength: 255, nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    RedirectUrl = table.Column<string>(maxLength: 255, nullable: true),
                    State = table.Column<int>(nullable: false, defaultValue: 1),
                    Sort = table.Column<int>(nullable: false),
                    ShopId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Mall_Swipers", x => x.Id); });

            migrationBuilder.CreateTable(
                "Mall_NewsContents",
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
                    Title = table.Column<string>(maxLength: 64, nullable: false),
                    CoverImageUrl = table.Column<string>(maxLength: 255, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ViewCount = table.Column<int>(nullable: false),
                    ShopId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mall_NewsContents", x => x.Id);
                    table.ForeignKey(
                        "FK_Mall_NewsContents_Mall_NewsCategories_CategoryId",
                        x => x.CategoryId,
                        "Mall_NewsCategories",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Mall_NewsContents_CategoryId",
                "Mall_NewsContents",
                "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Mall_NewsContents");

            migrationBuilder.DropTable(
                "Mall_Swipers");

            migrationBuilder.DropTable(
                "Mall_NewsCategories");
        }
    }
}