using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeEcommerce.Data.Migrations
{
    public partial class SexInCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Sex",
                table: "Categories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Categories");
        }
    }
}
