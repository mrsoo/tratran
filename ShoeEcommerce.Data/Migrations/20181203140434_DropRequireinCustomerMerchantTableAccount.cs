using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeEcommerce.Data.Migrations
{
    public partial class DropRequireinCustomerMerchantTableAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Merchants_IdMerchant",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Customers_idCustomer",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "idCustomer",
                table: "Accounts",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "IdMerchant",
                table: "Accounts",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Merchants_IdMerchant",
                table: "Accounts",
                column: "IdMerchant",
                principalTable: "Merchants",
                principalColumn: "idMerchant",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Customers_idCustomer",
                table: "Accounts",
                column: "idCustomer",
                principalTable: "Customers",
                principalColumn: "idCustomer",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Merchants_IdMerchant",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Customers_idCustomer",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "idCustomer",
                table: "Accounts",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdMerchant",
                table: "Accounts",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Merchants_IdMerchant",
                table: "Accounts",
                column: "IdMerchant",
                principalTable: "Merchants",
                principalColumn: "idMerchant",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Customers_idCustomer",
                table: "Accounts",
                column: "idCustomer",
                principalTable: "Customers",
                principalColumn: "idCustomer",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
