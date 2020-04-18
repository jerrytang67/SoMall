using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class add_mall_coupon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mall_Coupons",
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
                    Amount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Code = table.Column<string>(maxLength: 32, nullable: false),
                    Desc = table.Column<string>(maxLength: 255, nullable: false),
                    Count = table.Column<int>(nullable: false),
                    TotalCount = table.Column<int>(nullable: false),
                    UseType = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    DateTimeEnable = table.Column<DateTimeOffset>(nullable: false),
                    DateTimeStart = table.Column<DateTimeOffset>(nullable: false),
                    DatetimeEnd = table.Column<DateTimeOffset>(nullable: false),
                    UseCount = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ShopId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mall_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mall_UserCoupons",
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
                    CouponId = table.Column<Guid>(nullable: false),
                    OwnerUserId = table.Column<Guid>(nullable: false),
                    CouponName = table.Column<string>(maxLength: 64, nullable: false),
                    CouponAmount = table.Column<int>(nullable: false),
                    PaymentId = table.Column<Guid>(nullable: true),
                    UsedTime = table.Column<DateTimeOffset>(nullable: true),
                    UsedOrderId = table.Column<Guid>(nullable: true),
                    UsedOrderType = table.Column<int>(nullable: true),
                    ShopId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mall_UserCoupons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mall_Coupons");

            migrationBuilder.DropTable(
                name: "Mall_UserCoupons");
        }
    }
}
