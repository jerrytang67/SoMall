using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class abp_29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "AbpOrganizationUnits",
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
                    TenantId = table.Column<Guid>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(maxLength: 95, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpOrganizationUnits", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId",
                        x => x.ParentId,
                        "AbpOrganizationUnits",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AbpOrganizationUnitRoles",
                table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    OrganizationUnitId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpOrganizationUnitRoles", x => new {x.OrganizationUnitId, x.RoleId});
                    table.ForeignKey(
                        "FK_AbpOrganizationUnitRoles_AbpOrganizationUnits_OrganizationUnitId",
                        x => x.OrganizationUnitId,
                        "AbpOrganizationUnits",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_AbpOrganizationUnitRoles_AbpRoles_RoleId",
                        x => x.RoleId,
                        "AbpRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpUserOrganizationUnits",
                table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    OrganizationUnitId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserOrganizationUnits", x => new {x.OrganizationUnitId, x.UserId});
                    table.ForeignKey(
                        "FK_AbpUserOrganizationUnits_AbpOrganizationUnits_OrganizationUnitId",
                        x => x.OrganizationUnitId,
                        "AbpOrganizationUnits",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_AbpUserOrganizationUnits_AbpUsers_UserId",
                        x => x.UserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_AbpOrganizationUnitRoles_RoleId_OrganizationUnitId",
                "AbpOrganizationUnitRoles",
                new[] {"RoleId", "OrganizationUnitId"});

            migrationBuilder.CreateIndex(
                "IX_AbpOrganizationUnits_Code",
                "AbpOrganizationUnits",
                "Code");

            migrationBuilder.CreateIndex(
                "IX_AbpOrganizationUnits_ParentId",
                "AbpOrganizationUnits",
                "ParentId");

            migrationBuilder.CreateIndex(
                "IX_AbpUserOrganizationUnits_UserId_OrganizationUnitId",
                "AbpUserOrganizationUnits",
                new[] {"UserId", "OrganizationUnitId"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AbpOrganizationUnitRoles");

            migrationBuilder.DropTable(
                "AbpUserOrganizationUnits");

            migrationBuilder.DropTable(
                "AbpOrganizationUnits");
        }
    }
}