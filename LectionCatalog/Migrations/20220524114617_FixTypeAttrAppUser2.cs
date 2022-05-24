using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LectionCatalog.Migrations
{
    public partial class FixTypeAttrAppUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Favorites",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "History",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WatchLater",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorites",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "History",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WatchLater",
                table: "AspNetUsers");
        }
    }
}
