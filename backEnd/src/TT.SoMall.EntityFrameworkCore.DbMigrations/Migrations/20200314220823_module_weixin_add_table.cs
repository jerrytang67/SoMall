using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class module_weixin_add_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Theme",
                table: "Visitor_Forms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Visitor_FormItems",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Weixin_WechatUserinfos",
                columns: table => new
                {
                    appid = table.Column<string>(maxLength: 32, nullable: false),
                    openid = table.Column<string>(maxLength: 32, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    unionid = table.Column<string>(maxLength: 32, nullable: true),
                    nickname = table.Column<string>(maxLength: 32, nullable: true),
                    headimgurl = table.Column<string>(maxLength: 255, nullable: true),
                    city = table.Column<string>(maxLength: 255, nullable: true),
                    province = table.Column<string>(maxLength: 255, nullable: true),
                    country = table.Column<string>(maxLength: 255, nullable: true),
                    sex = table.Column<int>(nullable: false),
                    FromClient = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weixin_WechatUserinfos", x => new { x.openid, x.appid });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weixin_WechatUserinfos");

            migrationBuilder.DropColumn(
                name: "Theme",
                table: "Visitor_Forms");

            migrationBuilder.DropColumn(
                name: "Label",
                table: "Visitor_FormItems");
        }
    }
}
