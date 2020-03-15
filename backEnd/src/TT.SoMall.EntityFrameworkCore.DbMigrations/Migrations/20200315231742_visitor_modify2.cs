using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class visitor_modify2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Visitor_Forms");

            migrationBuilder.CreateTable(
                name: "Visitor_ShopForms",
                columns: table => new
                {
                    FromId = table.Column<Guid>(nullable: false),
                    ShopId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitor_ShopForms", x => new { x.FromId, x.ShopId });
                    table.ForeignKey(
                        name: "FK_Visitor_ShopForms_Visitor_Forms_FromId",
                        column: x => x.FromId,
                        principalTable: "Visitor_Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visitor_ShopForms_SoMall_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "SoMall_Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visitor_ShopForms_ShopId",
                table: "Visitor_ShopForms",
                column: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visitor_ShopForms");

            migrationBuilder.AddColumn<Guid>(
                name: "ShopId",
                table: "Visitor_Forms",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
