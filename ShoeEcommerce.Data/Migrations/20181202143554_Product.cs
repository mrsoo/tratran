using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeEcommerce.Data.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageProducts_ProductDetails_productDetailidproductDetail",
                table: "ImageProducts");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Products",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "size",
                table: "Products",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "home",
                table: "Products",
                newName: "Home");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Products",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "brand",
                table: "Products",
                newName: "Brand");

            migrationBuilder.RenameColumn(
                name: "productDetailidproductDetail",
                table: "ImageProducts",
                newName: "ProductidProduct");

            migrationBuilder.RenameColumn(
                name: "idproductDetail",
                table: "ImageProducts",
                newName: "idProduct");

            migrationBuilder.RenameIndex(
                name: "IX_ImageProducts_productDetailidproductDetail",
                table: "ImageProducts",
                newName: "IX_ImageProducts_ProductidProduct");

            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "Products",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountidAccount",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Creat_date",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "Fee",
                table: "Products",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "IdAcc",
                table: "Products",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdRepository",
                table: "Products",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "Sex",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Products_AccountidAccount",
                table: "Products",
                column: "AccountidAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdRepository",
                table: "Products",
                column: "IdRepository");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageProducts_Products_ProductidProduct",
                table: "ImageProducts",
                column: "ProductidProduct",
                principalTable: "Products",
                principalColumn: "idProduct",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Accounts_AccountidAccount",
                table: "Products",
                column: "AccountidAccount",
                principalTable: "Accounts",
                principalColumn: "idAccount",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Repositories_IdRepository",
                table: "Products",
                column: "IdRepository",
                principalTable: "Repositories",
                principalColumn: "idRepository",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageProducts_Products_ProductidProduct",
                table: "ImageProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Accounts_AccountidAccount",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Repositories_IdRepository",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AccountidAccount",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdRepository",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AccountidAccount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Creat_date",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Fee",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdAcc",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdRepository",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Products",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Products",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "Home",
                table: "Products",
                newName: "home");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Products",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Products",
                newName: "brand");

            migrationBuilder.RenameColumn(
                name: "idProduct",
                table: "ImageProducts",
                newName: "idproductDetail");

            migrationBuilder.RenameColumn(
                name: "ProductidProduct",
                table: "ImageProducts",
                newName: "productDetailidproductDetail");

            migrationBuilder.RenameIndex(
                name: "IX_ImageProducts_ProductidProduct",
                table: "ImageProducts",
                newName: "IX_ImageProducts_productDetailidproductDetail");

            migrationBuilder.AlterColumn<string>(
                name: "size",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 10);

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    idproductDetail = table.Column<string>(maxLength: 10, nullable: false),
                    AccountidAccount = table.Column<string>(nullable: true),
                    IdAcc = table.Column<string>(maxLength: 10, nullable: false),
                    IdRepository = table.Column<string>(maxLength: 10, nullable: true),
                    count = table.Column<int>(nullable: false),
                    creat_date = table.Column<DateTime>(nullable: false),
                    fee = table.Column<float>(nullable: false),
                    idProduct = table.Column<string>(maxLength: 10, nullable: false),
                    price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.idproductDetail);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Accounts_AccountidAccount",
                        column: x => x.AccountidAccount,
                        principalTable: "Accounts",
                        principalColumn: "idAccount",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Repositories_IdRepository",
                        column: x => x.IdRepository,
                        principalTable: "Repositories",
                        principalColumn: "idRepository",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_idProduct",
                        column: x => x.idProduct,
                        principalTable: "Products",
                        principalColumn: "idProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_AccountidAccount",
                table: "ProductDetails",
                column: "AccountidAccount");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_IdRepository",
                table: "ProductDetails",
                column: "IdRepository");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_idProduct",
                table: "ProductDetails",
                column: "idProduct",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageProducts_ProductDetails_productDetailidproductDetail",
                table: "ImageProducts",
                column: "productDetailidproductDetail",
                principalTable: "ProductDetails",
                principalColumn: "idproductDetail",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
