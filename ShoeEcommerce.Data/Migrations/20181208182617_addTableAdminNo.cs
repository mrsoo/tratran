using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeEcommerce.Data.Migrations
{
    public partial class addTableAdminNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisterNotifies",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    id_Acc = table.Column<string>(nullable: true),
                    id_Mer = table.Column<string>(nullable: true),
                    createdDate = table.Column<DateTime>(nullable: false),
                    Checked = table.Column<bool>(nullable: false),
                    stt = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterNotifies", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterNotifies");
        }
    }
}
