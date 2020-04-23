using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class add_tenpayNotify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mall_TenPayNotify",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    out_trade_no = table.Column<string>(maxLength: 64, nullable: true),
                    result_code = table.Column<string>(maxLength: 64, nullable: true),
                    fee_type = table.Column<string>(maxLength: 64, nullable: true),
                    return_code = table.Column<string>(maxLength: 64, nullable: true),
                    total_fee = table.Column<string>(maxLength: 64, nullable: true),
                    mch_id = table.Column<string>(maxLength: 64, nullable: true),
                    cash_fee = table.Column<string>(maxLength: 64, nullable: true),
                    openid = table.Column<string>(maxLength: 64, nullable: true),
                    transaction_id = table.Column<string>(maxLength: 64, nullable: true),
                    sign = table.Column<string>(maxLength: 64, nullable: true),
                    bank_type = table.Column<string>(maxLength: 64, nullable: true),
                    appid = table.Column<string>(maxLength: 64, nullable: true),
                    time_end = table.Column<string>(maxLength: 64, nullable: true),
                    trade_type = table.Column<string>(maxLength: 64, nullable: true),
                    nonce_str = table.Column<string>(maxLength: 64, nullable: true),
                    is_subscribe = table.Column<string>(maxLength: 64, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mall_TenPayNotify", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mall_TenPayNotify");
        }
    }
}
