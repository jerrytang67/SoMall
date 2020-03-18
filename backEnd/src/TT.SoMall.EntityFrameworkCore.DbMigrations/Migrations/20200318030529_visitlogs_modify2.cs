using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class visitlogs_modify2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Visitor_VisitorLogs",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LeaveTime",
                table: "Visitor_VisitorLogs",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Visitor_VisitorLogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Visitor_VisitorLogs");

            migrationBuilder.DropColumn(
                name: "LeaveTime",
                table: "Visitor_VisitorLogs");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Visitor_VisitorLogs");
        }
    }
}
