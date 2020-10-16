using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class accountManagement_module : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Mall_RealNameInfos");

            migrationBuilder.CreateTable(
                "Account_RealNameInfos",
                table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
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
                constraints: table => { table.PrimaryKey("PK_Account_RealNameInfos", x => x.UserId); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Account_RealNameInfos");

            migrationBuilder.CreateTable(
                "Mall_RealNameInfos",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    BusinessLicenseUrl = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: true),
                    CreationTime = table.Column<DateTime>("datetime2", nullable: false),
                    CreatorId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>("datetime2", nullable: true),
                    IDCardBackUrl = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                    IDCardFrontUrl = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                    IDCardHandUrl = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                    IsDeleted = table.Column<bool>("bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>("datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    Phone = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                    PhoneBackup = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: true),
                    RealName = table.Column<string>("nvarchar(64)", maxLength: 64, nullable: false),
                    State = table.Column<byte>("tinyint", nullable: false),
                    TenantId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    Type = table.Column<byte>("tinyint", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Mall_RealNameInfos", x => x.Id); });
        }
    }
}