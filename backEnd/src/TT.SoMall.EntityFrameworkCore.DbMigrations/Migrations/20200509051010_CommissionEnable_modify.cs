using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class CommissionEnable_modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CommissionEnable",
                table: "Mall_ProductSku",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "CommissionPrice",
                table: "Mall_ProductSku",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneBackup",
                table: "Mall_Partners",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommissionEnable",
                table: "Mall_ProductSku");

            migrationBuilder.DropColumn(
                name: "CommissionPrice",
                table: "Mall_ProductSku");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneBackup",
                table: "Mall_Partners",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16,
                oldNullable: true);
        }
    }
}
