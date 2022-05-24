using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LectionCatalog.Migrations
{
    public partial class FixTypeAttrAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lections_AspNetUsers_ApplicationUserId",
                table: "Lections");

            migrationBuilder.DropForeignKey(
                name: "FK_Lections_AspNetUsers_ApplicationUserId1",
                table: "Lections");

            migrationBuilder.DropForeignKey(
                name: "FK_Lections_AspNetUsers_ApplicationUserId2",
                table: "Lections");

            migrationBuilder.DropIndex(
                name: "IX_Lections_ApplicationUserId",
                table: "Lections");

            migrationBuilder.DropIndex(
                name: "IX_Lections_ApplicationUserId1",
                table: "Lections");

            migrationBuilder.DropIndex(
                name: "IX_Lections_ApplicationUserId2",
                table: "Lections");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Lections");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Lections");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId2",
                table: "Lections");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Lections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Lections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId2",
                table: "Lections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lections_ApplicationUserId",
                table: "Lections",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lections_ApplicationUserId1",
                table: "Lections",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Lections_ApplicationUserId2",
                table: "Lections",
                column: "ApplicationUserId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Lections_AspNetUsers_ApplicationUserId",
                table: "Lections",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lections_AspNetUsers_ApplicationUserId1",
                table: "Lections",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lections_AspNetUsers_ApplicationUserId2",
                table: "Lections",
                column: "ApplicationUserId2",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
