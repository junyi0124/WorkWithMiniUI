using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FirstCoreAppDemo.Data.Migrations
{
    public partial class AddMaterials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 6, nullable: false),
                    FullCode = table.Column<string>(maxLength: 128, nullable: false),
                    FullName = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    PId = table.Column<int>(nullable: true),
                    Unit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_FullCode",
                table: "Materials",
                column: "FullCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_FullName",
                table: "Materials",
                column: "FullName");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_Name",
                table: "Materials",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_PId",
                table: "Materials",
                column: "PId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");
        }
    }
}
