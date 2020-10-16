using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class mall_entity_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Mall_Addresses",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    RealName = table.Column<string>(maxLength: 64, nullable: false),
                    Phone = table.Column<string>(maxLength: 64, nullable: false),
                    LocationLabel = table.Column<string>(maxLength: 255, nullable: false),
                    NickName = table.Column<string>(maxLength: 64, nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    DatetimeLast = table.Column<DateTime>(nullable: true),
                    Lat = table.Column<double>(nullable: true),
                    Lng = table.Column<double>(nullable: true),
                    LocationType = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Mall_Addresses", x => x.Id); });

            migrationBuilder.CreateTable(
                "Mall_Comment",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    BuyerName = table.Column<string>(maxLength: 64, nullable: true),
                    BuyerAvatar = table.Column<string>(maxLength: 255, nullable: true),
                    Content = table.Column<string>(maxLength: 1024, nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    SpuId = table.Column<Guid>(nullable: false),
                    SkuId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    ShopId = table.Column<Guid>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Mall_Comment", x => x.Id); });

            migrationBuilder.CreateTable(
                "Mall_Partners",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    RealName = table.Column<string>(maxLength: 64, nullable: false),
                    Phone = table.Column<string>(maxLength: 64, nullable: false),
                    Nickname = table.Column<string>(maxLength: 64, nullable: true),
                    HeadImageUrl = table.Column<string>(maxLength: 255, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    AvblBalance = table.Column<decimal>(nullable: false),
                    UnavblBalance = table.Column<decimal>(nullable: false),
                    TotalWithdrawals = table.Column<decimal>(nullable: false),
                    LastLoginDate = table.Column<DateTime>(nullable: true),
                    Lat = table.Column<double>(nullable: true),
                    Lng = table.Column<double>(nullable: true),
                    LocationLabel = table.Column<string>(maxLength: 255, nullable: true),
                    LocationAddress = table.Column<string>(maxLength: 255, nullable: true),
                    Views = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Mall_Partners", x => x.Id); });

            migrationBuilder.CreateTable(
                "Mall_PayOrders",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Body = table.Column<string>(maxLength: 128, nullable: false),
                    OrderId = table.Column<Guid>(nullable: false),
                    TotalPrice = table.Column<int>(nullable: false),
                    BillNo = table.Column<string>(maxLength: 48, nullable: true),
                    OpenId = table.Column<string>(maxLength: 32, nullable: true),
                    MchId = table.Column<string>(maxLength: 32, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    PayType = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    IsSuccessPay = table.Column<bool>(nullable: false),
                    SuccessPayTime = table.Column<DateTime>(nullable: true),
                    IsRefund = table.Column<bool>(nullable: false),
                    RefundTime = table.Column<DateTime>(nullable: true),
                    RefundComplateTime = table.Column<DateTime>(nullable: true),
                    RefundPrice = table.Column<int>(nullable: true),
                    ShareFromUserId = table.Column<Guid>(nullable: true),
                    PartnerId = table.Column<Guid>(nullable: true),
                    FromClient = table.Column<string>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    ShopId = table.Column<Guid>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Mall_PayOrders", x => x.Id); });

            migrationBuilder.CreateTable(
                "Mall_ProductOrders",
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
                    PricePaidIn = table.Column<decimal>("decimal(18,2)", nullable: true),
                    PriceOriginal = table.Column<decimal>("decimal(18,2)", nullable: false),
                    State = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    PayType = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 255, nullable: true),
                    BuyerId = table.Column<Guid>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true),
                    AddressRealName = table.Column<string>(maxLength: 64, nullable: true),
                    AddressNickName = table.Column<string>(maxLength: 64, nullable: true),
                    AddressPhone = table.Column<string>(maxLength: 64, nullable: true),
                    AddressLocationLabel = table.Column<string>(maxLength: 255, nullable: true),
                    ManId = table.Column<Guid>(nullable: true),
                    PrintCount = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ShopId = table.Column<Guid>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Mall_ProductOrders", x => x.Id); });

            migrationBuilder.CreateTable(
                "Mall_RealNameInfos",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    RealName = table.Column<string>(maxLength: 64, nullable: false),
                    Phone = table.Column<string>(maxLength: 64, nullable: false),
                    PhoneBackup = table.Column<string>(maxLength: 64, nullable: true),
                    Type = table.Column<byte>(nullable: false),
                    IDCardFrontUrl = table.Column<string>(maxLength: 64, nullable: false),
                    IDCardBackUrl = table.Column<string>(maxLength: 64, nullable: false),
                    IDCardHandUrl = table.Column<string>(maxLength: 64, nullable: false),
                    BusinessLicenseUrl = table.Column<string>(maxLength: 64, nullable: true),
                    State = table.Column<byte>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Mall_RealNameInfos", x => x.Id); });

            migrationBuilder.CreateTable(
                "Mall_PartnerDetails",
                table => new
                {
                    PartnerId = table.Column<Guid>(nullable: false),
                    NoticeContent = table.Column<string>(nullable: true),
                    openid = table.Column<string>(nullable: true),
                    unionid = table.Column<string>(nullable: true),
                    weixin = table.Column<string>(nullable: true),
                    Introducting = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mall_PartnerDetails", x => x.PartnerId);
                    table.ForeignKey(
                        "FK_Mall_PartnerDetails_Mall_Partners_PartnerId",
                        x => x.PartnerId,
                        "Mall_Partners",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Mall_PartnerProducts",
                table => new
                {
                    PartnerId = table.Column<Guid>(nullable: false),
                    SpuId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: true),
                    State = table.Column<int>(nullable: false, defaultValue: 1),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mall_PartnerProducts", x => new {x.PartnerId, x.SpuId});
                    table.ForeignKey(
                        "FK_Mall_PartnerProducts_Mall_Partners_PartnerId",
                        x => x.PartnerId,
                        "Mall_Partners",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Mall_PartnerProducts_Mall_ProductSpu_SpuId",
                        x => x.SpuId,
                        "Mall_ProductSpu",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Mall_ProductOrderItems",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderId = table.Column<Guid>(nullable: false),
                    SpuId = table.Column<Guid>(nullable: false),
                    SkuId = table.Column<Guid>(nullable: false),
                    Count = table.Column<double>(nullable: false),
                    SpuName = table.Column<string>(maxLength: 64, nullable: false),
                    SkuName = table.Column<string>(maxLength: 64, nullable: false),
                    SkuPrice = table.Column<decimal>("decimal(18,2)", nullable: false),
                    SkuUnit = table.Column<string>(maxLength: 16, nullable: true),
                    Comment = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mall_ProductOrderItems", x => x.Id);
                    table.ForeignKey(
                        "FK_Mall_ProductOrderItems_Mall_ProductOrders_OrderId",
                        x => x.OrderId,
                        "Mall_ProductOrders",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Mall_PartnerProducts_SpuId",
                "Mall_PartnerProducts",
                "SpuId");

            migrationBuilder.CreateIndex(
                "IX_Mall_ProductOrderItems_OrderId",
                "Mall_ProductOrderItems",
                "OrderId");

            migrationBuilder.AddColumn<string>(
                "LocationAddress",
                "Mall_Addresses",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Mall_Addresses");

            migrationBuilder.DropTable(
                "Mall_Comment");

            migrationBuilder.DropTable(
                "Mall_PartnerDetails");

            migrationBuilder.DropTable(
                "Mall_PartnerProducts");

            migrationBuilder.DropTable(
                "Mall_PayOrders");

            migrationBuilder.DropTable(
                "Mall_ProductOrderItems");

            migrationBuilder.DropTable(
                "Mall_RealNameInfos");

            migrationBuilder.DropTable(
                "Mall_Partners");

            migrationBuilder.DropTable(
                "Mall_ProductOrders");

            migrationBuilder.DropColumn(
                "LocationAddress",
                "Mall_Addresses");
        }
    }
}