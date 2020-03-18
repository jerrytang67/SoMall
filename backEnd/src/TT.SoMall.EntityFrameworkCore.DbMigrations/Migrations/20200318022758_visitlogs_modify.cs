using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class visitlogs_modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "Visitor_VisitorLogs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Visitor_VisitorLogs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SaveToLocal",
                table: "Visitor_FormItems",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "Visitor_VisitorLogs");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Visitor_VisitorLogs");

            migrationBuilder.DropColumn(
                name: "SaveToLocal",
                table: "Visitor_FormItems");
        }
    }
}
