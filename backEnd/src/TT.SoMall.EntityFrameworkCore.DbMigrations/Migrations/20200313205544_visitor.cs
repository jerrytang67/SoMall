using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TT.SoMall.Migrations
{
    public partial class visitor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visitor_Credentials",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Data = table.Column<string>(maxLength: 255, nullable: false),
                    UseTimes = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitor_Credentials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitor_Forms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ShopId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitor_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitor_FormItems",
                columns: table => new
                {
                    FromId = table.Column<Guid>(nullable: false),
                    ItemId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    Key = table.Column<string>(maxLength: 64, nullable: false),
                    PlaceHolder = table.Column<string>(maxLength: 64, nullable: false),
                    DefaultValue = table.Column<string>(maxLength: 64, nullable: true),
                    ErrorText = table.Column<string>(maxLength: 64, nullable: true),
                    IsRequired = table.Column<bool>(nullable: false, defaultValue: true),
                    IsDisable = table.Column<bool>(nullable: false, defaultValue: false),
                    IsMulti = table.Column<bool>(nullable: false, defaultValue: false),
                    SelectionJson = table.Column<string>(nullable: true),
                    FormId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitor_FormItems", x => new { x.FromId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_Visitor_FormItems_Visitor_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Visitor_Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visitor_FormItems_Visitor_Forms_FromId",
                        column: x => x.FromId,
                        principalTable: "Visitor_Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitor_VisitorLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    FormId = table.Column<Guid>(nullable: false),
                    FormJson = table.Column<string>(nullable: true),
                    CredentialId = table.Column<Guid>(nullable: true),
                    FormId1 = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ShopId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitor_VisitorLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitor_VisitorLogs_Visitor_Credentials_CredentialId",
                        column: x => x.CredentialId,
                        principalTable: "Visitor_Credentials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visitor_VisitorLogs_Visitor_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Visitor_Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visitor_VisitorLogs_Visitor_Forms_FormId1",
                        column: x => x.FormId1,
                        principalTable: "Visitor_Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visitor_FormItems_FormId",
                table: "Visitor_FormItems",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitor_VisitorLogs_CredentialId",
                table: "Visitor_VisitorLogs",
                column: "CredentialId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitor_VisitorLogs_FormId",
                table: "Visitor_VisitorLogs",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitor_VisitorLogs_FormId1",
                table: "Visitor_VisitorLogs",
                column: "FormId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visitor_FormItems");

            migrationBuilder.DropTable(
                name: "Visitor_VisitorLogs");

            migrationBuilder.DropTable(
                name: "Visitor_Credentials");

            migrationBuilder.DropTable(
                name: "Visitor_Forms");
        }
    }
}
