using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstCoreAppDemo.Data.Migrations
{
    public partial class AddMaterialTreeColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Expanded",
                table: "Materials",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLeaf",
                table: "Materials",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "SortNumber",
                table: "Materials",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "_level",
                table: "Materials",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_SortNumber",
                table: "Materials",
                column: "SortNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Materials_SortNumber",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Expanded",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "IsLeaf",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "SortNumber",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "_level",
                table: "Materials");
        }
    }
}
