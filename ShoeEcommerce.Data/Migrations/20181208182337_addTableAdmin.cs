using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeEcommerce.Data.Migrations
{
    public partial class addTableAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_ImgStores_Customers_CustomeridCustomer",
                table: "Link_ImgStores");

            migrationBuilder.DropIndex(
                name: "IX_Link_ImgStores_CustomeridCustomer",
                table: "Link_ImgStores");

            migrationBuilder.DropColumn(
                name: "CustomeridCustomer",
                table: "Link_ImgStores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomeridCustomer",
                table: "Link_ImgStores",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Link_ImgStores_CustomeridCustomer",
                table: "Link_ImgStores",
                column: "CustomeridCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_ImgStores_Customers_CustomeridCustomer",
                table: "Link_ImgStores",
                column: "CustomeridCustomer",
                principalTable: "Customers",
                principalColumn: "idCustomer",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
