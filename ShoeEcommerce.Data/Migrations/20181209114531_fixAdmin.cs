using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeEcommerce.Data.Migrations
{
    public partial class fixAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "id_Mer",
                table: "RegisterNotifies",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "id_Acc",
                table: "RegisterNotifies",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegisterNotifies_id_Acc",
                table: "RegisterNotifies",
                column: "id_Acc");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterNotifies_id_Mer",
                table: "RegisterNotifies",
                column: "id_Mer");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterNotifies_Accounts_id_Acc",
                table: "RegisterNotifies",
                column: "id_Acc",
                principalTable: "Accounts",
                principalColumn: "idAccount",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterNotifies_Merchants_id_Mer",
                table: "RegisterNotifies",
                column: "id_Mer",
                principalTable: "Merchants",
                principalColumn: "idMerchant",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterNotifies_Accounts_id_Acc",
                table: "RegisterNotifies");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisterNotifies_Merchants_id_Mer",
                table: "RegisterNotifies");

            migrationBuilder.DropIndex(
                name: "IX_RegisterNotifies_id_Acc",
                table: "RegisterNotifies");

            migrationBuilder.DropIndex(
                name: "IX_RegisterNotifies_id_Mer",
                table: "RegisterNotifies");

            migrationBuilder.AlterColumn<string>(
                name: "id_Mer",
                table: "RegisterNotifies",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "id_Acc",
                table: "RegisterNotifies",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
