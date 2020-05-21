using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class auditNodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audit_AuditFlows",
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
                    AuditName = table.Column<string>(maxLength: 64, nullable: false),
                    Enable = table.Column<bool>(nullable: false),
                    ProviderName = table.Column<string>(maxLength: 2, nullable: false),
                    ProviderKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_AuditFlows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Audit_AuditNodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    Desc = table.Column<string>(maxLength: 64, nullable: true),
                    UserName = table.Column<string>(maxLength: 48, nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    AuditFlowId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_AuditNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audit_AuditNodes_Audit_AuditFlows_AuditFlowId",
                        column: x => x.AuditFlowId,
                        principalTable: "Audit_AuditFlows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Audit_AuditNodes_AuditFlowId",
                table: "Audit_AuditNodes",
                column: "AuditFlowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audit_AuditNodes");

            migrationBuilder.DropTable(
                name: "Audit_AuditFlows");
        }
    }
}
