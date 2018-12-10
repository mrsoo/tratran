using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeEcommerce.Data.Migrations
{
    public partial class Product_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Accounts_AccountidAccount",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AccountidAccount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AccountidAccount",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "IdAcc",
                table: "Products",
                newName: "idAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Products_idAccount",
                table: "Products",
                column: "idAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Accounts_idAccount",
                table: "Products",
                column: "idAccount",
                principalTable: "Accounts",
                principalColumn: "idAccount",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Accounts_idAccount",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_idAccount",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "idAccount",
                table: "Products",
                newName: "IdAcc");

            migrationBuilder.AddColumn<string>(
                name: "AccountidAccount",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_AccountidAccount",
                table: "Products",
                column: "AccountidAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Accounts_AccountidAccount",
                table: "Products",
                column: "AccountidAccount",
                principalTable: "Accounts",
                principalColumn: "idAccount",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
