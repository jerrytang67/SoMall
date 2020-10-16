using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class qrDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Mall_QrDetails",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    AppName = table.Column<string>(maxLength: 64, nullable: false),
                    EventName = table.Column<string>(maxLength: 64, nullable: false),
                    Params = table.Column<string>(nullable: true),
                    ViewCount = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    Path = table.Column<string>(maxLength: 255, nullable: true),
                    QrImageUrl = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Mall_QrDetails", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Mall_QrDetails");
        }
    }
}