using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class INeedAudit_prop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "Audit",
                "Mall_RefundLogs",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                "AuditFlowId",
                "Mall_RefundLogs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "AuditStatus",
                "Mall_RefundLogs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "NodesMaxIndex",
                "Audit_AuditFlows",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Audit",
                "Mall_RefundLogs");

            migrationBuilder.DropColumn(
                "AuditFlowId",
                "Mall_RefundLogs");

            migrationBuilder.DropColumn(
                "AuditStatus",
                "Mall_RefundLogs");

            migrationBuilder.DropColumn(
                "NodesMaxIndex",
                "Audit_AuditFlows");
        }
    }
}