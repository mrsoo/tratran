using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeEcommerce.Data.Migrations
{
    public partial class fixAccountfieldRankVip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Addresses_Addressid",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Addresses_Addressid",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Emails_Addressid",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_Addressid",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Addressid",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "Addressid",
                table: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "rankVip",
                table: "Accounts",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "RankVipidRank",
                table: "Accounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RankVipidRank",
                table: "Accounts",
                column: "RankVipidRank");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_RankVips_RankVipidRank",
                table: "Accounts",
                column: "RankVipidRank",
                principalTable: "RankVips",
                principalColumn: "idRank",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_RankVips_RankVipidRank",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_RankVipidRank",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "RankVipidRank",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "Addressid",
                table: "Emails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Addressid",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "rankVip",
                table: "Accounts",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.CreateIndex(
                name: "IX_Emails_Addressid",
                table: "Emails",
                column: "Addressid");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Addressid",
                table: "Addresses",
                column: "Addressid");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Addresses_Addressid",
                table: "Addresses",
                column: "Addressid",
                principalTable: "Addresses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Addresses_Addressid",
                table: "Emails",
                column: "Addressid",
                principalTable: "Addresses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
