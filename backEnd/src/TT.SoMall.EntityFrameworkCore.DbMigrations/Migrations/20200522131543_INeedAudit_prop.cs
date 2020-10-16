using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class INeedAudit_prop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Audit",
                table: "Mall_RefundLogs",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AuditFlowId",
                table: "Mall_RefundLogs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuditStatus",
                table: "Mall_RefundLogs",
                nullable: true);
            
            migrationBuilder.AddColumn<int>(
                name: "NodesMaxIndex",
                table: "Audit_AuditFlows",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Audit",
                table: "Mall_RefundLogs");

            migrationBuilder.DropColumn(
                name: "AuditFlowId",
                table: "Mall_RefundLogs");

            migrationBuilder.DropColumn(
                name: "AuditStatus",
                table: "Mall_RefundLogs");
            
            migrationBuilder.DropColumn(
                name: "NodesMaxIndex",
                table: "Audit_AuditFlows");
        }
    }
}