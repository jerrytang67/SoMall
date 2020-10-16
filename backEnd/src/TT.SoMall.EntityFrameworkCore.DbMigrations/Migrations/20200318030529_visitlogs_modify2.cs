using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class visitlogs_modify2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                "Lat",
                "Visitor_VisitorLogs",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                "LeaveTime",
                "Visitor_VisitorLogs",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                "Lng",
                "Visitor_VisitorLogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Lat",
                "Visitor_VisitorLogs");

            migrationBuilder.DropColumn(
                "LeaveTime",
                "Visitor_VisitorLogs");

            migrationBuilder.DropColumn(
                "Lng",
                "Visitor_VisitorLogs");
        }
    }
}