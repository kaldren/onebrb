using Microsoft.EntityFrameworkCore.Migrations;

namespace Onebrb.Data.Migrations
{
    public partial class ProductsUrlIsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductsUrl",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProductsUrl",
                table: "AspNetUsers",
                column: "ProductsUrl",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProductsUrl",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ProductsUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
