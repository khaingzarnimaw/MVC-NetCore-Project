using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegisterandLoginApp2.Migrations
{
    public partial class ItemStocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "ItemStock",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "ItemStock");
        }
    }
}
