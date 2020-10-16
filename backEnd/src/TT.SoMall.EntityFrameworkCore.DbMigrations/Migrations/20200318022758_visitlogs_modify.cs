using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class visitlogs_modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                "DeleterId",
                "Visitor_VisitorLogs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                "DeletionTime",
                "Visitor_VisitorLogs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                "SaveToLocal",
                "Visitor_FormItems",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "DeleterId",
                "Visitor_VisitorLogs");

            migrationBuilder.DropColumn(
                "DeletionTime",
                "Visitor_VisitorLogs");

            migrationBuilder.DropColumn(
                "SaveToLocal",
                "Visitor_FormItems");
        }
    }
}