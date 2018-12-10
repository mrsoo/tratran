using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeEcommerce.Data.Migrations
{
    public partial class fixproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "home",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "size",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "home",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "size",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Products");
        }
    }
}
