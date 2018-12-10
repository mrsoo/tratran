using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeEcommerce.Data.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brand_IdBrand",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "Brand",
                newName: "Brands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "IdBrand");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_IdBrand",
                table: "Products",
                column: "IdBrand",
                principalTable: "Brands",
                principalColumn: "IdBrand",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_IdBrand",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brand");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                table: "Brand",
                column: "IdBrand");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brand_IdBrand",
                table: "Products",
                column: "IdBrand",
                principalTable: "Brand",
                principalColumn: "IdBrand",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
