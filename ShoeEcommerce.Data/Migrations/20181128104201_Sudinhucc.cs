using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeEcommerce.Data.Migrations
{
    public partial class Sudinhucc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Position_PositionidPosition",
                table: "Advertisements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "Positions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "idPosition");

            migrationBuilder.CreateTable(
                name: "RankVips",
                columns: table => new
                {
                    idRank = table.Column<string>(maxLength: 10, nullable: false),
                    viewRate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankVips", x => x.idRank);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Positions_PositionidPosition",
                table: "Advertisements",
                column: "PositionidPosition",
                principalTable: "Positions",
                principalColumn: "idPosition",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Positions_PositionidPosition",
                table: "Advertisements");

            migrationBuilder.DropTable(
                name: "RankVips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Position");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "idPosition");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Position_PositionidPosition",
                table: "Advertisements",
                column: "PositionidPosition",
                principalTable: "Position",
                principalColumn: "idPosition",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
