using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace task2.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    PageId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    AddedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "strftime('%Y-%m-%d %H:%M:%S')"),
                    Content = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    UrlName = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.PageId);
                });

            migrationBuilder.CreateTable(
                name: "NavLinks",
                columns: table => new
                {
                    NavLinkId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    PageId = table.Column<int>(nullable: false),
                    ParentLinkID = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavLinks", x => x.NavLinkId);
                    table.ForeignKey(
                        name: "FK_NavLinks_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NavLinks_NavLinks_ParentLinkID",
                        column: x => x.ParentLinkID,
                        principalTable: "NavLinks",
                        principalColumn: "NavLinkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelatedPages",
                columns: table => new
                {
                    RelatedPageId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Page1ID = table.Column<int>(nullable: false),
                    Page2ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedPages", x => x.RelatedPageId);
                    table.ForeignKey(
                        name: "FK_RelatedPages_Pages_Page1ID",
                        column: x => x.Page1ID,
                        principalTable: "Pages",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelatedPages_Pages_Page2ID",
                        column: x => x.Page2ID,
                        principalTable: "Pages",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NavLinks_PageId",
                table: "NavLinks",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_NavLinks_ParentLinkID",
                table: "NavLinks",
                column: "ParentLinkID");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPages_Page1ID",
                table: "RelatedPages",
                column: "Page1ID");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPages_Page2ID",
                table: "RelatedPages",
                column: "Page2ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NavLinks");

            migrationBuilder.DropTable(
                name: "RelatedPages");

            migrationBuilder.DropTable(
                name: "Pages");
        }
    }
}
